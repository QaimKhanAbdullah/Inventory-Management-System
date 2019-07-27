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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Username and Password both required.");
                }
                else
                {
                    UserLogin usln = new UserLogin();
                    if (usln.checkLoginCredentials(txtUserName.Text, txtPassword.Text) == true)
                    {
                        frmMainPannel frmmain = new frmMainPannel();
                        this.Hide();
                        frmmain.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Id or Password");
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
