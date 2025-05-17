namespace PizzaCompany.Model
{
    partial class mProductForm
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
            this.btnBrows = new Guna.UI2.WinForms.Guna2Button();
            this.pImageSet = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pImageSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PizzaCompany.Properties.Resources.companyLogo;
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnBrows
            // 
            this.btnBrows.AutoRoundedCorners = true;
            this.btnBrows.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrows.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrows.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrows.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrows.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBrows.ForeColor = System.Drawing.Color.White;
            this.btnBrows.Location = new System.Drawing.Point(799, 358);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(180, 57);
            this.btnBrows.TabIndex = 2;
            this.btnBrows.Text = "Brows";
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // pImageSet
            // 
            this.pImageSet.BackColor = System.Drawing.Color.Turquoise;
            this.pImageSet.BorderRadius = 3;
            this.pImageSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pImageSet.Image = global::PizzaCompany.Properties.Resources.product_photo;
            this.pImageSet.ImageRotate = 0F;
            this.pImageSet.Location = new System.Drawing.Point(799, 162);
            this.pImageSet.Name = "pImageSet";
            this.pImageSet.Size = new System.Drawing.Size(180, 136);
            this.pImageSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pImageSet.TabIndex = 3;
            this.pImageSet.TabStop = false;
            // 
            // pCategory
            // 
            this.pCategory.BackColor = System.Drawing.Color.Transparent;
            this.pCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.pCategory.ItemHeight = 30;
            this.pCategory.Items.AddRange(new object[] {
            "Pizaa",
            "Appetzer",
            "Bite",
            "Ice"});
            this.pCategory.Location = new System.Drawing.Point(46, 291);
            this.pCategory.Name = "pCategory";
            this.pCategory.Size = new System.Drawing.Size(326, 36);
            this.pCategory.TabIndex = 4;
            // 
            // pName
            // 
            this.pName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pName.DefaultText = "";
            this.pName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pName.Location = new System.Drawing.Point(46, 162);
            this.pName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pName.Name = "pName";
            this.pName.PlaceholderText = "";
            this.pName.SelectedText = "";
            this.pName.Size = new System.Drawing.Size(326, 48);
            this.pName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Name";
            // 
            // pPrice
            // 
            this.pPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pPrice.DefaultText = "";
            this.pPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pPrice.Location = new System.Drawing.Point(398, 162);
            this.pPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pPrice.Name = "pPrice";
            this.pPrice.PlaceholderText = "";
            this.pPrice.SelectedText = "";
            this.pPrice.Size = new System.Drawing.Size(326, 48);
            this.pPrice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category";
            // 
            // mProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 604);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pPrice);
            this.Controls.Add(this.pName);
            this.Controls.Add(this.pCategory);
            this.Controls.Add(this.pImageSet);
            this.Controls.Add(this.btnBrows);
            this.Name = "mProductForm";
            this.Text = "mProductForm";
            this.Load += new System.EventHandler(this.mProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pImageSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnBrows;
        private Guna.UI2.WinForms.Guna2PictureBox pImageSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2ComboBox pCategory;
        public Guna.UI2.WinForms.Guna2TextBox pName;
        public Guna.UI2.WinForms.Guna2TextBox pPrice;
    }
}