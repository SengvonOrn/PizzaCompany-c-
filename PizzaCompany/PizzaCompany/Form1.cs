using System;
using System.Windows.Forms;

namespace PizzaCompany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Validate user credentials
            if (!MainClass.isValidatUser(username.Text, passwd.Text))
            {
                MessageBox.Show("User not logged in.");
                return;
            }

            // Check if password and confirm password match
            if (passwd.Text == confirm.Text)
            {
                this.Hide();
                DashbordForm form = new DashbordForm();
                form.Show();
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizeBox_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }
    }
}
