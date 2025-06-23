

using PizzaCompany.Stock;
using System;
using System.Windows.Forms;


namespace PizzaCompany.FormSidbarController
{
    public partial class StockProduct :  SampleForm
    {
        public StockProduct()
        {
            InitializeComponent();  
        }
        public void GetData()
        {
            string qry = "SELECT Id, Name, Price, Stocks, InStock, OutStock, TotalStock, TotalPrice, CreatedAt FROM StockProduct WHERE Name LIKE '%" + textSearch.Text + "%' ORDER BY Id DESC";
            ListBox Ib = new ListBox();
             

            Ib.Items.Add(Id);
            Ib.Items.Add(name);
            Ib.Items.Add(Price);
            Ib.Items.Add(stock);
            Ib.Items.Add(InStock);
            Ib.Items.Add(OutStock);
            Ib.Items.Add(totalStock);
            Ib.Items.Add(totalprice);
            MainClass.LoadingData(qry, guna2DataGridView1, Ib);
        }


        public override void textSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        private void StockProduct_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             StockTable stockTable = new StockTable();
             stockTable.ShowDialog();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
                MainClass.BlurBackround(new  stockModelform());
        }

    
    }
}
