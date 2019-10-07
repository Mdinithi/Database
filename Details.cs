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
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }

        private void Add_Cust_to_DB_Click(object sender, EventArgs e)
        {
            try
            {
                int custId = int.Parse(txtCustID.Text.ToString());
                string custName = txtCustName.Text.ToString();

                SqlConnect connect = new SqlConnect();
               
                 
                OracleConnection con = connect.ConnectToSqlDB();
               
                connect.AddCustomerToDB(con, custId, custName);
                MessageBox.Show("Customer Added Successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    }
}
