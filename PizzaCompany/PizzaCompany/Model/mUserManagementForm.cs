using System;
using System.Collections;
using System.Windows.Forms;
namespace PizzaCompany.Model
{
    public partial class mUserManagementForm : SampleAddForm
    {
        public mUserManagementForm()
        {
            InitializeComponent();
        }
        public override void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int id = 0;
        public DateTime DateTime = DateTime.Now;
        public string name = "";




        public override void btnSave_Click(object sender, EventArgs e)
        {
            string gender = umale.Checked ? "Male" : (ufemale.Checked ? "Female" : "");
            DateTime checkInDate = DateTime.Now;
            Hashtable ht = new Hashtable();
            ht.Add("@UserID", id);
            ht.Add("@username", username.Text);
            ht.Add("@uPasswd", upasswd.Text);
            ht.Add("@uPhone", uphone.Text);
            ht.Add("@uRole", urole.Text);
            ht.Add("@Gender", gender);
            ht.Add("@uCheckIn", checkInDate);
            if (upasswd.Text != upasswdConfirm.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return;
            }

            if (id == 0) // Insert
            {
                // Check if user already exists
                string checkQry = "SELECT COUNT(*) FROM users WHERE username = @username AND passwd = @uPasswd";
                object result = MainClass.Scalar(checkQry, ht);

                if (Convert.ToInt32(result) > 0)
                {
                    MessageBox.Show("User already exists with the same username and password!");
                    return;
                }

                string insertQry = @"INSERT INTO users(username, passwd, uPhone, uRole, Gender, uCheckIn) 
                                    VALUES(@username, @uPasswd, @uPhone, @uRole, @Gender, @uCheckIn)";
                if (MainClass.SQL(insertQry, ht) > 0)
                {
                    MessageBox.Show("Saved successfully");
                    id = 0;
                    username.Focus();
                }
                else
                {
                    MessageBox.Show("Insert failed.");
                }
            }
            else // Update
            {
                string updateQry = @"UPDATE users 
                             SET username = @username,
                                 passwd = @uPasswd,
                                 uPhone = @uPhone,
                                 uRole = @uRole,
                                 Gender = @Gender,
                                 uCheckIn = @uCheckIn
                             WHERE userID = @UserID";
                if (MainClass.SQL(updateQry, ht) > 0)
                {
                    MessageBox.Show("Updated successfully");
                    id = 0;
                    username.Focus();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
        }







        private void mUserManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
