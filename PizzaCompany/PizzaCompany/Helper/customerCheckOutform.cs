using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    public partial class customerCheckOutform : Form
    {
        private int userId;


        public customerCheckOutform()
        {
            InitializeComponent();
       
        }
        private void btnChechOut_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text.Trim();
            string confirmPassword = guna2TextBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }
            string qry = "SELECT userID FROM users WHERE username = @username AND passwd = @passwd";

            using (SqlCommand cmd = new SqlCommand(qry, MainClass.conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwd", password); 

                try
                {
                    if (MainClass.conn.State != ConnectionState.Open)
                        MainClass.conn.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        string updateQry = "UPDATE users SET uCheckOut = @checkOutTime, lastLogin = NULL WHERE userID = @userID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQry, MainClass.conn))
                        {
                            updateCmd.Parameters.AddWithValue("@checkOutTime", DateTime.Now);
                            updateCmd.Parameters.AddWithValue("@userID", userId);

                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Checkout successful.");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (MainClass.conn.State == ConnectionState.Open)
                        MainClass.conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
