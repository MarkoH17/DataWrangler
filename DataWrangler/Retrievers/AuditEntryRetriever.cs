using System.Collections.Generic;
using System.Data;
using DataWrangler.DBOs;

namespace DataWrangler.Retrievers
{
    public class AuditEntryRetriever : DataRetriever, IDataRetriever
    {
        private readonly UserAccount _user;
        private readonly RecordType _recordType;
        private readonly int _objectId;

        /*
         * AuditEntryRetriever Modes
         * 0 -> By UserAccount obj
         * 1 -> For a Record obj of a Record Type
         * 2 -> For a RecordType obj
         */
        private readonly int _mode;
        

        public AuditEntryRetriever(Dictionary<string, string> dbSettings, UserAccount user)
        {
            //AuditEntries by Username
            DbSettings = dbSettings;
            _user = user;
            _mode = 0;
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
                    {
                        countStatus = oH.GetAuditEntryCountByObj("User.$id", _user.Id);
                    }
                    else if (_mode == 1)
                    {
                        countStatus = oH.GetAuditEntryCountByObj("Record_" + _recordType.Id, _objectId);
                    }
                    else if (_mode == 2)
                    {
                        countStatus = oH.GetAuditEntryCountByObj("RecordType", _objectId);
                    }
                    
                    if (countStatus.Success) RowCountValue = (int) countStatus.Result;
                }

                return RowCountValue;
            }
        }

        private void LoadColumns()
        {
            foreach (var col in new[] {"User", "Operation", "Date"})
                ColumnsValue.Add(col);
        }
    }
}