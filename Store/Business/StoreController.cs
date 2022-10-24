using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Store.DataAccess;
using Store.Database;


namespace Store.Business
{
    public class StoreController
    {
        
        private static DataSet _dataset;
        private static SqlConnection _conn;




        public StoreController()
        {

            _dataset = new DataSet();
            _conn = new DbConnect().Conn;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StoreView());
        }


        //methods

        public static void Load(StoreView sv)
        {
            StoreModel.Display(_dataset, _conn);
            sv.Bind(_dataset.Tables[StoreModel._dataSetTableName]);
        }

        public static void Update()
        {
            StoreModel.Update(_dataset, _conn);
        }

        
        public static void Close()
        {
            Application.Exit();
        }
        
        
        
    }
}