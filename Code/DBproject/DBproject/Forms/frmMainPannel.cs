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
    public partial class frmMainPannel : Form
    {
        public frmMainPannel()
        {
            InitializeComponent();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                frmCategories frm = new frmCategories();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubCategories_Click(object sender, EventArgs e)
        {
            try
            {
                frmSubCategories frm = new frmSubCategories();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnitMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                frmUnits frm = new frmUnits();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                frmProducts frm = new frmProducts();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomers frm = new frmCustomers();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            try
            {
                frmStock frm = new frmStock();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStockDetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmStockDetails frm = new frmStockDetails();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmTransactions frm = new frmTransactions();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
