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
    public partial class CustString : Form
    {
        public CustString()
        {
            InitializeComponent();
        }

        private void Btn_GetCustomer_String_Click(object sender, EventArgs e)
        {
            try
            {
                int custId = int.Parse(txtCustId.Text.ToString());
                SqlConnect con = new SqlConnect();
                string customerString = con.GetCustStringFromDB(custId);
                MessageBox.Show(customerString);
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {

            int custId = int.Parse(txtCustId.Text.ToString());
            SqlConnect con = new SqlConnect();
            con.DeleteCustomer(custId);
            MessageBox.Show("Customer deleted OK");
        }
    }
}
