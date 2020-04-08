using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataWrangler.DBOs;
using LiteDB;
using LiteDB.Engine;

namespace DataWrangler
{
    public class DataAccess : IDisposable
    {
        public const string CollectionPrefix = "col_";
        private readonly LiteDatabase _db;
        private readonly UserAccount _user;
        public bool SkipAuditEntries;

        public DataAccess(string connectionString, UserAccount user = null, bool skipAuditEntries = false)
        {
            _db = new LiteDatabase(connectionString);
            _user = user;
            SkipAuditEntries = skipAuditEntries;

            BsonMapper.Global.Entity<AuditEntry>().DbRef(x => x.User, _getCollectionName(typeof(UserAccount)));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        private StatusObject _addAuditEntry(int objId, object obj, UserAccount user,
            StatusObject.OperationTypes operation, string note = null, string colName = null)
        {
            try
            {
                var collection = _getCollection<AuditEntry>(null, "ObjectId");
                var auditEntry = new AuditEntry
                {
                    ObjectId = objId,
                    ObjectLookupCol = colName == null ? _getCollectionName(obj.GetType()) : _getCollectionName(colName),
                    User = user,
                    Operation = operation,
                    Note = note,
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

        private ILiteCollection<T> _getCollection<T>(string colName = null, string indexCol = null, bool unique = false)
        {
            var collection = _db.GetCollection<T>(!string.IsNullOrEmpty(colName)
                ? _getCollectionName(colName)
                : _getCollectionName<T>());
            if (indexCol != null)
                collection.EnsureIndex(indexCol, unique);
            return collection;
        }

        private string _getCollectionName<T>()
        {
            return _getCollectionName(typeof(T));
        }

        private string _getCollectionName(Type t, string suffix = null)
        {
            return CollectionPrefix + t.Name + suffix;
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
                exprCmd.Append($"{"Attributes." + rT.Attributes.ElementAt(i).Key} like \"%{searchValue}%\"");
                if (i < rT.Attributes.Keys.Count - 1)
                    exprCmd.Append(" OR ");
            }

            return exprCmd.ToString();
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
                    var fileName = fileInfo.Name;
                    if (r.Attachments != null)
                        if (r.Attachments.Select(x => x.Split('/').Last()).ToList().Contains(fileInfo.Name))
                        {
                            var newName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                            newName += " - Copy";
                            fileName = newName + fileInfo.Extension;
                        }

                    var dbFilePath = $"$/records/{r.TypeId}/{r.Id}/{Guid.NewGuid().ToString()}/{fileName}";
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        var result = fs.Upload(dbFilePath, fileName, fileStream);
                        if (result != null && result.Length == fileInfo.Length)
                        {
                            fileIds.Add(result.Id);

                            if (!SkipAuditEntries)
                            {
                                var auditResult = _addAuditEntry(r.Id, r, _user, StatusObject.OperationTypes.FileAdd,
                                    null, "Record_" + r.TypeId);
                                if (!auditResult.Success) return auditResult;
                            }
                        }
                        else
                        {
                            return GetStatusObject(StatusObject.OperationTypes.FileAdd,
                                $"Failed to add file '{fileInfo.Name}' to record", false);
                        }
                    }
                }
                catch (LiteException e)
                {
                    return GetStatusObject(StatusObject.OperationTypes.FileAdd, e, false);
                }
            }

            return GetStatusObject(StatusObject.OperationTypes.FileAdd, fileIds, true);
        }

