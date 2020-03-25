using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class AuditEntryRetriever : DataRetriever, IDataRetriever
    {
        /*
         * AuditEntryRetriever Modes
         * 0 -> For a UserAccount obj
         * 1 -> For a Record obj of a Record Type
         * 2 -> For a RecordType obj
         * 3 -> For all by a UserAccount
         */
        private readonly int _mode;
        private readonly int _objectId;
        private readonly RecordType _recordType;
        private readonly UserAccount _user;


        public AuditEntryRetriever(Dictionary<string, string> dbSettings, UserAccount user, bool auditsByUser = false)
        {
            //AuditEntries by Username
            DbSettings = dbSettings;
            _user = user;
            _mode = auditsByUser ? 3 : 0;
            LoadColumns();
        }

        public AuditEntryRetriever(Dictionary<string, string> dbSettings, RecordType rT, int recordId)
        {
            //AuditEntries by Record
            DbSettings = dbSettings;
            _recordType = rT;
            _objectId = recordId;
            _mode = 1;
            LoadColumns();
        }

        public AuditEntryRetriever(Dictionary<string, string> dbSettings, RecordType rT)
        {
            //AuditEntries by RecordType
            DbSettings = dbSettings;
            _objectId = rT.Id;
            _mode = 2;
            LoadColumns();
        }

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage, string searchField = null,
            string searchValue = null)
        {
            AuditEntry[] auditEntries = null;
            StatusObject fetchStatus = null;
            using (var oH = new ObjectHelper(DbSettings))
            {
                switch (_mode)
                {
                    case 0:
                        fetchStatus = oH.GetUserAccountAuditEntries(_user.Id, lowerPageBoundary, rowsPerPage);
                        break;
                    case 1:
                        fetchStatus = oH.GetRecordAuditEntries(_recordType, _objectId, lowerPageBoundary, rowsPerPage);
                        break;
                    case 2:
                        fetchStatus = oH.GetRecordTypeAuditEntries(_objectId, lowerPageBoundary, rowsPerPage);
                        break;
                    case 3:
                        fetchStatus = oH.GetAuditEntriesByUserAccount(_user, lowerPageBoundary, rowsPerPage);
                        break;
                }

                if (fetchStatus.Success)
                    auditEntries = (AuditEntry[]) fetchStatus.Result;
            }

            return DataProcessor.FillAuditEntryDataTable(Columns, auditEntries);
        }

        public void ResetRowCount()
        {
            RowCountValue = -1;
        }

        public string[] Columns => ColumnsValue.ToArray();

        public int RowCount
        {
            get
            {
                if (RowCountValue != -1) return RowCountValue;


                using (var oH = new ObjectHelper(DbSettings))
                {
                    StatusObject countStatus = null;
                    if (_mode == 0)
                        countStatus = oH.GetAuditEntryCountByObj("UserAccount", _user.Id);
                    else if (_mode == 1)
                        countStatus = oH.GetAuditEntryCountByObj("Record_" + _recordType.Id, _objectId);
                    else if (_mode == 2)
                        countStatus = oH.GetAuditEntryCountByObj("RecordType", _objectId);
                    else if (_mode == 3) countStatus = oH.GetAuditEntryCountByUser(_user);

                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
        }

        private void LoadColumns()
        {
            string[] cols;
            if (_mode == 3)
                cols = new[] {"Date", "Object Type", "Object ID", "Operation", "Notes"};
            else
                cols = new[] {"User", "Operation", "Date"};

            foreach (var col in cols)
                ColumnsValue.Add(col);
        }
    }
}