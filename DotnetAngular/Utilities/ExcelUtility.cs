using ClosedXML.Excel;
using System.Data;

namespace DotnetAngular.Utilities
{
    public static class ExcelUtility
    {
        public static DataTable Read(Stream fileStream, string sheetName = null)
        {
            using (XLWorkbook wb = new XLWorkbook(fileStream))
            {
                IXLWorksheet ws = null;
                if (!string.IsNullOrEmpty(sheetName) && !wb.TryGetWorksheet(sheetName, out ws))
                {
                    throw new Exception("Invalid file");
                }

                ws ??= wb.Worksheet(1);
                ws.SetAutoFilter(false);
                if (ws.Tables.Any())
                {
                    return ws.Table(0).AsNativeDataTable();
                }

                return ws.RangeUsed().AsTable().AsNativeDataTable();
            }
        }
    }
}
