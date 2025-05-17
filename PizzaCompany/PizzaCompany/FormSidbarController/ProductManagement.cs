using PizzaCompany.Model;
using System;
using System.Collections;
using System.Windows.Forms;
namespace PizzaCompany.FormSidbarController
{
    public partial class ProductManagement : SampleForm
    {
        public ProductManagement()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            string qry = "SELECT * FROM productManagement WHERE pName LIKE '%" + textSearch.Text +"%' ";
            ListBox Ib = new ListBox();
            Ib.Items.Add(dgvid);
            Ib.Items.Add(dgName);
            Ib.Items.Add(dgCate);
            Ib.Items.Add(dgPrice);
            //Ib.Items.Add(dgImg);
            MainClass.LoadingData(qry, guna2DataGridView1, Ib);
        }





        private void ProductManagement_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private mProductForm _mProductForm = null; 
        private  void btnAdd_Click_1(object sender, EventArgs e)
        {
            MainClass.BlurBackround(new mProductForm());
            GetData();
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
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                mProductForm mfr = new mProductForm();


                mfr.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                mfr.pName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgName"].Value);
                mfr.pCategory.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgCate"].Value);
                mfr.pPrice.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgPrice"].Value);
                mfr.ShowDialog();
                GetData();


             }


            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgdelet")
            {


                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = "DELETE FROM productManagement WHERE pId = " + id + "";
                Hashtable ht = new Hashtable();

                MainClass.SQL(qry, ht);


                MessageBox.Show("Seleted successfully");
                GetData();
               }


        }
    }
}
