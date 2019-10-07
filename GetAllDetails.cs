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
    public partial class GetAllDetails : Form
    {
        public GetAllDetails()
        {
            InitializeComponent();
        }

        private void GetAllDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCustDetails_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            OracleDataAdapter test = con.GetCustomerDetails();
            DataTable ds = new DataTable();
            test.Fill(ds);
            grdAllData.DataSource = ds;
        }

        private void btnProdDetails_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            OracleDataAdapter test = con.GetProductDetails();
            DataTable ds = new DataTable();
            test.Fill(ds);
            grdAllData.DataSource = ds;
        }
    }
}
