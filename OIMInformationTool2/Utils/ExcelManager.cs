using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;

namespace OIMInformationTool2.Utils

{
    public class ExcelManager
    {


        public DataSet readExcelSheet(String path_file_xls)
        {
            // Setting parameters for the excel OleDbConnection

            var connection_String_xls = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};Dbq="+path_file_xls+"; Extensions=xls/xlsx;Persist Security Info=False";
            // Creating the OleDbConnection connection
            var connection = new OdbcConnection();
            connection.ConnectionString = connection_String_xls;
            // Opening the connection
            connection.Open();
            OdbcCommand command = new OdbcCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            // Generating the query
            command.CommandText = "Select * from [TULCAN_NOMINAL$]";
            OdbcDataAdapter adapter = new OdbcDataAdapter();
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
