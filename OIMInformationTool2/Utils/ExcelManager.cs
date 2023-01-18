using System.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace OIMInformationTool2.Utils

{
    public class ExcelManager
    {


        public DataSet readExcelSheet(String path_file_xls)
        {


            var wbook = new XLWorkbook(path_file_xls);
            var workSheet = wbook.Worksheet(3);

            //Create a new DataTable.
            DataTable dt = new DataTable();

            //Loop through the Worksheet rows.
            bool firstRow = true;
            foreach (IXLRow row in workSheet.Rows())
            {
                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    //Add rows to DataTable.
                    dt.Rows.Add();
                    int i = 0;
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                        i++;
                    }
                }

            }

            DataSet data = new DataSet();
            data.Tables.Add(dt);

            return data;
        }


    }
}