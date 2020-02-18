using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler
{
    internal class ObjectHelper : IDisposable
    {
        public const int DefaultRecordsetSize = 250;
        private readonly DataAccess _dA;
        private readonly Dictionary<string, string> _dbSettings;

        public ObjectHelper(Dictionary<string, string> DbSettings, UserAccount user = null)
        {
            string connectionString;

            if (!DbSettings.ContainsKey("dbPass"))
                connectionString = string.Format("Filename={0};Connection=shared", DbSettings["dbFilePath"]);
            else
                connectionString = string.Format("Filename={0};Password='{1}';Connection=shared",
                    DbSettings["dbFilePath"], DbSettings["dbPass"]);

            _dA = new DataAccess(connectionString, user);
            _dbSettings = DbSettings;
        }

        public void Dispose()
        {
            _dA.Dispose();
        }

        public StatusObject RebuildDb(bool usePassword = false, string newPassword = null)
        {
            return _dA.RebuildDatabase(_dbSettings, usePassword, newPassword);
        }

        #region RecordType Accessors

        public StatusObject AddRecordType(string name, List<string> attributes, bool active)
        {
            var newRecordType = new RecordType
            {
                Name = name,
                Attributes = attributes,
                Active = active
            };
            return _dA.InsertObject(newRecordType);
        }

        public StatusObject AddRecordTypes(string[] names, List<string>[] attributes, bool[] actives)
        {
            if (names.Length == attributes.Length && names.Length == actives.Length)
            {
                var newRecordTypes = new RecordType[names.Length];
                for (var i = 0; i < names.Length; i++)
                    newRecordTypes[i] = new RecordType
                    {
                        Name = names[i],
                        Attributes = attributes[i],
                        Active = actives[i]
                    };

                return _dA.InsertObjects(newRecordTypes);
            }

            return _dA.GetStatusObject(StatusObject.OperationTypes.Create, "Mismatched number of values provided!",
                false);
        }

        public StatusObject GetRecordTypeById(int id)
        {
            return _dA.GetObjectById<RecordType>(id);
        }

        public StatusObject GetRecordTypes(int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetObjectsByType<RecordType>(skip, limit);
        }

        public StatusObject UpdateRecordType(RecordType rT)
        {
            rT.LastUpdated = DateTime.UtcNow;
            return _dA.UpdateObject(rT);
        }

        public StatusObject DeleteRecordType(RecordType rT)
        {
            return _dA.DeleteObjectById<RecordType>(rT.Id);
        }

        #endregion

        #region Record Accessors

        public StatusObject AddRecord(RecordType rT, Dictionary<string, string> attributes, bool active)
        {
            if (!attributes.Keys.Except(rT.Attributes).Any())
            {
                var newRecord = new Record
                {
                    TypeId = rT.Id,
                    Attributes = attributes,
                    Active = active
                };
                return _dA.InsertObject(newRecord);
            }

            return _dA.GetStatusObject(StatusObject.OperationTypes.Create,
                "Record contains attributes unknown to the RecordType definition", false);
        }

        public StatusObject AddRecords(Record[] records)
        {
            return _dA.InsertObjects(records);
        }

        public StatusObject AddAttachmentsToRecord(Record r, string[] attachmentPaths)
        {
            foreach (var file in attachmentPaths)
                if (!File.Exists(file))
                    return _dA.GetStatusObject(StatusObject.OperationTypes.Create,
                        "File specified for attachment is inaccessible", false);

            var uploadResults = _dA.AddFilesToRecord(r, attachmentPaths);
            if (uploadResults.Success)
            {
                r.Attachments = (List<string>) uploadResults.Result;
                return UpdateRecord(r);
            }

            return uploadResults;
        }

        public StatusObject GetRecordById(int id)
        {
            return _dA.GetObjectById<Record>(id);
        }

        public StatusObject GetRecordsByType(RecordType rT, int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetRecordsByType(rT, skip, limit);
        }

        public StatusObject UpdateRecord(Record r)
        {
            r.LastUpdated = DateTime.UtcNow;
            return _dA.UpdateObject(r);
        }

        public StatusObject DeleteRecord(Record r)
        {
            if (r.Attachments.Count > 0)
                foreach (var attachment in r.Attachments)
                {
                    var delAttachmentResult = _dA.DeleteFileFromRecord(r, attachment);
                    if (!delAttachmentResult.Success) return delAttachmentResult;
                }

            return _dA.DeleteObjectById<Record>(r.Id);
        }

        public StatusObject DeleteAttachmentFromRecord(Record r, string fileId)
        {
            return _dA.DeleteFileFromRecord(r, fileId);
        }

        public StatusObject SaveFileFromRecord(string fileId, string outputPath)
        {
            return _dA.SaveFile(fileId, outputPath);
        }

        #endregion

        #region UserAccount Accessors

        public StatusObject AddUserAccount(string username, string password, bool active)
        {
            var newUserAccount = new UserAccount
            {
                Username = username,
                Password = UserAccount.GetPasswordHash(password),
                Active = active
            };
            return _dA.InsertObject(newUserAccount, "Username", true);
        }

        public StatusObject GetUserAccountById(int id)
        {
            return _dA.GetObjectById<UserAccount>(id);
        }

        public StatusObject GetUserAccounts(int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetObjectsByType<UserAccount>(skip, limit);
        }

        public StatusObject UpdateUserAccount(UserAccount uA)
        {
            uA.LastUpdated = DateTime.UtcNow;
            return _dA.UpdateObject(uA);
        }

        #endregion

        #region Searches

        public StatusObject GetRecordsByTypeSearch(RecordType rT, string searchField, string searchTerm, int skip = 0,
            int limit = DefaultRecordsetSize)
        {
            return _dA.GetRecordsByTypeSearch(rT, searchField, searchTerm, skip, limit);
        }

        public StatusObject GetUserAccountByUsername(string username)
        {
            return _dA.GetObjectByFieldSearch<UserAccount>("username", username);
        }

        #endregion

        #region AuditEntries

        public StatusObject GetAuditEntriesByUsername(string username, int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetAuditEntriesByField("Username", username, skip, limit);
        }

        public StatusObject GetRecordAuditEntries(int objectId, int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetAuditEntriesByField<Record>("ObjectId", objectId, skip, limit);
        }

        public StatusObject GetRecordTypeAuditEntries(int objectId, int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetAuditEntriesByField<RecordType>("ObjectId", objectId, skip, limit);
        }

        public StatusObject GetUserAccountAuditEntries(int objectId, int skip = 0, int limit = DefaultRecordsetSize)
        {
            return _dA.GetAuditEntriesByField<Record>("ObjectId", objectId, skip, limit);
        }

        #endregion
    }
}