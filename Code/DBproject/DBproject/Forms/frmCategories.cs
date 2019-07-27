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
    public partial class frmCategories : Form
    {
        private int IDToUpdate_Categoires = 0;

        public frmCategories()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoriesName.Text))
                {
                    MessageBox.Show("Please Enter Category Name");
                }
                else
                {
                    AddUpdate add = new AddUpdate();
                    add.addUpdateCategories(
                        txtCategoriesName.Text,
                        txtCategoryDesc.Text, 
                        0,
                        0
                    );    // 0 for add

                    Get get = new Get();
                    dgvAllCategoriesDetails.DataSource = null;
                    dgvAllCategoriesDetails.DataSource = get.getAllCategoriesDetails();

                    this.IDToUpdate_Categoires = 0;
                
                    txtCategoriesName.Clear();
                    txtCategoryDesc.Clear(); 
                
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                dgvAllCategoriesDetails.DataSource = null;
                dgvAllCategoriesDetails.DataSource = get.getAllCategoriesDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvAllCategoriesDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.IDToUpdate_Categoires = Convert.ToInt32(dgvAllCategoriesDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCategoriesName.Text = dgvAllCategoriesDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCategoryDesc.Text = dgvAllCategoriesDetails.Rows[e.RowIndex].Cells[2].Value.ToString();

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

                if (string.IsNullOrEmpty(txtCategoriesName.Text))
                {
                    MessageBox.Show("Please Select A Record To Update By Double Clicking..");
                }
                else
                {
                    if (this.IDToUpdate_Categoires == 0)
                    {
                        MessageBox.Show("Please Select A Record To Update By Double Clicking..");
                        return;
                    }
                    else
                    {
                        AddUpdate add = new AddUpdate();
                        
                        add.addUpdateCategories(
                            txtCategoriesName.Text, 
                            txtCategoryDesc.Text, 
                            this.IDToUpdate_Categoires, 
                            1
                        );    // 1 for UPDATE

                        Get get = new Get();
                        dgvAllCategoriesDetails.DataSource = null;
                        dgvAllCategoriesDetails.DataSource = get.getAllCategoriesDetails();

                        this.IDToUpdate_Categoires = 0;

                        txtCategoriesName.Clear();
                        txtCategoryDesc.Clear(); 
                    }

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }
    }
}
