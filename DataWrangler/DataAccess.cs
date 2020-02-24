using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataWrangler.DBOs;
using LiteDB;

namespace DataWrangler
{
    public class DataAccess : IDisposable
    {
        public const string CollectionPrefix = "col_";
        private readonly LiteDatabase _db;
        private readonly UserAccount _user;

        private readonly bool _skipAuditEntries;

        public DataAccess(string connectionString, UserAccount user = null, bool skipAuditEntries = false)
        {
            _db = new LiteDatabase(connectionString);
            _user = user;
            _skipAuditEntries = skipAuditEntries;

            BsonMapper.Global.Entity<AuditEntry>().DbRef(x => x.User, _getCollectionName(typeof(UserAccount)));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public StatusObject AddFilesToRecord(Record r, string[] filePaths)
        {
            var fs = _db.FileStorage;
            var fileIds = new List<string>();

            foreach (var filePath in filePaths)
            {
                var fileInfo = new FileInfo(filePath);
                try
                {
                    var dbFilePath = string.Format("$/records/{0}/{1}/{2}/{3}", r.TypeId, r.Id,
                        Guid.NewGuid().ToString(), fileInfo.Name);
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        var result = fs.Upload(dbFilePath, fileInfo.Name, fileStream);
                        if (result != null && result.Length == fileInfo.Length)
                        {
                            fileIds.Add(result.Id);

                            if (!_skipAuditEntries)
                            {
                                var auditResult = _addAuditEntry(r.Id, r, _user, StatusObject.OperationTypes.FileAdd);
                                if (!auditResult.Success) return auditResult;
                            }
                        }
                        else
                        {
                            return GetStatusObject(StatusObject.OperationTypes.Create,
                                string.Format("Failed to add file '{0}' to record", fileInfo.Name), false);
                        }
                    }
                }
                catch (LiteException e)
                {
                    return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
                }
            }

            return GetStatusObject(StatusObject.OperationTypes.Create, fileIds, true);
        }

        public StatusObject DeleteFileFromRecord(Record r, string fileId)
        {
            var fs = _db.FileStorage;

            if (!r.Attachments.Contains(fileId))
                return GetStatusObject(StatusObject.OperationTypes.Delete,
                    "Failed to remove file from record because it isn't associated with this record.", false);

            var result = fs.Delete(fileId);

            if (!_skipAuditEntries)
            {
                var auditResult = _addAuditEntry(r.Id, r, _user, StatusObject.OperationTypes.FileRemove);
                if (!auditResult.Success) return auditResult;
            }


            if (result)
            {
                r.Attachments.Remove(fileId);
                return UpdateObject(r);
            }

            return GetStatusObject(StatusObject.OperationTypes.Delete, "Failed to remove file from record.", false);
        }

        public StatusObject SaveFile(string fileId, string savePath)
        {
            var fs = _db.FileStorage;

            if (File.Exists(savePath))
                return GetStatusObject(StatusObject.OperationTypes.Create,
                    "Save path specified already contains a file!", false);

            LiteFileInfo<string> saveFile;

            using (var fileStream = File.Create(savePath))
            {
                saveFile = fs.Download(fileId, fileStream);
            }

            var outputFile = new FileInfo(savePath);

            if (saveFile != null && outputFile.Exists && outputFile.Length == saveFile.Length)
                return GetStatusObject(StatusObject.OperationTypes.Create, true, true);

            return GetStatusObject(StatusObject.OperationTypes.Create,
                "Failed to save file from database to local file", false);
        }

        public StatusObject InsertObject<T>(T obj)
        {
            try
            {
                var collection = _getCollection<T>();
                int result = collection.Insert(obj);

                if (!_skipAuditEntries)
                {
                    var auditResult = _addAuditEntry(result, obj, _user, StatusObject.OperationTypes.Create);
                    if (!auditResult.Success) return auditResult;
                }

                return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
            }
        }

        public StatusObject InsertObject<T>(T obj, string indexCol, bool unique = false)
        {
            if (obj.GetType().GetProperty(indexCol) != null)
                try
                {
                    var collection = _getCollection<T>(indexCol, unique);
                    int result = collection.Insert(obj);

                    if (!_skipAuditEntries)
                    {
                        var auditResult = _addAuditEntry(result, obj, _user, StatusObject.OperationTypes.Create);
                        if (!auditResult.Success) return auditResult;
                    }

                    return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
                }
                catch (LiteException e)
                {
                    return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
                }

            return GetStatusObject(StatusObject.OperationTypes.Create,
                string.Format("Object '{0}' does not contain property '{1}'", obj.GetType().Name, indexCol), false);
        }

