using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class GetAllSales : Form
    {
        public GetAllSales()
        {
            InitializeComponent();
        }

        private void GetAllSales_Load(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            OracleDataAdapter test = con.GetAllSalesDetails();
            DataTable ds = new DataTable();
            test.Fill(ds);
            grdAllData.DataSource = ds;
        }
    }
}
