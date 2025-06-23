using PizzaCompany.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
namespace PizzaCompany.FormSidbarController
{
    public partial class customerManagement : SampleForm
    {
        public customerManagement()
        {
            InitializeComponent();
        }
        PermissionForm permission = new PermissionForm();
        public void GetData()
        {
            string qry = @"
                    WITH LatestOrders AS (
                    SELECT *, ROW_NUMBER() OVER (PARTITION BY cId ORDER BY CreatedAt DESC) AS rn
                    FROM OrderTable )
                    SELECT 
                    c.cId,
                    o.oId, 
                    c.cPhone,
                    c.cName, 
                    c.cExt, 
                    c.cAdress, 
                    c.cSuite, 
                    c.cCrost, 
                    c.cCR, 
                    c.city, 
                    c.cPost, 
                    c.cDl, 
                    c.cIsc,
                    o.payment
                FROM Custmer c
                JOIN LatestOrders o ON c.cId = o.cId
                WHERE o.rn = 1 AND c.cName LIKE '%" + textSearch.Text + @"%' 
                ORDER BY o.CreatedAt DESC";
            ListBox Ib = new ListBox();
            Ib.Items.Add(cId);
            Ib.Items.Add(oId);
            Ib.Items.Add(cphone);
            Ib.Items.Add(cname);
            Ib.Items.Add(extention);
            Ib.Items.Add(caddress);
            Ib.Items.Add(cSuite);
            Ib.Items.Add(ccrost);
            Ib.Items.Add(ccr);
            Ib.Items.Add(ct);
            Ib.Items.Add(cpostcode);
            Ib.Items.Add(cdelivery);
            Ib.Items.Add(cinstore);
            Ib.Items.Add(payment);

            MainClass.LoadingData(qry, guna2DataGridView1, Ib);
        }
        private void btnAdd_Click_1(object sender, System.EventArgs e)
        {

            MainClass.BlurBackround(new Customer());
        }
        public override void textSearch_TextChanged(object sender, EventArgs e)
        {
          
            GetData();
        }
        private  void customerManagement_Load(object sender, System.EventArgs e)
        {
            GetData();

        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell == null || guna2DataGridView1.CurrentRow == null)
                return;
            string columnName = guna2DataGridView1.CurrentCell.OwningColumn.Name;


            //=======>


            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "print" && e.RowIndex >= 0)
            {
                int customerId = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["cId"].Value);
                List<CartItem> cartItems = MainClass.getdataPrint(customerId);

                if (cartItems != null && cartItems.Count > 0)
                {
                    Transaction transactionForm = new Transaction(cartItems);
                    transactionForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No cart items found for this customer.");
                }
            }


            //======>




            if (columnName == "edited")
            {

                permission.ShowDialog();

                if (permission.popup == true)
                {
                    Customer cus = new Customer();

                    cus.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["cId"].Value);
                    cus.phone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cphone"].Value);
                    cus.ext.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["extention"].Value);
                    cus.name.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cname"].Value);
                    cus.address.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["caddress"].Value);
                    cus.suite.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cSuite"].Value);
                    cus.Crosstr.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["ccrost"].Value);
                    cus.cityregion.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["ccr"].Value);
                    cus.cr.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["ct"].Value);
                    cus.postal.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cpostcode"].Value);
                    cus.dl.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cdelivery"].Value);
                    cus.cic.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["cinstore"].Value);
                    cus.ShowDialog();
                    GetData();

                }

             
            }
            if (columnName == "deleted")
            {
                permission.ShowDialog();

                if (permission.popup == true)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["cId"].Value);

                string sql = @"
                DELETE OT
                FROM [VSUSER].[dbo].[OrderTable] OT
                INNER JOIN [VSUSER].[dbo].[Custmer] C ON OT.cId = C.cId
                WHERE C.cId = @cId;

                DELETE FROM [VSUSER].[dbo].[Custmer]
                WHERE cId = @cId;
            ";

                Hashtable ht = new Hashtable();
                ht.Add("@cId", id);

                MainClass.SQL(sql, ht);

                MessageBox.Show("Deleted successfully");
                GetData(); 
            }

            }

            if (columnName == "payment")
            {

                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["cId"].Value);

                MainClass.UpdatePayment(id);
                GetData();
            }

        }
    }
}
