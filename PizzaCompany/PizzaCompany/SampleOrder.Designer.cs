namespace PizzaCompany
{
    partial class SampleOrder
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
            this.searchmenu = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // searchmenu
            // 
            this.searchmenu.BorderRadius = 3;
            this.searchmenu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchmenu.DefaultText = "";
            this.searchmenu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchmenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchmenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchmenu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchmenu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchmenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchmenu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchmenu.IconLeft = global::PizzaCompany.Properties.Resources.loupe;
            this.searchmenu.IconLeftSize = new System.Drawing.Size(25, 25);
            this.searchmenu.Location = new System.Drawing.Point(628, 28);
            this.searchmenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchmenu.Name = "searchmenu";
            this.searchmenu.PlaceholderText = "Search here...";
            this.searchmenu.SelectedText = "";
            this.searchmenu.Size = new System.Drawing.Size(433, 62);
            this.searchmenu.TabIndex = 0;
            // 
            // SampleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 676);
            this.Controls.Add(this.searchmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SampleOrder";
            this.Text = "SampleOrder";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox searchmenu;
    }
}