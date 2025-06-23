using System;
using System.Collections;
using System.Windows.Forms;


namespace PizzaCompany.Stock
{
    public partial class fmOutStock : Form
    {
        public fmOutStock()
        {
            InitializeComponent();
        }


        public int Id = 0;
        public decimal getstokes   = 0;
        public decimal  TotalPrice  = 0;


        private decimal getTotalStock = 0;
        private decimal getTotalPrice = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {

         

          string  qry = "UPDATE StockProduct SET  InStock = @IntStock, OutStock = @OutStock, TotalStock = @TotalStock, TotalPrice = @TotalPrice  WHERE Id = @Id";
          Hashtable ht = new Hashtable();

         getTotalStock = getstokes - Convert.ToDecimal(InStock.Text);
         getTotalPrice = TotalPrice * Convert.ToDecimal(InStock.Text);
          
          ht.Add("@Id", Id);
          ht.Add("@IntStock",  Convert.ToDecimal(InStock.Text));
          ht.Add("@OutStock", getTotalStock);
          ht.Add("@TotalStock", Convert.ToDecimal(InStock.Text));
          ht.Add("@TotalPrice", getTotalPrice);
            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                Id = 0;
                InStock.Text = "";
                getstokes = 0;
                TotalPrice = 0;
            }
            Id = 0;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
