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
    public partial class CountProductSale : Form
    {
        public CountProductSale()
        {
            InitializeComponent();
        }

        private void BtnCountSale_Click(object sender, EventArgs e)
        {
            try
            {
                int coundays = int.Parse(txtNoOfDays.Text);
                SqlConnect connect = new SqlConnect();
                string productSaleCountDetails = connect.GetCountSales(coundays);
                MessageBox.Show("The total Number of sales:"+productSaleCountDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
