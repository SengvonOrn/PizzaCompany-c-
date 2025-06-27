namespace PizzaCompany.FormMenuController
{
    partial class PizzaForm
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
            this.selectOptions = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnDeluxpizza = new Guna.UI2.WinForms.Guna2Button();
            this.btnClassicpizza = new Guna.UI2.WinForms.Guna2Button();
            this.btnSeafood = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 83);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1311, 741);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // searchMenu
            // 
            this.searchMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.searchMenu.Location = new System.Drawing.Point(860, 15);
            this.searchMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.PlaceholderText = "Search here";
            this.searchMenu.SelectedText = "";
            this.searchMenu.Size = new System.Drawing.Size(378, 56);
            this.searchMenu.TabIndex = 2;
            this.searchMenu.TextChanged += new System.EventHandler(this.searchMenu_TextChanged);
            // 
            // selectOptions
            // 
            this.selectOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectOptions.BackColor = System.Drawing.Color.Transparent;
            this.selectOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectOptions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.selectOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectOptions.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.selectOptions.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.selectOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.selectOptions.ItemHeight = 30;
            this.selectOptions.Items.AddRange(new object[] {
            "Selected",
            "6",
            "9",
            "12"});
            this.selectOptions.Location = new System.Drawing.Point(695, 14);
            this.selectOptions.Name = "selectOptions";
            this.selectOptions.Size = new System.Drawing.Size(135, 36);
            this.selectOptions.StartIndex = 0;
            this.selectOptions.TabIndex = 3;
            this.selectOptions.SelectedIndexChanged += new System.EventHandler(this.selectOptions_SelectedIndexChanged);
            // 
            // btnDeluxpizza
            // 
            this.btnDeluxpizza.BorderColor = System.Drawing.Color.Transparent;
            this.btnDeluxpizza.BorderRadius = 2;
            this.btnDeluxpizza.BorderThickness = 1;
            this.btnDeluxpizza.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDeluxpizza.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnDeluxpizza.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnDeluxpizza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeluxpizza.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeluxpizza.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeluxpizza.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeluxpizza.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeluxpizza.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnDeluxpizza.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeluxpizza.ForeColor = System.Drawing.Color.White;
            this.btnDeluxpizza.Location = new System.Drawing.Point(322, 16);
            this.btnDeluxpizza.Name = "btnDeluxpizza";
            this.btnDeluxpizza.Size = new System.Drawing.Size(138, 56);
            this.btnDeluxpizza.TabIndex = 4;
            this.btnDeluxpizza.Text = "Deluxe pizza";
            this.btnDeluxpizza.Click += new System.EventHandler(this.btnDeluxpizza_Click);
            // 
            // btnClassicpizza
            // 
            this.btnClassicpizza.BorderColor = System.Drawing.Color.Transparent;
            this.btnClassicpizza.BorderRadius = 2;
            this.btnClassicpizza.BorderThickness = 1;
            this.btnClassicpizza.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnClassicpizza.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnClassicpizza.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnClassicpizza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClassicpizza.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClassicpizza.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClassicpizza.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClassicpizza.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClassicpizza.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnClassicpizza.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassicpizza.ForeColor = System.Drawing.Color.White;
            this.btnClassicpizza.Location = new System.Drawing.Point(169, 15);
            this.btnClassicpizza.Name = "btnClassicpizza";
            this.btnClassicpizza.Size = new System.Drawing.Size(137, 56);
            this.btnClassicpizza.TabIndex = 5;
            this.btnClassicpizza.Text = "Classic pizza";
            this.btnClassicpizza.Click += new System.EventHandler(this.btnClassicpizza_Click);
            // 
            // btnSeafood
            // 
            this.btnSeafood.BorderColor = System.Drawing.Color.Transparent;
            this.btnSeafood.BorderRadius = 2;
            this.btnSeafood.BorderThickness = 1;
            this.btnSeafood.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSeafood.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSeafood.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnSeafood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeafood.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeafood.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeafood.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeafood.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeafood.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnSeafood.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeafood.ForeColor = System.Drawing.Color.White;
            this.btnSeafood.Location = new System.Drawing.Point(477, 16);
            this.btnSeafood.Name = "btnSeafood";
            this.btnSeafood.Size = new System.Drawing.Size(151, 56);
            this.btnSeafood.TabIndex = 4;
            this.btnSeafood.Text = "Seafood Deluxe";
            this.btnSeafood.Click += new System.EventHandler(this.btnSeafood_Click);
            // 
            // btnAll
            // 
            this.btnAll.BorderColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderRadius = 2;
            this.btnAll.BorderThickness = 1;
            this.btnAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnAll.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnAll.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(31)))), ((int)(((byte)(242)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(16, 15);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(137, 56);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // PizzaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 823);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.selectOptions);
            this.Controls.Add(this.btnClassicpizza);
            this.Controls.Add(this.btnSeafood);
            this.Controls.Add(this.btnDeluxpizza);
            this.Controls.Add(this.searchMenu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PizzaForm";
            this.Text = "PizzaForm";
            this.Load += new System.EventHandler(this.PizzaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox searchMenu;
        private Guna.UI2.WinForms.Guna2ComboBox selectOptions;
        private Guna.UI2.WinForms.Guna2Button btnDeluxpizza;
        private Guna.UI2.WinForms.Guna2Button btnClassicpizza;
        private Guna.UI2.WinForms.Guna2Button btnSeafood;
        private Guna.UI2.WinForms.Guna2Button btnAll;
    }
}