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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                        string.IsNullOrEmpty(txtQuantity.Text) || 
                        string.IsNullOrEmpty(txtRate.Text) || 
                        string.IsNullOrEmpty(txtAmount.Text)  
                    ) 
                {

                    MessageBox.Show("Enter Complete Information");
                }
                else
                {
                    AddUpdate addUpdate = new AddUpdate();
                    addUpdate.addUpdateStockDetails(
                            Convert.ToDouble(txtAmount.Text), 
                            Convert.ToDouble(txtRate.Text ), 
                            Convert.ToDouble(txtQuantity.Text), 
                            Convert.ToInt32(cmbItemName.SelectedValue),
                            Convert.ToInt32(cmbUnit.SelectedValue) ,
                            "", //not being used
                            0 , 
                            0  // ADD
                        );



                    MessageBox.Show("Stock Added");
                    txtAmount.Clear(); 
                    txtRate.Clear(); 
                    txtQuantity.Clear();

                    Get get = new Get();
                    dgvAllStockDetails.DataSource = null;
                    dgvAllStockDetails.DataSource = get.getAllStockDetails();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmStock_Load(object sender, EventArgs e)
        {

            try
            {
                Get get = new Get();
                cmbItemName.DataSource = null;
                cmbItemName.DisplayMember = "Product_Name";
                cmbItemName.ValueMember = "Product_ID";                // not being used 
                cmbItemName.DataSource = get.getAllProductNames().Tables[0];


                cmbUnit.DataSource = null;
                cmbUnit.DisplayMember = "UnitMeasure_Name";
                cmbUnit.ValueMember = "UnitMeasure_ID";
                cmbUnit.DataSource = get.getAllUnitmeasures().Tables[0];

                dgvAllStockDetails.DataSource = null;
                dgvAllStockDetails.DataSource = get.getAllStockDetails();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    return;
                }


                double unitPrice;
                if (!double.TryParse(txtRate.Text, out unitPrice))
                {
                    txtRate.Clear();
                    MessageBox.Show("Please Enter A Number In Rate");
                    return;
                }

                if (string.IsNullOrEmpty(txtRate.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    txtAmount.Clear();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        double quantity;
                        if (!double.TryParse(txtQuantity.Text, out quantity))
                        {
                            txtQuantity.Clear();
                            MessageBox.Show("Please Enter A Number In Quantity");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    txtAmount.Clear();
                    return;
                }


                if (string.IsNullOrEmpty(txtRate.Text))
                {
                    MessageBox.Show("Please Enter The Rate Frist...");
                    txtQuantity.Clear();
                    return;
                }


                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    txtAmount.Clear();
                }
                else
                {

                    double qty;
                    if (double.TryParse(txtQuantity.Text, out qty))
                    {
                        txtAmount.Text = Convert.ToString(
                                        (
                                            Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text))
                                        );
                    }
                    else
                    {
                        MessageBox.Show("Please Enter A Number In Quantity");
                        txtQuantity.Clear();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
