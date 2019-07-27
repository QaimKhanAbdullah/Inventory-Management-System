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
    public partial class frmTransactions : Form
    {


        


        DataTable dtProducts = new DataTable();

        public frmTransactions()
        {
            InitializeComponent();
        }

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = DateTime.Now.Date.ToShortDateString();

                Get get = new Get();
                cmbCustomer.DataSource = null;
                cmbCustomer.DisplayMember = "Cust_Name";
                cmbCustomer.ValueMember = "Cust_ID";
                cmbCustomer.DataSource = get.getAllCustomerNames().Tables[0];

                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(cmbCustomer.Text))
                {
                    MessageBox.Show("Please Select Customer First !");
                }
                else
                {

                    if (dgvFinalProducts.RowCount > 0)
                    {
                        // ask for confirmation
                        if (DialogResult.Yes == MessageBox.Show("Do You Really Want To Add New Products\nWarning: Products Already added will be lost", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {


                            double billAmount = 0.0;

                            frmTransactionProducts frm = new frmTransactionProducts(ref dtProducts);
                            frm.ShowDialog();
                            dgvFinalProducts.DataSource = null;
                            dgvFinalProducts.DataSource = dtProducts;


                            for (int i = 0; i < dgvFinalProducts.RowCount; i++)
                            {
                                billAmount += Convert.ToDouble(dgvFinalProducts.Rows[i].Cells[3].Value);
                            }



                            txtBillAmount.Text = "" + billAmount;

                        }
                    }
                    else
                    {


                        double billAmount = 0.0;
                        frmTransactionProducts frm = new frmTransactionProducts(ref dtProducts);
                        frm.ShowDialog();
                        dgvFinalProducts.DataSource = null;
                        dgvFinalProducts.DataSource = dtProducts;


                        for (int i = 0; i < dgvFinalProducts.RowCount; i++)
                        {
                            billAmount += Convert.ToDouble(dgvFinalProducts.Rows[i].Cells[3].Value);
                        }
                        txtBillAmount.Clear();
                        txtBillAmount.Text = "" + billAmount;



                    }
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

                if (dgvFinalProducts.RowCount < 1) 
                {
                    MessageBox.Show("Please Add Products Firts");
                    return;
                }


                AddUpdate add = new AddUpdate();
                add.addTransactionDetails(
                    Convert.ToInt32(cmbCustomer.SelectedValue),
                     DateTime.Now.Date,
                    Convert.ToDouble(txtBillAmount.Text)
                );



                for (int i = 0; i < dgvFinalProducts.RowCount ; i++)
			    {
                    add.addTransactionProductDetails(
                       Convert.ToDouble(dgvFinalProducts.Rows[i].Cells[2].Value),       //Quantity
                       Convert.ToDouble(dgvFinalProducts.Rows[i].Cells[3].Value) ,      //amount
                       dgvFinalProducts.Rows[i].Cells[0].Value.ToString() //item name
                    );			 
			    }


                
                //subtract stock
                for (int i = 0; i < dgvFinalProducts.RowCount; i++)
                {
                    AddUpdate update = new AddUpdate();
                    update.addUpdateStockDetails(
                            0,      // not being used
                            0,      // not being used
                            Convert.ToDouble(dgvFinalProducts.Rows[i].Cells[2].Value),       // minus this quantuty
                            0,      // not being used
                            0,      // not being used
                            dgvFinalProducts.Rows[i].Cells[0].Value.ToString(),//item name
                            0,
                            1  // UPDATE (MINUS STOCK)
                        );
                }



                dgvFinalProducts.DataSource = null;
                MessageBox.Show("Data Added");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        }
    }

