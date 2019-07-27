namespace DBproject
{
    partial class frmTransactionProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionProducts));
            this.dgvFinalProducts = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSIH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFinalProducts
            // 
            this.dgvFinalProducts.AllowUserToAddRows = false;
            this.dgvFinalProducts.AllowUserToDeleteRows = false;
            this.dgvFinalProducts.AllowUserToOrderColumns = true;
            this.dgvFinalProducts.AllowUserToResizeColumns = false;
            this.dgvFinalProducts.AllowUserToResizeRows = false;
            this.dgvFinalProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinalProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvFinalProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFinalProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Column1,
            this.Column2,
            this.Amount});
            this.dgvFinalProducts.Location = new System.Drawing.Point(12, 120);
            this.dgvFinalProducts.Name = "dgvFinalProducts";
            this.dgvFinalProducts.ReadOnly = true;
            this.dgvFinalProducts.Size = new System.Drawing.Size(682, 211);
            this.dgvFinalProducts.TabIndex = 190;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item Name";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Rate";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.AutoSize = true;
            this.Customer.Location = new System.Drawing.Point(12, 15);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(61, 13);
            this.Customer.TabIndex = 192;
            this.Customer.Text = "Item Name ";
            // 
            // cmbProducts
            // 
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(97, 12);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(209, 21);
            this.cmbProducts.TabIndex = 191;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 196;
            this.label4.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(402, 41);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(209, 20);
            this.txtAmount.TabIndex = 195;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 194;
            this.label3.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(402, 15);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(209, 20);
            this.txtQuantity.TabIndex = 193;
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 200;
            this.label2.Text = "Stock In Hand";
            // 
            // txtSIH
            // 
            this.txtSIH.Enabled = false;
            this.txtSIH.Location = new System.Drawing.Point(97, 41);
            this.txtSIH.Name = "txtSIH";
            this.txtSIH.Size = new System.Drawing.Size(209, 20);
            this.txtSIH.TabIndex = 199;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Enabled = false;
            this.txtRate.Location = new System.Drawing.Point(97, 67);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(209, 20);
            this.txtRate.TabIndex = 201;
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(586, 86);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(108, 28);
            this.btnAddToList.TabIndex = 203;
            this.btnAddToList.Text = "ADD To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(586, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 28);
            this.btnSave.TabIndex = 204;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(42, 342);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(189, 25);
            this.label24.TabIndex = 205;
            this.label24.Text = "Transaction Products";
            // 
            // pictureBox22
            // 
            this.pictureBox22.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox22.Image")));
            this.pictureBox22.Location = new System.Drawing.Point(5, 332);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(42, 44);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox22.TabIndex = 206;
            this.pictureBox22.TabStop = false;
            // 
            // frmTransactionProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 388);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSIH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.Customer);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.dgvFinalProducts);
            this.Name = "frmTransactionProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management - Transaction Products";
            this.Load += new System.EventHandler(this.frmTransactionProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFinalProducts;
        private System.Windows.Forms.Label Customer;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSIH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox22;
    }
}