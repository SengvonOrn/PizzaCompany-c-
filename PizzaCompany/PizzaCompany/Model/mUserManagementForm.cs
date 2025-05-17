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
            string qry = "";
            string gender = umale.Checked ? "Male" : (ufemale.Checked ? "Female" : "");
            DateTime checkInDate = DateTime.Now;

            if (id == 0)
            {
                qry = @"INSERT INTO users(username, passwd, uPhone, uRole, Gender, uCheckIn) 
            VALUES(@username, @uPasswd, @uPhone, @uRole, @Gender, @uCheckIn)";
            }
            else
            {
                qry = @"UPDATE users 
            SET username = @username,
                passwd = @uPasswd,
                uPhone = @uPhone,
                uRole = @uRole,
                Gender = @Gender,
                uCheckIn = @uCheckIn
            WHERE userID = @UserID";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@UserID", id);
            ht.Add("@username", username.Text);
            ht.Add("@uPasswd", upasswd.Text);
            ht.Add("@uPhone", uphone.Text);
            ht.Add("@uRole", urole.Text);
            ht.Add("@Gender", gender);
            ht.Add("@uCheckIn", checkInDate);

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                username.Focus();
            }
        }

        private void mUserManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
