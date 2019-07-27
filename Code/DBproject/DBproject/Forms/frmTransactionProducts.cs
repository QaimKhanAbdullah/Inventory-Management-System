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
    public partial class frmTransactionProducts : Form
    {



        DataTable gridData = new DataTable();
        DataTable dtProducts;


        public frmTransactionProducts(ref DataTable dt)
        {
            InitializeComponent();
            this.dtProducts = dt;
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


                        if (qty > Convert.ToDouble(txtSIH.Text))
                        {
                            MessageBox.Show("Quanttity Cannot be Greater Then Stock In Hand..");
                            txtQuantity.Clear();
                        }
                        else
                        {
                            txtAmount.Text = Convert.ToString(
                                            (
                                                Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text))
                                            );

                        }
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

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                txtSIH.Text = "" + get.getProductStockInHand(Convert.ToInt32(cmbProducts.SelectedValue));
                // get selling rate 
                txtRate.Text = "" + get.getSellingRatesOfProduct(Convert.ToInt32(cmbProducts.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void frmTransactionProducts_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                cmbProducts.DataSource = null;
                cmbProducts.DisplayMember = "Product_Name";
                cmbProducts.ValueMember = "Product_ID";                
                cmbProducts.DataSource = get.getAllProductNames().Tables[0];


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(txtAmount.Text) ||
                    string.IsNullOrEmpty(txtQuantity.Text) ||
                    string.IsNullOrEmpty(txtRate.Text)

                    )
                {
                    MessageBox.Show("Enter Compelete Inforation!");
                }
                else
                {
                    dgvFinalProducts.Rows.Add(
                        cmbProducts.Text,
                        txtRate.Text,
                        txtQuantity.Text,
                        txtAmount.Text
                    );

                    // clear
                    txtAmount.Clear();
                    txtQuantity.Clear();
                    txtRate.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                dtProducts.Rows.Clear();
                dtProducts.Columns.Clear();

                dtProducts.Columns.Add(new DataColumn("Item Names", typeof(string)));
                dtProducts.Columns.Add(new DataColumn("Rate", typeof(string)));
                dtProducts.Columns.Add(new DataColumn("Quantity", typeof(string)));
                dtProducts.Columns.Add(new DataColumn("Amount", typeof(string)));

                for (int k = 0; k < dgvFinalProducts.Rows.Count; k++)
                {
                    dtProducts.Rows.Add(
                            dgvFinalProducts.Rows[k].Cells[0].Value.ToString(),
                            dgvFinalProducts.Rows[k].Cells[1].Value.ToString(),
                            dgvFinalProducts.Rows[k].Cells[2].Value.ToString(),
                            dgvFinalProducts.Rows[k].Cells[3].Value.ToString()
                        );
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







    }
}
