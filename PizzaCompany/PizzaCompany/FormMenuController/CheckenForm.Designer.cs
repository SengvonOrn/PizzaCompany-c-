﻿namespace PizzaCompany.FormMenuController
{
    partial class CheckenForm
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
            this.searchMenu = new Guna.UI2.WinForms.Guna2TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectOptions = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
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
            this.searchMenu.Location = new System.Drawing.Point(860, 13);
            this.searchMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchMenu.Name = "searchMenu";
            this.searchMenu.PlaceholderText = "";
            this.searchMenu.SelectedText = "";
            this.searchMenu.Size = new System.Drawing.Size(381, 56);
            this.searchMenu.TabIndex = 5;
            this.searchMenu.TextChanged += new System.EventHandler(this.searchMenu_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 84);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1322, 741);
            this.flowLayoutPanel1.TabIndex = 6;
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
            this.selectOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.selectOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.selectOptions.ItemHeight = 30;
            this.selectOptions.Items.AddRange(new object[] {
            "Selected",
            "6",
            "10"});
            this.selectOptions.Location = new System.Drawing.Point(697, 13);
            this.selectOptions.Name = "selectOptions";
            this.selectOptions.Size = new System.Drawing.Size(139, 36);
            this.selectOptions.StartIndex = 0;
            this.selectOptions.TabIndex = 7;
            this.selectOptions.SelectedIndexChanged += new System.EventHandler(this.selectOptions_SelectedIndexChanged);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnAll.Location = new System.Drawing.Point(562, 13);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(108, 56);
            this.btnAll.TabIndex = 8;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // CheckenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 823);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.selectOptions);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.searchMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckenForm";
            this.Text = "CheckenForm";
            this.Load += new System.EventHandler(this.CheckenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox searchMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox selectOptions;
        private Guna.UI2.WinForms.Guna2Button btnAll;
    }
}