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
    public partial class Upd_SalesYTDFrm : Form
    {
        public Upd_SalesYTDFrm()
        {
            InitializeComponent();
        }

        private void btn_upd_salesytd_Click(object sender, EventArgs e)
        {
            int custId = int.Parse(txtCustID.Text);
            int amount = int.Parse(txtAmount.Text);
            SqlConnect connection = new SqlConnect();
            try
            {
                connection.UpdateSalesYTD(custId, amount);
                MessageBox.Show("Update successful");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
