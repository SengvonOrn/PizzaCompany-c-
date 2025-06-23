using PizzaCompany.Helper;
using System;
using System.Windows.Forms;
using static PizzaCompany.Helper.SessionClass;

namespace PizzaCompany
{
    public partial class PermissionForm : Form
    {
        public PermissionForm()
        {
            InitializeComponent();
        }
        public bool popup = false;

       



        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (passwd.Text != confirmpass.Text)
            {
              
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (!MainClass.userPermission("Manager", passwd.Text.Trim()))
            {
                MessageBox.Show("User not authorized. Please try again.");
                return;
            }



            popup = true;
            this.Hide();
            passwd.Text = "";
            confirmpass.Text = "";



        }





        private void btnCancel_Click(object sender, EventArgs e)
        {
            popup = false;
            this.Hide();
            passwd.Text = "";
            confirmpass.Text = "";

        }
    

    }
}
