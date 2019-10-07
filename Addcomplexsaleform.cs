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
    public partial class Addcomplexsaleform : Form
    {
        public Addcomplexsaleform()
        {
            InitializeComponent();
        }

        private void btnAddComplexSale_Click(object sender, EventArgs e)
        {

            try
            {
                int custid = int.Parse(txtCustID.Text);
                int prodid = int.Parse(txtProdId.Text);
                int qty = int.Parse(txtPrdQty.Text);
                string date = dtSaleDate.Text;
                SqlConnect con = new SqlConnect();
                con.AddComplexSale(custid, prodid, qty,date);
                MessageBox.Show("Added complex Sale Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