        public StatusObject CleanupRecordAttributes(RecordType rT, List<string> removedAttrs)
        {
            var recordCountStatus = GetCountOfObj<Record>("Record_" + rT.Id);
            var recordCount = 0;
            if (recordCountStatus.Success) recordCount = Convert.ToInt32(recordCountStatus.Result);

            for (var i = 0; i < recordCount; i += 500)
            {
                var recordFetchStatus = GetObjectsByType<Record>(i, i + 500, "Record_" + rT.Id);
                Record[] recordFetch;
                var updateNeeded = false;
                if (recordFetchStatus.Success)
                    recordFetch = (Record[]) recordFetchStatus.Result;
                else
                    return recordFetchStatus;

                foreach (var rec in recordFetch)
                    if (rec.Attributes.Keys.Intersect(removedAttrs).Any())
                    {
                        updateNeeded = true;
                        foreach (var removedAttr in removedAttrs)
                            if (rec.Attributes.Keys.Contains(removedAttr))
                                rec.Attributes.Remove(removedAttr);
                    }

                if (updateNeeded)
                {
                    var recordUpdateStatus = UpdateObjects(recordFetch, "Record_" + rT.Id);
                    if (recordUpdateStatus.Success)
                    {
                        var auditResult = _addAuditEntry(-1, recordFetch[0], _user, StatusObject.OperationTypes.Update,
                            "Performed record attribute cleanup", "Record_" + rT.Id);
                        if (!auditResult.Success) return auditResult;
                    }
                    else
                    {
                        return recordUpdateStatus;
                    }
                }
            }

            return GetStatusObject(StatusObject.OperationTypes.Update, true, true);
        }

        public StatusObject DeleteCollection<T>(string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = _db.DropCollection(collection.Name);
                return GetStatusObject(StatusObject.OperationTypes.Delete, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Delete, e, false);
            }
        }

        public StatusObject DeleteFileFromRecord(Record r, string fileId)
        {
            var fs = _db.FileStorage;

            if (!r.Attachments.Contains(fileId))
                return GetStatusObject(StatusObject.OperationTypes.FileRemove,
                    "Failed to remove file from record because it isn't associated with this record.", false);

            var result = fs.Delete(fileId);

            if (!SkipAuditEntries)
            {
                var auditResult = _addAuditEntry(r.Id, r, _user, StatusObject.OperationTypes.FileRemove, null,
                    "Record_" + r.TypeId);
                if (!auditResult.Success) return auditResult;
            }


            if (result)
            {
                r.Attachments.Remove(fileId);
                SkipAuditEntries = true;
                return UpdateObject(r, "Record_" + r.TypeId);
            }

            return GetStatusObject(StatusObject.OperationTypes.FileRemove, "Failed to remove file from record.", false);
        }

        public StatusObject DeleteFileOfRecordType(RecordType rT)
        {
            var fs = _db.FileStorage;

            var expr = BsonExpression.Create($"_id like \"$/records/{rT.Id}%\"");

            var files = fs.Find(expr).ToList();

            foreach (var file in files)
            {
                var deleteResult = fs.Delete(file.Id);
                if (!deleteResult)
                    return GetStatusObject(StatusObject.OperationTypes.FileRemove,
                        "Failed to bulk remove files from all records orphaned under Record Type " + rT.Name, false);
            }

            if (!SkipAuditEntries)
            {
                var auditResult = _addAuditEntry(rT.Id, rT, _user, StatusObject.OperationTypes.FileRemove,
                    "Deleted " + files.Count + " File Attachments for Record Type " + rT.Name);
                if (!auditResult.Success) return auditResult;
            }

            return GetStatusObject(StatusObject.OperationTypes.FileRemove, null, true);
        }

        public StatusObject DeleteObject<T>(T obj, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);

                var objId = obj.GetType().GetProperty("Id").GetValue(obj);
                var objIdVal = Convert.ToInt32(objId);
                var result = collection.Delete(objIdVal);

                if (!SkipAuditEntries)
                {
                    var auditResult = _addAuditEntry(objIdVal, obj, _user, StatusObject.OperationTypes.Delete, null,
                        colName);
                    if (!auditResult.Success) return auditResult;
                }

