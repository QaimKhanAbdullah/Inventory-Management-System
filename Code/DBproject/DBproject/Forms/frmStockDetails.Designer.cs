namespace DBproject
{
    partial class frmStockDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockDetails));
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAllStockDetails = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStockDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 194;
            this.label6.Text = "All Stock Details";
            // 
            // dgvAllStockDetails
            // 
            this.dgvAllStockDetails.AllowUserToAddRows = false;
            this.dgvAllStockDetails.AllowUserToDeleteRows = false;
            this.dgvAllStockDetails.AllowUserToOrderColumns = true;
            this.dgvAllStockDetails.AllowUserToResizeColumns = false;
            this.dgvAllStockDetails.AllowUserToResizeRows = false;
            this.dgvAllStockDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllStockDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllStockDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAllStockDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllStockDetails.Location = new System.Drawing.Point(12, 23);
            this.dgvAllStockDetails.Name = "dgvAllStockDetails";
            this.dgvAllStockDetails.ReadOnly = true;
            this.dgvAllStockDetails.Size = new System.Drawing.Size(676, 374);
            this.dgvAllStockDetails.TabIndex = 193;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(50, 410);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(119, 25);
            this.label24.TabIndex = 195;
            this.label24.Text = "Stock Details";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
            this.pictureBox14.Location = new System.Drawing.Point(12, 403);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(42, 41);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox14.TabIndex = 196;
            this.pictureBox14.TabStop = false;
            // 
            // frmStockDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 461);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvAllStockDetails);
            this.Name = "frmStockDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management - Stock Details";
            this.Load += new System.EventHandler(this.frmStockDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStockDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAllStockDetails;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox14;
    }
}