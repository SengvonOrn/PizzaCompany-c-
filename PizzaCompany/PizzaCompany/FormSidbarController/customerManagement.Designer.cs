namespace PizzaCompany.FormSidbarController
{
    partial class customerManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Sr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extention = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSuite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccrost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpostcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinstore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.print = new System.Windows.Forms.DataGridViewImageColumn();
            this.edited = new System.Windows.Forms.DataGridViewImageColumn();
            this.deleted = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.HoverState.ImageSize = new System.Drawing.Size(57, 57);
            this.btnAdd.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            this.btnAdd.PressedState.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // textTitle
            // 
            this.textTitle.Size = new System.Drawing.Size(132, 25);
            this.textTitle.Text = "Add Customer";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 50;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sr,
            this.cId,
            this.oId,
            this.cphone,
            this.cname,
            this.extention,
            this.caddress,
            this.cSuite,
            this.ccrost,
            this.ccr,
            this.ct,
            this.cpostcode,
            this.cdelivery,
            this.cinstore,
            this.payment,
            this.print,
            this.edited,
            this.deleted});
            this.guna2DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(36, 203);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1267, 628);
            this.guna2DataGridView1.TabIndex = 9;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 50;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // Sr
            // 
            this.Sr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Sr.FillWeight = 109.5979F;
            this.Sr.HeaderText = "Sr#";
            this.Sr.MinimumWidth = 6;
            this.Sr.Name = "Sr";
            this.Sr.ReadOnly = true;
            this.Sr.Width = 30;
            // 
            // cId
            // 
            this.cId.FillWeight = 109.5979F;
            this.cId.HeaderText = "cId";
            this.cId.MinimumWidth = 6;
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            // 
            // oId
            // 
            this.oId.HeaderText = "OId";
            this.oId.MinimumWidth = 6;
            this.oId.Name = "oId";
            this.oId.ReadOnly = true;
            this.oId.Visible = false;
            // 
            // cphone
            // 
            this.cphone.FillWeight = 109.5979F;
            this.cphone.HeaderText = "Phone";
            this.cphone.MinimumWidth = 6;
            this.cphone.Name = "cphone";
            this.cphone.ReadOnly = true;
            // 
            // cname
            // 
            this.cname.FillWeight = 109.5979F;
            this.cname.HeaderText = "Name";
            this.cname.MinimumWidth = 6;
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            // 
            // extention
            // 
            this.extention.FillWeight = 109.5979F;
            this.extention.HeaderText = "Extention";
            this.extention.MinimumWidth = 6;
            this.extention.Name = "extention";
            this.extention.ReadOnly = true;
            // 
            // caddress
            // 
            this.caddress.FillWeight = 109.5979F;
            this.caddress.HeaderText = "Address";
            this.caddress.MinimumWidth = 6;
            this.caddress.Name = "caddress";
            this.caddress.ReadOnly = true;
            // 
            // cSuite
            // 
            this.cSuite.FillWeight = 109.5979F;
            this.cSuite.HeaderText = "Suite";
            this.cSuite.MinimumWidth = 6;
            this.cSuite.Name = "cSuite";
            this.cSuite.ReadOnly = true;
            // 
            // ccrost
            // 
            this.ccrost.FillWeight = 109.5979F;
            this.ccrost.HeaderText = "Crost";
            this.ccrost.MinimumWidth = 6;
            this.ccrost.Name = "ccrost";
            this.ccrost.ReadOnly = true;
            // 
            // ccr
            // 
            this.ccr.FillWeight = 109.5979F;
            this.ccr.HeaderText = "City";
            this.ccr.MinimumWidth = 6;
            this.ccr.Name = "ccr";
            this.ccr.ReadOnly = true;
            // 
            // ct
            // 
            this.ct.FillWeight = 109.5979F;
            this.ct.HeaderText = "Region";
            this.ct.MinimumWidth = 6;
            this.ct.Name = "ct";
            this.ct.ReadOnly = true;
            // 
            // cpostcode
            // 
            this.cpostcode.FillWeight = 109.5979F;
            this.cpostcode.HeaderText = "PostCode";
            this.cpostcode.MinimumWidth = 6;
            this.cpostcode.Name = "cpostcode";
            this.cpostcode.ReadOnly = true;
            // 
            // cdelivery
            // 
            this.cdelivery.FillWeight = 109.5979F;
            this.cdelivery.HeaderText = "Delivery";
            this.cdelivery.MinimumWidth = 6;
            this.cdelivery.Name = "cdelivery";
            this.cdelivery.ReadOnly = true;
            // 
            // cinstore
            // 
            this.cinstore.FillWeight = 109.5979F;
            this.cinstore.HeaderText = "command";
            this.cinstore.MinimumWidth = 6;
            this.cinstore.Name = "cinstore";
            this.cinstore.ReadOnly = true;
            // 
            // payment
            // 
            this.payment.FillWeight = 109.5979F;
            this.payment.HeaderText = "Payment";
            this.payment.MinimumWidth = 6;
            this.payment.Name = "payment";
            this.payment.ReadOnly = true;
            this.payment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // print
            // 
            this.print.FillWeight = 54.54546F;
            this.print.HeaderText = "Print";
            this.print.Image = global::PizzaCompany.Properties.Resources.printer;
            this.print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.print.MinimumWidth = 6;
            this.print.Name = "print";
            this.print.ReadOnly = true;
            this.print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // edited
            // 
            this.edited.FillWeight = 56.42316F;
            this.edited.HeaderText = "Edited";
            this.edited.Image = global::PizzaCompany.Properties.Resources.edit;
            this.edited.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.edited.MinimumWidth = 6;
            this.edited.Name = "edited";
            this.edited.ReadOnly = true;
            // 
            // deleted
            // 
            this.deleted.FillWeight = 54.66045F;
            this.deleted.HeaderText = "Deleted";
            this.deleted.Image = global::PizzaCompany.Properties.Resources.trash;
            this.deleted.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.deleted.MinimumWidth = 6;
            this.deleted.Name = "deleted";
            this.deleted.ReadOnly = true;
            // 
            // customerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 833);
            this.Controls.Add(this.guna2DataGridView1);
            this.Name = "customerManagement";
            this.Text = "customerManagement";
            this.Load += new System.EventHandler(this.customerManagement_Load);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.textTitle, 0);
            this.Controls.SetChildIndex(this.guna2DataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cId;
        private System.Windows.Forms.DataGridViewTextBoxColumn oId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn extention;
        private System.Windows.Forms.DataGridViewTextBoxColumn caddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSuite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccrost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ct;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpostcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn cinstore;
        private System.Windows.Forms.DataGridViewButtonColumn payment;
        private System.Windows.Forms.DataGridViewImageColumn print;
        private System.Windows.Forms.DataGridViewImageColumn edited;
        private System.Windows.Forms.DataGridViewImageColumn deleted;
    }
}