using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store.Business;

namespace Store
{
    public partial class StoreView : Form
    {
        public StoreView()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            
            StoreController.Load(this);
        }

        public void Bind(DataTable table)
        {
            dataGridView.DataSource = table;
            dataGridView.Refresh();

        }

        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            StoreController.Close();

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            StoreController.Update();

        }
    }
}