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
    }
}
