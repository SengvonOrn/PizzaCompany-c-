using PizzaCompany.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace PizzaCompany.Stock
{
    public partial class StockTable : Form
    {
        public StockTable()
        {
            InitializeComponent();
        }




        public void GetData()
        {
            string qry = "SELECT Id, Name FROM StockProduct";
            ListBox Ib = new ListBox();

            Ib.Items.Add(Id);
            Ib.Items.Add(name);
            MainClass.LoadingData(qry, guna2DataGridView1, Ib);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void StockTable_Load(object sender, EventArgs e)
        {
            GetData();
        }

        MainClass mainClass = new MainClass();
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell == null || guna2DataGridView1.CurrentRow == null)
                return;

            string columnName = guna2DataGridView1.CurrentCell.OwningColumn.Name;

            if(columnName == "update")
            {


                stockModelform modelform = new stockModelform();

                int Id =  Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Id"].Value);



                List<stockModel> stockModels = mainClass.getUpdatestock(Id); 
                foreach ( var  stocks in  stockModels)
                {
                    modelform.Id = stocks.Id;
                    modelform.name.Text = stocks.name;
                    modelform.price.Text = Convert.ToDecimal(stocks.price).ToString("0.##");
                    modelform.Stoks.Text = Convert.ToDecimal(stocks.stocks).ToString("0.##");
                    modelform.IntStocks = Convert.ToDecimal(stocks.In_stock);
                    modelform.OutStocks = Convert.ToDecimal(stocks.outStock);

                }

                MainClass.BlurBackround(modelform);
                GetData();

            }





            if (columnName == "add")
            {
                fmOutStock Stock = new fmOutStock();
                int Id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Id"].Value);
                List<stockModel> stockModels = mainClass.getUpdatestock(Id);


                foreach (var stocks in stockModels)
                {


                    Stock.Id = stocks.Id;
                    Stock.InStock.Text = Convert.ToDecimal(stocks.In_stock).ToString("0.##");
                    Stock.getstokes = Convert.ToDecimal(stocks.stocks);
                    Stock.TotalPrice = Convert.ToDecimal(stocks.price);

                }
             
                MainClass.BlurBackround(Stock);
                GetData();
            }
        }
    }
}
