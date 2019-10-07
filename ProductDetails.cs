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
    public partial class ProductDetails : Form
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int prodId = int.Parse(txtProdId.Text.ToString());
                string prodName = txtProdName.Text.ToString();
                double prodPrice = double.Parse(txtProdPrice.Text);

                SqlConnect connect = new SqlConnect();


                OracleConnection con = connect.ConnectToSqlDB();

                connect.AddProductToDB(con, prodId, prodName,prodPrice);
                MessageBox.Show("Product Added Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
