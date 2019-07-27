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
    public partial class frmSubCategories : Form
    {


        private int IDToUpdate_SubCategoires = 0;
 
        public frmSubCategories()
        {
            InitializeComponent();
        }

        private void frmSubCategories_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();

                dgvAllSubCategoriesDetails.DataSource = null;
                dgvAllSubCategoriesDetails.DataSource = get.getAllSubCategoriesDetails();


                DataSet dt = new DataSet();

                dt = get.getAllCategories();
                cmbCategories.DisplayMember = "Category_name";
                cmbCategories.ValueMember = "Category_ID";
                cmbCategories.DataSource = dt.Tables[0];
            }
            catch (Exception eex)
            {
                MessageBox.Show(eex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSubCategoryName.Text))
                {
                    MessageBox.Show("Please Enter Sub Category Name");
                }
                else
                {
                    AddUpdate add = new AddUpdate();
                    add.addUpdateSubCategories(
                        cmbCategories.Text, 
                        txtSubCategoryName.Text, 
                        txtSubCategoryDesc.Text, 
                        0, 
                        0
                    );    // 0 for add

                    Get get = new Get();
                    dgvAllSubCategoriesDetails.DataSource = null;
                    dgvAllSubCategoriesDetails.DataSource = get.getAllSubCategoriesDetails();

                    this.IDToUpdate_SubCategoires = 0;


                    txtSubCategoryName.Clear();
                    txtSubCategoryDesc.Clear(); 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtSubCategoryName.Text))
                {
                    MessageBox.Show("Please Select A Record To Update By Double Clicking..");
                }
                else
                {
                    if (this.IDToUpdate_SubCategoires == 0)
                    {
                        MessageBox.Show("Please Select A Record To Update By Double Clicking..");
                        return;
                    }
                    else
                    {

                        AddUpdate update = new AddUpdate();
                        update.addUpdateSubCategories(
                            cmbCategories.Text,
                            txtSubCategoryName.Text, 
                            txtSubCategoryDesc.Text, 
                            this.IDToUpdate_SubCategoires, 
                            1
                        );    // 1 for UDPATE

                        Get get = new Get();
                        dgvAllSubCategoriesDetails.DataSource = null;
                        dgvAllSubCategoriesDetails.DataSource = get.getAllSubCategoriesDetails();

                        this.IDToUpdate_SubCategoires = 0;

                    }

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void dgvAllSubCategoriesDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IDToUpdate_SubCategoires = Convert.ToInt32(dgvAllSubCategoriesDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtSubCategoryName.Text = dgvAllSubCategoriesDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSubCategoryDesc.Text = dgvAllSubCategoriesDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.cmbCategories.Text = dgvAllSubCategoriesDetails.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
