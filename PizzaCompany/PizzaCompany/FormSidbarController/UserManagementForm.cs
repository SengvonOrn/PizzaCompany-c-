using PizzaCompany.Model;
using System;
using System.Collections;
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
        public void GetData()
        {
            string qry = "SELECT userID,  username, passwd, uPhone, uRole, Gender  FROM users where username Like '%"+textSearch.Text+"%'";
            ListBox Ib = new ListBox();
            Ib.Items.Add(dgvid);
            Ib.Items.Add(dgName);
            Ib.Items.Add(dgpass);
            Ib.Items.Add(dgvPhone);
            Ib.Items.Add(dgvRole);
            Ib.Items.Add(dgSex);
            MainClass.LoadingData(qry, guna2DataGridView1 ,Ib);

        }
        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            GetData();
        }
  
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
           
            // let create table first
            GetData();

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                 {
                  permission.ShowDialog();
                if (permission.popup == true)
                   {
                    mUserManagementForm mU = new mUserManagementForm();
                    mU.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    mU.username.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgName"].Value);
                    mU.upasswd.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgpass"].Value);
                    mU.upasswdConfirm.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgpass"].Value);
                    mU.uphone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                    mU.urole.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
                    mU.umale.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value);
                    string gender = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgSex"].Value);
                    if (gender == "Male")
                    {
                        mU.umale.Checked = true;
                    }
                    else if (gender == "Female")
                    {
                        mU.ufemale.Checked = true;
                    }
                    mU.ShowDialog();
                    GetData();
                }
            }
                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgdelet")
                {
                permission.ShowDialog();

                if (permission.popup == true)
                {
                        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                        string qry = "DELETE FROM users WHERE userID = @userID";
                        Hashtable ht = new Hashtable();
                        ht.Add("@userID", id);

                        MainClass.SQL(qry, ht);

                        MessageBox.Show("Deleted successfully");
                        GetData(); // Refresh the grid
                }


            }
        }
    }
}