                return GetStatusObject(StatusObject.OperationTypes.Delete, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Delete, e, false);
            }
        }

        public StatusObject GetAuditEntriesByObjId<T>(BsonValue objId, int skip, int limit, string colName = null)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection
                    .Include(x => x.User)
                    .Find(Query.And(Query.EQ("ObjectId", objId),
                        Query.EQ("ObjectLookupCol",
                            colName == null ? _getCollectionName<T>() : _getCollectionName(colName))))
                    .OrderByDescending(x => x.Date).Skip(skip)
                    .Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetAuditEntriesByUser(UserAccount user, int skip, int limit)
        {
            try
            {
                var collection = _getCollection<AuditEntry>();
                var result = collection
                    .Include(x => x.User)
                    .FindAll()
                    .Where(x => x.User.Id == user.Id)
                    .OrderByDescending(x => x.Date).Skip(skip)
                    .Take(limit).ToArray();
                return GetStatusObject(StatusObject.OperationTypes.Read, result, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Read, e, false);
            }
        }

        public StatusObject GetCountOfAuditEntryByObj(string objLookupCol, int objId)
        {
            var expr = BsonExpression.Create(
                $"ObjectLookupCol = \"{_getCollectionName(objLookupCol)}\" and ObjectId = {objId}");
            try
            {
                var collection = _getCollection<AuditEntry>();

                var result = collection.Count(expr);
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

        public StatusObject GetDbSize()
        {
            try
            {
                var collection = _db.GetCollection("$database");
                var sizeResult = collection.FindAll().FirstOrDefault();
                sizeResult.TryGetValue("dataFileSize", out var size);
                return GetStatusObject(StatusObject.OperationTypes.System, size.AsInt32, true);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.System, e, false);
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
                var result = collection.Find(Query.EQ(searchField, DataProcessor.SafeString(searchValue))).Skip(skip)
                    .Take(limit).ToArray();
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

                if (!SkipAuditEntries)
                {
                    var auditResult = _addAuditEntry(result, obj, _user, StatusObject.OperationTypes.Create, null,
                        colName);
                    if (!auditResult.Success) return auditResult;
                }

                return GetStatusObject(StatusObject.OperationTypes.Create, result, result > 0);
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

                if (!SkipAuditEntries)
                {
                    var auditResult = _addAuditEntry(-1, objs[0], _user, StatusObject.OperationTypes.Create,
                        "Insert Bulk operation with " + objs.Length + " items", colName);
                    if (!auditResult.Success) return auditResult;
                }

                return GetStatusObject(StatusObject.OperationTypes.Create, result, result > 0);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Create, e, false);
            }
        }

        public StatusObject LoginUserAccount(string username, string password)
        {
            var result = GetObjectByFieldSearch<UserAccount>("username", username);
            if (result.Success && result.Result != null)
            {
                var userObj = (UserAccount) result.Result;
                var storedHash = userObj.Password;
                var hashBytes = Convert.FromBase64String(storedHash);

                var salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var calculatedHash = UserAccount.GetPasswordHash(password, salt);
                var loginSuccess = false;
                if (calculatedHash.Equals(storedHash))
                {
                    result.Result = userObj;
                    loginSuccess = true;
                }
                else
                {
                    result.Result = null;
                }

                var auditResult = _addAuditEntry(userObj.Id, userObj, userObj,
                    loginSuccess && userObj.Active ? StatusObject.OperationTypes.LoginSuccess : StatusObject.OperationTypes.LoginFailure);
                if (!auditResult.Success) return auditResult;
            }

            return result;
        }

        public StatusObject RebuildDatabase(Dictionary<string, string> dbSettings, bool usePassword = false,
            string newPassword = null)
        {
            try
            {
                var rebuildOpts = new RebuildOptions();

                if (usePassword)
                {
                    if (newPassword != null)
                    {
                        rebuildOpts.Password = newPassword;
                    }
                    else
                    {
                        dbSettings.TryGetValue("dbPass", out var currPassword);
                        rebuildOpts.Password = currPassword;
                    }
                }

                var result = _db.Rebuild(rebuildOpts);

                return GetStatusObject(StatusObject.OperationTypes.System, result, result >= 0L);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.System, e, false);
            }
        }

        public StatusObject SaveFile(string fileId, string savePath)
        {
            var fs = _db.FileStorage;

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

                if (!SkipAuditEntries)
                {
                    var auditResult = _addAuditEntry(objId, obj, _user, StatusObject.OperationTypes.Update, null,
                        colName);
                    if (!auditResult.Success) return auditResult;
                }


                return GetStatusObject(StatusObject.OperationTypes.Update, result, result);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Update, e, false);
            }
        }

        public StatusObject UpdateObjects<T>(T[] objs, string colName = null)
        {
            try
            {
                var collection = _getCollection<T>(colName);
                var result = collection.Update(objs);

                return GetStatusObject(StatusObject.OperationTypes.Update, result, result == objs.Length);
            }
            catch (LiteException e)
            {
                return GetStatusObject(StatusObject.OperationTypes.Update, e, false);
            }
        }
    }
}