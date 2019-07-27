using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBproject
{
    public partial class frmStockDetails : Form
    {
        public frmStockDetails()
        {
            InitializeComponent();
        }

        private void frmStockDetails_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                dgvAllStockDetails.DataSource = null;
                dgvAllStockDetails.DataSource = get.getAllStockDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
