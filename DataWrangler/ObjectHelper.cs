using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataWrangler.DBOs;

namespace DataWrangler
{
    internal class ObjectHelper : IDisposable
    {
        private readonly DataAccess _dA;

        public ObjectHelper(string dbFilePath, string dbPassword = null)
        {
            string connectionString = null;
            if (string.IsNullOrEmpty(dbPassword))
                connectionString = string.Format("Filename={0};Connection=shared", dbFilePath);
            else
                connectionString =
                    string.Format("Filename={0};Password='{1}';Connection=shared", dbFilePath, dbPassword);

            _dA = new DataAccess(connectionString);
        }

        public void Dispose()
        {
            _dA.Dispose();
        }

        public StatusObject RebuildDb()
        {
            return _dA.RebuildDatabase();
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

        public StatusObject GetRecordTypes()
        {
            return _dA.GetObjectsByType<RecordType>();
        }

        public StatusObject UpdateRecordType(RecordType rT)
        {
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

        public StatusObject AddRecords(RecordType[] rT, Dictionary<string, string>[] attributes, bool[] actives)
        {
            if (rT.Length == attributes.Length && rT.Length == actives.Length)
            {
                var newRecords = new Record[rT.Length];
                for (var i = 0; i < rT.Length; i++)
                    if (!attributes[i].Keys.Except(rT[i].Attributes).Any())
                        newRecords[i] = new Record
                        {
                            TypeId = rT[i].Id,
                            Attributes = attributes[i],
                            Active = actives[i]
                        };
                return _dA.InsertObjects(newRecords);
            }

            return _dA.GetStatusObject(StatusObject.OperationTypes.Create, "Mismatched number of values provided!",
                false);
        }

        public StatusObject AddAttachmentsToRecord(Record r, string[] attachmentPaths)
        {
            foreach (var file in attachmentPaths)
                if (!File.Exists(file))
                    return _dA.GetStatusObject(StatusObject.OperationTypes.Create,
                        "File specified for attachment is inaccessible", false);
            var uploadResults = _dA.AddFilesToRecord(r.TypeId, r.Id, attachmentPaths);
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

        public StatusObject GetRecordsByType(RecordType rT)
        {
            return _dA.GetRecordsByType(rT);
        }

        public StatusObject UpdateRecord(Record r)
        {
            return _dA.UpdateObject(r);
        }

        public StatusObject UpdateRecords(Record[] records)
        {
            return _dA.UpdateObjects(records);
        }

        public StatusObject DeleteRecord(Record r)
        {
            if (r.Attachments.Count > 0)
            {
                foreach (var attachment in r.Attachments)
                {
                    var delAttachmentResult = _dA.DeleteFileFromRecord(r, attachment);
                    if (!delAttachmentResult.Success)
                        return delAttachmentResult;
                }
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

        public StatusObject AddUserAccount(string username, string password, UserAccount.Permissions permission,
            bool active)
        {
            var newUserAccount = new UserAccount
            {
                Username = username,
                Password = UserAccount.GetPasswordHash(password),
                Permission = permission,
                Active = active
            };
            return _dA.InsertObject(newUserAccount, "Username");
        }

        public StatusObject GetUserAccountById(int id)
        {
            return _dA.GetObjectById<UserAccount>(id);
        }

        public StatusObject GetUserAccounts()
        {
            return _dA.GetObjectsByType<UserAccount>();
        }

        public StatusObject UpdateUserAccount(UserAccount uA)
        {
            return _dA.UpdateObject(uA);
        }

        #endregion

        #region Searches

        public StatusObject GetRecordsByTypeSearch(RecordType rT, string searchField, string searchTerm)
        {
            return _dA.GetRecordsByTypeSearch(rT, searchField, searchTerm);
        }

        public StatusObject GetUserAccountByUsername(string username)
        {
            return _dA.GetObjectByFieldSearch<UserAccount>("username", username);
        }

        #endregion
    }
}