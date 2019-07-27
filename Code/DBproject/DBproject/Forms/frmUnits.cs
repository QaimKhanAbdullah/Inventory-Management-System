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
    public partial class frmUnits : Form
    {
        private int idToUpdate = 0;
        
        public frmUnits()
        {
            InitializeComponent();
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            try
            {
                Get get = new Get();
                dgvUnitMeasures.DataSource = null;
                dgvUnitMeasures.DataSource = get.getAllUnitMeasureDetails();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddUpdate add = new AddUpdate();
                add.addUpdateUnitMeasure(
                    txtUnitMeasure.Text,
                    0, 
                    0
                );      // ADD

                txtUnitMeasure.Clear();
                this.idToUpdate = 0;
                MessageBox.Show("DATA ADDED");

                Get get = new Get();
                dgvUnitMeasures.DataSource = null;
                dgvUnitMeasures.DataSource = get.getAllUnitMeasureDetails();



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
                AddUpdate update = new AddUpdate();
                update.addUpdateUnitMeasure(
                    txtUnitMeasure.Text, 
                    this.idToUpdate, 
                    1
                );  // UPDATE

                txtUnitMeasure.Clear();
                MessageBox.Show("DATA UDPATED");
                this.idToUpdate = 0;

                Get get = new Get();
                dgvUnitMeasures.DataSource = null;
                dgvUnitMeasures.DataSource = get.getAllUnitMeasureDetails();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUnitMeasures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.idToUpdate = Convert.ToInt32(dgvUnitMeasures.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtUnitMeasure.Text = dgvUnitMeasures.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






    }
}
