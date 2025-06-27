using System;
using System.Collections;
using System.Windows.Forms;

namespace PizzaCompany.Stock
{
    public partial class stockModelform : Form
    {
        public stockModelform()
        {
            InitializeComponent();
        }


        public int Id = 0;
        public decimal IntStocks = 0;
        public decimal OutStocks = 0;


        private decimal getOutStocks = 0;
        private decimal getTotalPrice = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (Id == 0)
            {
                qry = "INSERT INTO StockProduct(Name,  Price, Stocks, InStock, OutStock,  TotalStock, TotalPrice) VALUES(@Name, @Price, @Stocks, '0', '0', @TotalStock, @TotalPrice)";
            }
            else
            {
                qry = "UPDATE StockProduct SET Name = @Name, Price = @Price,  Stocks = @Stocks, OutStock = @OutStock  WHERE Id = @Id";
            }
            if(name.Text == "" || price.Text == "" ||  Stoks.Text == "")
            {
                MessageBox.Show("Please Input completed field");
                return;
            }
            else
            {
                if (IntStocks == 0)
                {
                
                    getTotalPrice = Convert.ToDecimal(price.Text) * Convert.ToDecimal(Stoks.Text);
                }
                else
                {
                    getTotalPrice = Convert.ToDecimal(price.Text) * Convert.ToDecimal(IntStocks);
                }

                getOutStocks = Convert.ToDecimal(Stoks.Text) - IntStocks;
                Hashtable ht = new Hashtable();


                ht.Add("@id", Id);
                ht.Add("@Name", name.Text);
                ht.Add("@Price", price.Text);

                ht.Add("@Stocks", Stoks.Text);
                ht.Add("@Instock ", Stoks.Text);


                ht.Add("@OutStock", getOutStocks);
                ht.Add("@TotalStock", Stoks.Text);

                ht.Add("@TotalPrice", getTotalPrice);


                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Saved successfully");
                    Id = 0;
                    name.Text = "";
                    price.Text = "";
                    Stoks.Text = "";
                }
                Id = 0;

            }



           
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
