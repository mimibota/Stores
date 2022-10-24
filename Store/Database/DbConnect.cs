using System.Data.SqlClient;

namespace Store.Database
{
    public class DbConnect
    {


        public SqlConnection Conn;


        public DbConnect()
        {
            Conn = new SqlConnection("Server=.\\SQL2019EXPRESS;Integrated security=true; Database=midterm_db;");

        }


    }
}