namespace PizzaCompany.FormMenuController
{
    partial class BeverageForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchMenu = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDrink = new Guna.UI2.WinForms.Guna2Button();
            this.btnAlcohol = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 84);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1116, 638);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // searchMenu
            // 
            this.searchMenu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchMenu.DefaultText = "";
            this.searchMenu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchMenu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchMenu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchMenu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchMenu.IconLeft = global::PizzaCompany.Properties.Resources.search;
            this.searchMenu.IconLeftSize = new System.Drawing.Size(30, 30);
            this.searchMenu.Location = new System.Drawing.Point(718, 13);
            this.searchMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.PlaceholderText = "";
            this.searchMenu.SelectedText = "";
            this.searchMenu.Size = new System.Drawing.Size(388, 56);
            this.searchMenu.TabIndex = 2;
            this.searchMenu.TextChanged += new System.EventHandler(this.searchMenu_TextChanged_1);
            // 
            // btnDrink
            // 
            this.btnDrink.BorderColor = System.Drawing.Color.Transparent;
            this.btnDrink.BorderRadius = 2;
            this.btnDrink.BorderThickness = 1;
            this.btnDrink.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDrink.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnDrink.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnDrink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDrink.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDrink.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDrink.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDrink.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDrink.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnDrink.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrink.ForeColor = System.Drawing.Color.White;
            this.btnDrink.Location = new System.Drawing.Point(335, 12);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Size = new System.Drawing.Size(166, 56);
            this.btnDrink.TabIndex = 3;
            this.btnDrink.Text = "Soft drink && water";
            this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
            // 
            // btnAlcohol
            // 
            this.btnAlcohol.BorderColor = System.Drawing.Color.Transparent;
            this.btnAlcohol.BorderRadius = 2;
            this.btnAlcohol.BorderThickness = 1;
            this.btnAlcohol.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAlcohol.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAlcohol.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnAlcohol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlcohol.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAlcohol.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAlcohol.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAlcohol.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAlcohol.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnAlcohol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlcohol.ForeColor = System.Drawing.Color.White;
            this.btnAlcohol.Location = new System.Drawing.Point(143, 11);
            this.btnAlcohol.Name = "btnAlcohol";
            this.btnAlcohol.Size = new System.Drawing.Size(166, 57);
            this.btnAlcohol.TabIndex = 3;
            this.btnAlcohol.Text = "Alcohol";
            this.btnAlcohol.Click += new System.EventHandler(this.btnAlcohol_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 2;
            this.guna2Button3.BorderThickness = 1;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button3.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.guna2Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(16, 11);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(101, 56);
            this.guna2Button3.TabIndex = 3;
            this.guna2Button3.Text = "All";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // BeverageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 723);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.btnAlcohol);
            this.Controls.Add(this.btnDrink);
            this.Controls.Add(this.searchMenu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeverageForm";
            this.Text = "BeverageForm";
            this.Load += new System.EventHandler(this.BeverageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox searchMenu;
        private Guna.UI2.WinForms.Guna2Button btnDrink;
        private Guna.UI2.WinForms.Guna2Button btnAlcohol;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}