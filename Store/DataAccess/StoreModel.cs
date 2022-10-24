using System;
using System.Data;
using System.Data.SqlClient;
using Store.Business;
using Store.Database;

namespace Store.DataAccess
{
    public class StoreModel
    {
        
        private static SqlDataAdapter _adapter;
        private static string _dataBaseTableName = "dbo.Store";
        public static string _dataSetTableName = "x";

        public static void Display(DataSet dataset, SqlConnection conn)
        {
            conn.Open();
            MyAdapter(conn).Fill(dataset, _dataSetTableName);
            conn.Close();
            
        }

        public static void Update(DataSet dataset, SqlConnection conn)
        {
            conn.Open();
            MyAdapter(conn).Update(dataset, _dataSetTableName);
            conn.Close();
        }

        public static void Delete(DataSet dataset, SqlConnection conn)
        {

        }

        private static SqlDataAdapter MyAdapter(SqlConnection connection)
        {
            if (_adapter == null)
            {
                _adapter = new SqlDataAdapter();
                
                _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                
                //Select

                _adapter.SelectCommand = new SqlCommand("SELECT * FROM dbo.Store;", connection);
                

                //insert
                _adapter.InsertCommand = new SqlCommand("INSERT INTO dbo.Store (name, description) VALUES(@name, @description);", connection);
                _adapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 128, "name");
                _adapter.InsertCommand.Parameters.Add("@description", SqlDbType.Text, -1, "description");
                //_adapter.InsertCommand.Parameters.Add("@date_created", SqlDbType.Date, 32, "date_created");
                
                
                //update
                
                _adapter.UpdateCommand = new SqlCommand("UPDATE dbo.Store SET name = @name, description = @description WHERE id = @id;", connection);
                _adapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 128, "name");
                _adapter.UpdateCommand.Parameters.Add("@description", SqlDbType.Text, -1, "description");
                //_adapter.InsertCommand.Parameters.Add("@date_created", SqlDbType.Date, 32, "date_created");
                _adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

                //delete
                _adapter.DeleteCommand = new SqlCommand("DELETE FROM dbo.Store WHERE @id = id;", connection);
                _adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

                
             //   _adapter.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
                
                return _adapter;
            }
            
            return _adapter;
            
        }


        // private static void OnRowUpdating(Object sender, SqlRowUpdatingEventArgs args)
        // {
        //     if (args.StatementType == StatementType.Insert)
        //     {
        //         args.Status
        //     }
        // }

    }
}