        public StatusObject InsertObjects<T>(T[] objs, string indexCol = "Id")
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.InsertBulk(objs);
                return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
            }
        }

        public StatusObject UpdateObject<T>(T obj)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.Update(obj);

                var objId = (int) obj.GetType().GetProperty("Id").GetValue(obj);

                if (!_skipAuditEntries)
                {
                    var auditResult = _addAuditEntry(objId, obj, _user, StatusObject.OperationTypes.Update);
                    if (!auditResult.Success) return auditResult;
                }


                return GetStatusObject(StatusObject.OperationTypes.Update, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Update, e, false);
            }
        }

        public StatusObject DeleteObjectById<T>(int id)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.Delete(id);
                return GetStatusObject(StatusObject.OperationTypes.Delete, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Delete, e, false);
            }
        }

        public StatusObject GetObjectsByType<T>(int skip, int limit)
        {
            try
            {
                var collection = _getCollection<T>();
                IEnumerable<T> result = collection.FindAll().Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByType(RecordType rT, int skip, int limit)
        {
            try
            {
                var collection = _getCollection<Record>();
                var result = collection.Find(Query.EQ("TypeId", rT.Id)).Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectById<T>(int id)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.FindById(id);
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectByFieldSearch<T>(string searchField, string searchValue)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.FindOne(Query.EQ(searchField, searchValue));
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectsByFieldSearch<T>(string searchField, string searchValue, int skip, int limit)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.Find(Query.EQ(searchField, searchValue)).Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByTypeSearch(RecordType rT, string searchField, string searchValue, int skip,
            int limit)
        {
            //TODO: Optimize Retrieval by not using LINQ method of filtering large recordset
            if (rT.Attributes.Contains(searchField))
                try
                {
                    var records = GetRecordsByType(rT, skip, limit);
                    var result = new List<Record>();
                    if (records.Success)
                    {
                        foreach (var record in (Record[]) records.Result)
                            if (record.Attributes.ContainsKey(searchField))
                                if (!string.IsNullOrEmpty(record.Attributes[searchField]))
                                    if (record.Attributes.ContainsValue(searchValue))
                                        result.Add(record);
                        return GetStatusObject(StatusObject.OperationTypes.Read, result.ToArray(), true);
                    }

                    return records;
                }
                catch (LiteException e)
                {
                    return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
                }

            return GetStatusObject(StatusObject.OperationTypes.Read,
                string.Format("SearchField is invalid ('{0}' is not a valid Attribute in '{1}')", searchField, rT.Name),
                false);
        }

        public StatusObject GetAuditEntriesByField<T>(string fieldName, BsonValue fieldValue, int skip, int limit)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection
                    .Include(x => x.User)
                    .Find(Query.And(Query.EQ(fieldName, fieldValue),
                        Query.EQ("ObjectLookupCol", _getCollectionName<T>())))
                    .OrderByDescending(x => x.Date).Skip(skip)
                    .Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetAuditEntriesByUsername(string username, int skip, int limit)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection
                    .Include(x => x.User)
                    .FindAll()
                    .OrderByDescending(x => x.Date).Skip(skip).Take(limit)
                    .Where(x => x.User.Username.Equals(username))
                    .ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject RebuildDatabase(Dictionary<string, string> dbSettings, bool usePassword = false,
            string newPassword = null)
        {
            try
            {
                string cmd;
                if (usePassword && newPassword != null)
                {
                    cmd = $"rebuild {{\"password\" : \"{newPassword}\"}};";
                }
                else
                {
                    dbSettings.TryGetValue("dbPass", out var currPass);

                    if (usePassword && currPass != null)
                        cmd = $"rebuild {{\"password\" : \"{currPass}\"}};";
                    else
                        cmd = "rebuild;";
                }

                var result = _db.Execute(cmd);

                return GetStatusObject(StatusObject.OperationTypes.Update, result, result.Single().AsDecimal == 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Update, e, false);
            }
        }

        private ILiteCollection<T> _getCollection<T>(string indexCol = "Id", bool unique = false)
        {
            var collection = _db.GetCollection<T>(_getCollectionName<T>());
            collection.EnsureIndex(indexCol, unique);
            return collection;
        }

        private string _getCollectionName<T>()
        {
            return _getCollectionName(typeof(T));
        }

        private string _getCollectionName(Type t)
        {
            return CollectionPrefix + t.Name;
        }

        public StatusObject GetStatusObject(StatusObject.OperationTypes operation, object result, bool success)
        {
            return new StatusObject
            {
                OperationType = operation,
                Result = result,
                Success = success
            };
        }

        private StatusObject _addAuditEntry(int objId, object obj, UserAccount user,
            StatusObject.OperationTypes operation)
        {
            try
            {
                var collection = _getCollection<AuditEntry>("ObjectId");
                var auditEntry = new AuditEntry
                {
                    ObjectId = objId,
                    ObjectLookupCol = _getCollectionName(obj.GetType()),
                    User = user,
                    Operation = operation,
                    Date = DateTime.UtcNow
                };
                int result = collection.Insert(auditEntry);

                return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetCountOfObj<T>()
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.Count();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }
    }
}