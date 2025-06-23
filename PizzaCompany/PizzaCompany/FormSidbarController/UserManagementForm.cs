using PizzaCompany.Model;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PizzaCompany.FormSidbarController
{
    public partial class UserManagementForm : SampleForm
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }
        PermissionForm permission = new PermissionForm();


        //==============================>

        public void GetData()
        {
            if (string.IsNullOrEmpty(MainClass.USER))
            {
                MessageBox.Show("Please log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2DataGridView1.DataSource = null;
                return;
            }


         // Show only user that login

            string qry = "SELECT userID, username, passwd, uPhone, uRole, Gender FROM users " +
                         "WHERE lastLogin IS NOT NULL AND username LIKE '%" + textSearch.Text.Trim() + "%'";

            ListBox Ib = new ListBox();
            Ib.Items.Add(dgvid);
            Ib.Items.Add(dgName);
            Ib.Items.Add(dgpass);
            Ib.Items.Add(dgvPhone);
            Ib.Items.Add(dgvRole);
            Ib.Items.Add(dgSex);

            MainClass.LoadingData(qry, guna2DataGridView1, Ib);



        }

        //========Loading User Data================>

        private void UserManagementForm_Load(object sender, EventArgs e)
        {



            if (!string.IsNullOrEmpty(MainClass.USER))
            {
                GetData();
            }
            else
            {
                MessageBox.Show("You must login first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2DataGridView1.DataSource = null;
            }
        }
        //=========btnShowAddUser================>
  
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
          


            permission.ShowDialog();

            if (permission.popup == true)
            {
                MainClass.BlurBackround(new mUserManagementForm());
            }



        }


        public override void textSearch_TextChanged(object sender, EventArgs e)
        {
           
            GetData();

        }


        //==============DataGridViews===========>
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validate row and column index
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Get clicked column name safely
            string columnName = guna2DataGridView1.Columns[e.ColumnIndex].Name;

            // Get the clicked row
            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

            if (row == null)
                return;

            // Check nulls in cells for important columns
            if (row.Cells["dgvid"].Value == null || row.Cells["dgName"].Value == null)
                return;

            //================ User CheckOut =================>




            if (columnName == "checkOut")
            {
                int userId = Convert.ToInt32(row.Cells["dgvid"].Value);
                string username = Convert.ToString(row.Cells["dgName"].Value);

                DialogResult result = MessageBox.Show($"Are you sure {username} wants to check out?", "Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string qry = "UPDATE users SET uCheckOut = @checkOutTime, lastLogin = NULL WHERE userID = @userID";
                    using (SqlCommand cmd = new SqlCommand(qry, MainClass.conn))
                    {
                        cmd.Parameters.AddWithValue("@checkOutTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@userID", userId);

                        try
                        {
                            if (MainClass.conn.State != ConnectionState.Open)
                                MainClass.conn.Open();

                            cmd.ExecuteNonQuery();

                            MessageBox.Show($"{username} checked out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error checking out: " + ex.Message);
                        }
                        finally
                        {
                            if (MainClass.conn.State == ConnectionState.Open)
                                MainClass.conn.Close();
                        }
                    }
                }
                return; 
            }




            //================ User Edit =====================>





            if (columnName == "dgvedit")
            {
                permission.ShowDialog();
                if (permission.popup == true)
                {
                    mUserManagementForm mU = new mUserManagementForm();

                    mU.id = Convert.ToInt32(row.Cells["dgvid"].Value);
                    mU.username.Text = Convert.ToString(row.Cells["dgName"].Value);
                    mU.upasswd.Text = Convert.ToString(row.Cells["dgpass"].Value);
                    mU.upasswdConfirm.Text = Convert.ToString(row.Cells["dgpass"].Value);
                    mU.uphone.Text = Convert.ToString(row.Cells["dgvPhone"].Value);
                    mU.urole.Text = Convert.ToString(row.Cells["dgvRole"].Value);

                    string gender = Convert.ToString(row.Cells["dgSex"].Value);
                    mU.umale.Checked = false;
                    mU.ufemale.Checked = false;
                    if (gender == "Male")
                        mU.umale.Checked = true;
                    else if (gender == "Female")
                        mU.ufemale.Checked = true;

                    mU.ShowDialog();
                    GetData();
                }
                return; 
            }
            
            //================ User Delete ===================>

            if (columnName == "dgdelet")
            {
                permission.ShowDialog();
                if (permission.popup == true)
                {
                    int id = Convert.ToInt32(row.Cells["dgvid"].Value);

                    string qry = "DELETE FROM users WHERE userID = @userID";
                    Hashtable ht = new Hashtable();
                    ht.Add("@userID", id);

                    MainClass.SQL(qry, ht);

                    MessageBox.Show("Deleted successfully");
                    GetData();
                }
                return; // exit after delete
            }
        }

    }
}
