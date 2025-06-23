using PizzaCompany.Model;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PizzaCompany.FormSidbarController
{
    public partial class ProductManagement : SampleForm
    {
        public ProductManagement()
        {
            InitializeComponent();
        }
        PermissionForm permission = new PermissionForm();
        public void GetData()
        {
            string qry = "SELECT * FROM productManagement WHERE pName LIKE '%" + textSearch.Text +"%' ";
            ListBox Ib = new ListBox();
            Ib.Items.Add(dgvid);
            Ib.Items.Add(dgName);
            Ib.Items.Add(dgCate);
            Ib.Items.Add(dgPrice);
            Ib.Items.Add(pSize);
            Ib.Items.Add(pgroup);
            Ib.Items.Add(dgImg);
            Ib.Items.Add(cmd);
            MainClass.LoadingData(qry, guna2DataGridView1, Ib);

        }





        private void ProductManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }



        private mProductForm _mProductForm = null; 




        private  void btnAdd_Click_1(object sender, EventArgs e)
        {

            permission.ShowDialog();

            if (permission.popup == true)
            {
                MainClass.BlurBackround(new  mProductForm());
            }

        }


        public override void textSearch_TextChanged(object sender, EventArgs e)
        {
            // let create table first
            GetData();
        }

        //=========================================>

        // select event on table for update deleted
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if (guna2DataGridView1.CurrentCell == null || guna2DataGridView1.CurrentRow == null)
                return;

            string columnName = guna2DataGridView1.CurrentCell.OwningColumn.Name;

            if (columnName == "dgvedit")
            {
                permission.ShowDialog();

                if (permission.popup == true)
                {

                mProductForm mfr = new mProductForm();


                mfr.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);               
                mfr.pName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgName"].Value);
                mfr.pCategory.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgCate"].Value);
                mfr.pPrice.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgPrice"].Value);
                mfr.pSize.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["pSize"].Value);
                mfr.pGroup.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["pgroup"].Value);
                mfr.cmd.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cmd"].Value);



                    //=====image=====>

                    object imgData = guna2DataGridView1.CurrentRow.Cells["dgImg"].Value;

                    if (imgData != DBNull.Value && imgData != null)
                    {
                        byte[] imageBytes = (byte[])imgData;
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            mfr.pImageSet.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        mfr.pImageSet.Image = Properties.Resources.edit; 
                    }

                    //======image====>

                   mfr.ShowDialog();
                   GetData();


                }
                
             }


            else if  (columnName == "dgdelet")
            {

                permission.ShowDialog();

                if (permission.popup == true)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                    string qry = "DELETE FROM productManagement WHERE pId = @pId";

                    Hashtable ht = new Hashtable();
                    ht.Add("@pId", id);

                    MainClass.SQL(qry, ht);

                    MessageBox.Show("Deleted successfully");
                    GetData();
               }
            }


        }
    }
}
