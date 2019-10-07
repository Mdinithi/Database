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
    public partial class UpdProdSalesYTD : Form
    {
        public UpdProdSalesYTD()
        {
            InitializeComponent();
        }

        private void btn_upd_salesytd_prod_Click(object sender, EventArgs e)
        {
            int prodId = int.Parse(txtProdID.Text);
            int amount = int.Parse(txtAmount.Text);
            SqlConnect connection = new SqlConnect();
            try
            {
                connection.UpdateProdSalesYTD(prodId, amount);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
