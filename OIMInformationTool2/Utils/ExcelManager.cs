using System.Data;
using System.Data.OleDb;

namespace OIMInformationTool2.Utils

{
    public class ExcelManager
    {


        public DataSet readExcelSheet(String path_file_xls)
        {
            // Setting parameters for the excel OleDbConnection

            var connection_String_xls = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                        "Extended Properties='Excel 12.0 Xml;HDR=Yes;IMEX=0;';" +
                                        "Data Source=" + path_file_xls;
            // Creating the OleDbConnection connection
            var connection = new OleDbConnection(connection_String_xls);
            // Opening the connection
            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            // Generating the query
            command.CommandText = "Select * from [TULCAN_NOMINAL$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            // Filling the dataset form Excel using OleDbAdapter
            DataSet data = new DataSet();
            adapter.Fill(data);
            System.Diagnostics.Debug.WriteLine(data.Tables[0].Rows[0][0]);
            // Closing the connection
            connection.Close();
            return data;
        }



    }
}
