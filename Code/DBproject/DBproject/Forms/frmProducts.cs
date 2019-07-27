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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (

                        string.IsNullOrEmpty(txtItemName.Text) ||
                        string.IsNullOrEmpty(txtItemCode.Text) ||
                        string.IsNullOrEmpty(txtMinLevelStock.Text) ||
                        string.IsNullOrEmpty(txtReorderQty.Text) ||
                        string.IsNullOrEmpty(txtRemarks.Text) ||
                        string.IsNullOrEmpty(txtSeqNo.Text) ||
                        string.IsNullOrEmpty(txtSellingRate.Text)


                    )
                {
                    MessageBox.Show("Please Enter Complete Information");
                }
                else
                {
                    AddUpdate add = new AddUpdate();
                    add.addUpdateProducts(
                                txtItemName.Text,
                                txtItemCode.Text,
                                txtSeqNo.Text,
                                txtMinLevelStock.Text,
                                txtReorderQty.Text,
                                txtRemarks.Text,
                                cmbType.Text,
                                Convert.ToInt32(cmbCategory.SelectedValue),
                                Convert.ToInt32(cmbSubCategory.SelectedValue),
                                Convert.ToDouble(txtSellingRate.Text),
                                0,
                                0
                           );    // 0 for add

                    MessageBox.Show("DATA ADEED");


                    //clear 
                    txtItemName.Clear();
                    txtItemCode.Clear();
                    txtSeqNo.Clear();
                    txtMinLevelStock.Clear();
                    txtReorderQty.Clear();
                    txtRemarks.Clear();
                    cmbType.Text = "";
                    txtSellingRate.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                cmbType.SelectedIndex = 0;

                Get get = new Get();

                DataSet dt = new DataSet();
                dt = get.getAllCategories();
                cmbCategory.DisplayMember = "Category_name";
                cmbCategory.ValueMember = "Category_ID";
                cmbCategory.DataSource = dt.Tables[0];



                dt = get.getAllSubCategoriesForThisCategory(Convert.ToInt32(cmbCategory.SelectedValue));
                cmbSubCategory.DisplayMember = "SubCategory_Name";
                cmbSubCategory.ValueMember = "SubCategory_ID";
                cmbSubCategory.DataSource = dt.Tables[0];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
