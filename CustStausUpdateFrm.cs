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
    public partial class CustStausUpdateFrm : Form
    {
        public CustStausUpdateFrm()
        {
            InitializeComponent();
        }

        private void btn_upd_status_Click(object sender, EventArgs e)
        {
            int custId = int.Parse(txtCustID.Text);
            string status = txtStatus.Text.ToUpper();
            SqlConnect connection = new SqlConnect();
            try
            {
                connection.UpdateCustStatus(custId, status);
                MessageBox.Show("Update status successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
