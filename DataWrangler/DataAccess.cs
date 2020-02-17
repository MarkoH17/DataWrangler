using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataWrangler.DBOs;
using LiteDB;

namespace DataWrangler
{
    internal class DataAccess : IDisposable
    {
        private readonly LiteDatabase _db;
        private readonly UserAccount _user;

        public DataAccess(UserAccount user, string connectionString)
        {
            _db = new LiteDatabase(connectionString);
            _user = user;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public StatusObject AddFilesToRecord(int recordTypeId, int recordId, string[] filePaths)
        {
            var fs = _db.FileStorage;
            var fileIds = new List<string>();

            foreach (var filePath in filePaths)
            {
                var fileInfo = new FileInfo(filePath);
                try
                {
                    var dbFilePath = string.Format("$/records/{0}/{1}/{2}/{3}", recordTypeId, recordId,
                        Guid.NewGuid().ToString(), fileInfo.Name);
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        var result = fs.Upload(dbFilePath, fileInfo.Name, fileStream);
                        if (result != null && result.Length == fileInfo.Length)
                            fileIds.Add(result.Id);
                        else
                            return GetStatusObject(StatusObject.OperationTypes.Create,
                                string.Format("Failed to add file '{0}' to record", fileInfo.Name), false);
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

                var auditResult = _addAuditEntry(result, obj, _user, StatusObject.OperationTypes.Create);
                if (!auditResult.Success) return auditResult;

                return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
            }
        }

        public StatusObject InsertObject<T>(T obj, string indexCol)
        {
            if (obj.GetType().GetProperty(indexCol) != null)
                try
                {
                    var collection = _getCollection<T>(indexCol);
                    int result = collection.Insert(obj);

                    var auditResult = _addAuditEntry(result, obj, _user, StatusObject.OperationTypes.Create);
                    if (!auditResult.Success) return auditResult;

                    return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
                }
                catch (LiteException e)
                {
                    return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
                }

            return GetStatusObject(StatusObject.OperationTypes.Create,
                string.Format("Object '{0}' does not contain property '{1}'", obj.GetType().Name, indexCol), false);
        }

        public StatusObject InsertObjects<T>(T[] objs)
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
                var auditResult = _addAuditEntry(objId, obj, _user, StatusObject.OperationTypes.Update);
                if (!auditResult.Success) return auditResult;

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

        public StatusObject GetObjectsByType<T>()
        {
            try
            {
                var collection = _getCollection<T>();
                IEnumerable<T> result = collection.FindAll().ToList();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByType(RecordType rT)
        {
            try
            {
                var collection = _getCollection<Record>();
                var result = collection.Query().Where(o => o.TypeId == rT.Id).ToList();
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

        public StatusObject GetObjectsByFieldSearch<T>(string searchField, string searchValue)
        {
            try
            {
                var collection = _getCollection<T>();
                var result = collection.Find(Query.EQ(searchField, searchValue)).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByTypeSearch(RecordType rT, string searchField, string searchValue)
        {
            if (rT.Attributes.Contains(searchField))
                try
                {
                    var records = GetRecordsByType(rT);

                    if (records.Success)
                    {
                        var result = ((List<Record>) records.Result)
                            .Where(r => r.Attributes[searchField].Equals(searchValue)).ToList();
                        return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
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

        public StatusObject GetAuditEntriesByField<T>(string fieldName, BsonValue fieldValue)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection
                    .Find(Query.And(Query.EQ(fieldName, fieldValue),
                        Query.EQ("ObjectLookupCol", _getCollectionName<T>()))).OrderByDescending(x => x.Date).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetAuditEntriesByField(string fieldName, BsonValue fieldValue)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection.Find(Query.EQ(fieldName, fieldValue)).OrderByDescending(x => x.Date).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject RebuildDatabase()
        {
            try
            {
                var result = _db.Execute("rebuild;");
                return GetStatusObject(StatusObject.OperationTypes.Update, result, result.Single().AsDecimal == 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Update, e, false);
            }
        }

        private ILiteCollection<T> _getCollection<T>(string indexCol = "Id")
        {
            var collection = _db.GetCollection<T>(_getCollectionName<T>());
            collection.EnsureIndex(indexCol);
            return collection;
        }

        private string _getCollectionName<T>()
        {
            return _getCollectionName(typeof(T));
        }

        private string _getCollectionName(Type t)
        {
            return "col_" + t.Name;
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
                    Username = user.Username,
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
    }
}