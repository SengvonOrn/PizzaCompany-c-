namespace PizzaCompany
{
    partial class SampleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleForm));
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.textTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(36, 157);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1263, 12);
            this.guna2Separator1.TabIndex = 8;
            // 
            // textTitle
            // 
            this.textTitle.AutoSize = true;
            this.textTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitle.Location = new System.Drawing.Point(31, 11);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(125, 25);
            this.textTitle.TabIndex = 6;
            this.textTitle.Text = "Add Products";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(798, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search";
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.BorderRadius = 3;
            this.textSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSearch.DefaultText = "";
            this.textSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textSearch.IconLeft = global::PizzaCompany.Properties.Resources.loupe;
            this.textSearch.IconLeftSize = new System.Drawing.Size(28, 28);
            this.textSearch.Location = new System.Drawing.Point(801, 68);
            this.textSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSearch.Name = "textSearch";
            this.textSearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.textSearch.PlaceholderText = "Search Item Here";
            this.textSearch.SelectedText = "";
            this.textSearch.Size = new System.Drawing.Size(498, 55);
            this.textSearch.TabIndex = 5;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.HoverState.ImageSize = new System.Drawing.Size(57, 57);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAdd.ImageRotate = 0F;
            this.btnAdd.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAdd.IndicateFocus = true;
            this.btnAdd.Location = new System.Drawing.Point(36, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(3);
            this.btnAdd.PressedState.ImageSize = new System.Drawing.Size(55, 55);
            this.btnAdd.Size = new System.Drawing.Size(58, 55);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseTransparentBackground = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // SampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 833);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SampleForm";
            this.Text = "SampleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox textSearch;
        public Guna.UI2.WinForms.Guna2ImageButton btnAdd;
        public System.Windows.Forms.Label textTitle;
    }
}