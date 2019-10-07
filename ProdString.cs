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
    public partial class ProdString : Form
    {
        public ProdString()
        {
            InitializeComponent();
        }

        private void Btn_GetProduct_String_Click(object sender, EventArgs e)
        {
            try
            {
                int prodid = int.Parse(txtProdId.Text);
                SqlConnect connect = new SqlConnect();
                string productDetails = connect.GetProdStringFromDB(prodid);
                MessageBox.Show(productDetails);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
