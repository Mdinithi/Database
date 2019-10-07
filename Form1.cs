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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddCustToDB_Click(object sender, EventArgs e)
        {
            Details ds = new Details();
            ds.ShowDialog();
        }

        private void DELETE_ALL_CUSTOMERS_FROM_DB_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            string deletedRows=  con.DeleteAllCustomersFromDB();
            MessageBox.Show(deletedRows + " rows deleted sucessfully");
        }

        private void ADD_PROD_TO_DB_Click(object sender, EventArgs e)
        {
            ProductDetails prodDetails = new ProductDetails();
            prodDetails.ShowDialog();
        }

        private void DELETE_ALL_PRODUCTS_FROM_DB_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            string deletedRows = con.DeleteAllProductsFromDB();
            MessageBox.Show(deletedRows + " rows deleted sucessfully");
        }

        private void GET_CUST_STRING_FROM_DB_Click(object sender, EventArgs e)
        {
            try
            {
                CustString custStr = new CustString();
                custStr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UPD_CUST_SALESYTD_IN_DB_Click(object sender, EventArgs e)
        {
            Upd_SalesYTDFrm updFrm = new Upd_SalesYTDFrm();
            updFrm.ShowDialog();
        }

        private void GET_PROD_STRING_FROM_DB_Click(object sender, EventArgs e)
        {
            ProdString product = new ProdString();
            product.ShowDialog();
        }

        private void UPD_PROD_SALESYTD_IN_DB_Click(object sender, EventArgs e)
        {
            UpdProdSalesYTD prodUpdateFrm = new UpdProdSalesYTD();
            prodUpdateFrm.Show();
        }

        private void UPD_CUST_STATUS_IN_DB_Click(object sender, EventArgs e)
        {
            CustStausUpdateFrm updateStatus = new CustStausUpdateFrm();
            updateStatus.Show();
        }

        private void ADD_SIMPLE_SALE_TO_DB_Click(object sender, EventArgs e)
        {
            AddSimpleSaleFrm simplesale = new AddSimpleSaleFrm();
            simplesale.Show();
        }

        private void SUM_CUST_SALESYTD_Click(object sender, EventArgs e)
        { 
            SqlConnect con = new SqlConnect();
           string sum= con.GetSumCustSalesYTD();
            MessageBox.Show("All Customer total: " + sum);
        }

        private void GetAllCUST_Click(object sender, EventArgs e)
        {
            GetAllDetails frmGetCustDetails = new GetAllDetails();
            frmGetCustDetails.Show();
      
        }

        private void AddCComplexSale_Click(object sender, EventArgs e)
        {
            Addcomplexsaleform complexSale = new Addcomplexsaleform();
            complexSale.ShowDialog();
        }

        private void BtnGetAllSales_Click(object sender, EventArgs e)
        {
            GetAllSales getSales = new GetAllSales();
            getSales.ShowDialog();
        }

        private void CountProductSales_Click(object sender, EventArgs e)
        {
            CountProductSale productCount = new CountProductSale();
            productCount.ShowDialog();
        }

        private void btnDeleteSaleFromDB_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
            string deletedRows = con.DeleteSaleFromDB();
            MessageBox.Show("Deleted SaleOK. SaleID:" + deletedRows );
        }

        private void BtnDeleteAllSale_Click(object sender, EventArgs e)
        {
            SqlConnect con = new SqlConnect();
           con.DeleteAllSaleFromDB();
            MessageBox.Show("Deleted All Sales");
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            CustString delCustomer = new CustString();
            delCustomer.ShowDialog();
        }
    }
}
