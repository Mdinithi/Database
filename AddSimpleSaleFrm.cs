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
    public partial class AddSimpleSaleFrm : Form
    {
        public AddSimpleSaleFrm()
        {
            InitializeComponent();
        }

        private void btnAddSimpleSale_Click(object sender, EventArgs e)
        {
            try
            {
                int custid = int.Parse(txtCustID.Text);
                int prodid = int.Parse(txtProdId.Text);
                int qty = int.Parse(txtPrdQty.Text);
                SqlConnect con = new SqlConnect();
                con.AddSimpleSale(custid, prodid, qty);
                MessageBox.Show("Added Simple Sale Ok");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
