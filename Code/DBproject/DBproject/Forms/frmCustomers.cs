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
    public partial class frmCustomers : Form
    {


        private int idToUpdate = 0;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                dgvAllCustomerDetails.DataSource = null;
                dgvAllCustomerDetails.DataSource = get.getAllCustomerDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                      string.IsNullOrEmpty(txtCustomerName.Text) 
                   )
                {
                    MessageBox.Show("Please Enter Information In All The Fields With '*' ..");
                }
                else
                {
                    AddUpdate add = new AddUpdate();
                    add.addUpdateCustomerDetails(
                            txtCustomerName.Text,
                            txtAddress.Text,
                            txtFaxNumber.Text,
                            txtRemarks.Text,
                            txtCustomerCOde.Text,
                            txtCity.Text,
                            txtAddress2.Text,
                            txtMobileNO.Text,
                            txtEmailID.Text,
                            0,
                            0                   // ADD
                        );

                    MessageBox.Show("Data Added");



                    txtCustomerName.Clear();
                    txtAddress.Clear();
                    txtFaxNumber.Clear();
                    txtRemarks.Clear();
                    txtCustomerCOde.Clear();
                    txtCity.Clear();
                    txtAddress2.Clear();
                    txtMobileNO.Clear();
                    txtEmailID.Clear();


                    Get get = new Get();
                    dgvAllCustomerDetails.DataSource = null;
                    dgvAllCustomerDetails.DataSource = get.getAllCustomerDetails();


                    this.idToUpdate = 0;
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
                if (
                      string.IsNullOrEmpty(txtCustomerName.Text)
                   )
                {
                    MessageBox.Show("Select Record By Double Clicking..");
                }
                else
                {
                    AddUpdate add = new AddUpdate();
                    add.addUpdateCustomerDetails(
                            txtCustomerName.Text,
                            txtAddress.Text,
                            txtFaxNumber.Text,
                            txtRemarks.Text,
                            txtCustomerCOde.Text,
                            txtCity.Text,
                            txtAddress2.Text,
                            txtMobileNO.Text,
                            txtEmailID.Text,
                            this.idToUpdate,
                            1                   // UPDATE
                        );

                    MessageBox.Show("Data Updated");
                    txtCustomerName.Clear();
                    txtAddress.Clear();
                    txtFaxNumber.Clear();
                    txtRemarks.Clear();
                    txtCustomerCOde.Clear();
                    txtCity.Clear();
                    txtAddress2.Clear();
                    txtMobileNO.Clear();
                    txtEmailID.Clear();


                    Get get = new Get();
                    dgvAllCustomerDetails.DataSource = null;
                    dgvAllCustomerDetails.DataSource = get.getAllCustomerDetails();


                    this.idToUpdate = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void dgvAllCustomerDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.idToUpdate = Convert.ToInt32(dgvAllCustomerDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCustomerName.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMobileNO.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtAddress2.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtFaxNumber.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtRemarks.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtEmailID.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCity.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtCustomerCOde.Text = dgvAllCustomerDetails.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
