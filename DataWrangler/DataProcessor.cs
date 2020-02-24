using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataWrangler.DBOs;
using OfficeOpenXml;

namespace DataWrangler
{
    public class DataProcessor
    {
        public Dictionary<int, string> GetSpreadsheetHeaders(string filePath, int sheetIdx = 1)
        {
            Dictionary<int, string> headerValues = null;
            var fi = new FileInfo(filePath);
            using (var p = new ExcelPackage(fi))
            {
                var ws = p.Workbook.Worksheets[sheetIdx];
                headerValues = ws.Cells[ws.Dimension.Start.Row, ws.Dimension.Start.Column, 1, ws.Dimension.End.Column]
                    .Where(x => !string.IsNullOrEmpty(x.Text)).ToDictionary(x => x.Start.Column, x => x.Text);
            }

            return headerValues;
        }

        public Record[] GetRecordsFromSheet(RecordType recordType, Dictionary<int, string> cols, string filePath,
            int sheetIdx = 1)
        {
            var records = new List<Record>();

            var filteredColumns = cols.Where(x => recordType.Attributes.Contains(x.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            var fi = new FileInfo(filePath);
            using (var p = new ExcelPackage(fi))
            {
                var ws = p.Workbook.Worksheets[sheetIdx];

                for (var i = 2; i <= ws.Dimension.End.Row; i++)
                {
                    var recordAttributes = new Dictionary<string, string>();

                    foreach (var col in filteredColumns) recordAttributes.Add(col.Value, ws.Cells[i, col.Key].Text);

                    var nRecord = new Record
                    {
                        TypeId = recordType.Id,
                        Attributes = recordAttributes,
                        Active = true
                    };

                    records.Add(nRecord);
                }
            }

            return records.ToArray();
        }

        public Dictionary<int, string> RemapHeaders(Dictionary<int, string> headers, RecordType rT,
            KeyValuePair<int, int>[] newMapping)
        {
            foreach (var pair in newMapping)
                if (headers.ContainsKey(pair.Key) && pair.Value >= 0 && pair.Value <= rT.Attributes.Count)
                    headers[pair.Key] = rT.Attributes[pair.Value];

            return headers;
        }

        public static bool IsColumnVisible(DataGridView gridView, DataGridViewCellValueEventArgs e)
        {
            if (gridView.FirstDisplayedScrollingColumnIndex == e.ColumnIndex)
            {
                if (gridView.FirstDisplayedScrollingColumnHiddenWidth != 0)
                {
                    return true;
                }
            }

            bool sameWidth = gridView.GetColumnDisplayRectangle(e.ColumnIndex, false).Width == gridView.GetColumnDisplayRectangle(e.ColumnIndex, true).Width;
            return !sameWidth;
        }

        #region Data Table Fillers
        public DataTable FillRecordDataTable(string[] cols, RecordType rT, Record[] records)
        {
            var dT = new DataTable();
            foreach (var col in cols) dT.Columns.Add(col);

            foreach (var rec in records)
            {
                var dR = dT.NewRow();
                dR["Id"] = rec.Id;
                foreach (var attr in rec.Attributes)
                    dR[attr.Key] = attr.Value;

                dT.Rows.Add(dR);
            }

            return dT;
        }

        public DataTable FillRecordTypeDataTable(string[] cols, RecordType[] recordTypes)
        {
            var dT = new DataTable();
            foreach (var i in recordTypes)
            {
                var dR = dT.NewRow();
                dR["Id"] = i.Id;
                dR["Name"] = i.Name;
                dR["Attributes"] = string.Join(", ", i.Attributes);
                dT.Rows.Add(dR);
            }

            return dT;
        }

        public DataTable FillUserAccountDataTable(string[] cols, UserAccount[] userAccounts)
        {
            var dT = new DataTable();
            foreach (var i in userAccounts)
            {
                var dR = dT.NewRow();
                dR["Id"] = i.Id;
                dR["Username"] = i.Username;
                dT.Rows.Add(dR);
            }

            return dT;
        }

        public DataTable FillAuditEntryDataTable(string[] cols, AuditEntry[] auditEntries)
        {
            var dT = new DataTable();
            foreach (var i in auditEntries)
            {
                var dR = dT.NewRow();
                dR["Id"] = i.Id;
                dR["User Account"] = i.User.Username;
                dR["Object Type"] = i.ObjectLookupCol.Replace(DataAccess.CollectionPrefix, "");
                dT.Rows.Add(dR);
            }

            return dT;
        }
        #endregion
    }
}