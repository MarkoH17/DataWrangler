using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataWrangler.DBOs;
using LiteDB;

namespace DataWrangler
{
    public class DataAccess : IDisposable
    {
        public const string CollectionPrefix = "col_";
        private readonly LiteDatabase _db;

        private readonly bool _skipAuditEntries;
        private readonly UserAccount _user;

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

        public StatusObject DeleteObjectById<T>(int id, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.Delete(id);
                return GetStatusObject(StatusObject.OperationTypes.Delete, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Delete, e, false);
            }
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

        public StatusObject GetCountOfObj<T>(string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.Count();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetCountOfObjByExpr<T>(BsonExpression expr, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);

                var result = collection.Count(expr);
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetCountOfRecordsByGlobalSearch(RecordType rT, string searchValue, string colName = null)
        {
            try
            {
                var collection = _getCollection<Record>(colName);

                var filter = _getQueryCmdRecordTypeAttributes(rT, DataProcessor.SafeString(searchValue));
                var expr = BsonExpression.Create(filter);
                var result = collection.Count(expr);
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectByFieldSearch<T>(string searchField, string searchValue, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.FindOne(Query.EQ(searchField, DataProcessor.SafeString(searchValue)));
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectById<T>(int id, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.FindById(id);
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectsByFieldSearch<T>(string searchField, string searchValue, int skip, int limit,
            string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.Find(Query.EQ(searchField, DataProcessor.SafeString(searchValue))).Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetObjectsByType<T>(int skip, int limit, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                IEnumerable<T> result = collection.FindAll().Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByExprSearch(BsonExpression expr, int skip, int limit, string colName = null)
        {
            try
            {
                var collection = _getCollection<Record>(colName);
                var result = collection.Find(expr).Skip(skip).Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetRecordsByGlobalSearch(RecordType rT, string searchValue, int skip, int limit,
            string colName = null)
        {
            try
            {
                var collection = _getCollection<Record>(colName);

                var filter = _getQueryCmdRecordTypeAttributes(rT, DataProcessor.SafeString(searchValue));
                var expr = BsonExpression.Create(filter);

                var result = collection.Find(expr).Skip(skip).Take(limit).ToArray();

                return GetStatusObject(StatusObject.OperationTypes.Read, result.ToArray(), true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
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

        public StatusObject InsertObject<T>(T obj, string colName = null, string indexCol = null, bool unique = false)
        {
            try
            {
                var collection = _getCollection<T>(colName, indexCol, unique);
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

        public StatusObject InsertObjects<T>(T[] objs, string colName = null, string indexCol = null)
        {
            try
            {
                var collection = _getCollection<T>(colName, indexCol);
                var result = collection.InsertBulk(objs);
                return GetStatusObject(StatusObject.OperationTypes.Create, result, result >= 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
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

        public StatusObject UpdateObject<T>(T obj, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
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

        private StatusObject _addAuditEntry(int objId, object obj, UserAccount user,
            StatusObject.OperationTypes operation)
        {
            try
            {
                var collection = _getCollection<AuditEntry>(null, "ObjectId");
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

        private ILiteCollection<T> _getCollection<T>(string colName = null, string indexCol = "Id", bool unique = false)
        {
            ILiteCollection<T> collection;
            if (!string.IsNullOrEmpty(colName))
                collection = _db.GetCollection<T>(_getCollectionName(colName));
            else
                collection = _db.GetCollection<T>(_getCollectionName<T>());

            if (indexCol == null || !indexCol.Equals("Id")) collection.EnsureIndex("Id");

            if (indexCol != null)
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

        private string _getCollectionName(string name)
        {
            return CollectionPrefix + name;
        }

        private string _getQueryCmdRecordTypeAttributes(RecordType rT, string searchValue)
        {
            var exprCmd = new StringBuilder();

            for (var i = 0; i < rT.Attributes.Keys.Count; i++)
            {
                exprCmd.Append(string.Format("{0} like \"%{1}%\"", "Attributes." + rT.Attributes.ElementAt(i).Key,
                    searchValue));
                if (i < rT.Attributes.Keys.Count - 1)
                    exprCmd.Append(" OR ");
            }

            return exprCmd.ToString();
        }
    }
}