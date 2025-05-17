using PizzaCompany.Helper;
using System;
using System.Collections;
using System.Windows.Forms;


namespace PizzaCompany.FormSidbarController
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
        public int id = 0;
        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(phone.Text) &&
              !string.IsNullOrWhiteSpace(name.Text) &&
              !string.IsNullOrWhiteSpace(address.Text))
            {
                string sql = "";
                if (id == 0)
                {
                    sql = "INSERT INTO Custmer (cPhone, cName, cExt, cAdress, cSuite, cCrost, cCR, cPost, cDl, cIsc) " +
                          "VALUES (@cPhone, @cName, @cExt, @cAdress, @cSuite, @cCrost, @cCR, @cPost, @cDl, @cIsc)";
                }

                Hashtable tb = new Hashtable();
                tb.Add("@cPhone", phone.Text);
                tb.Add("@cName", name.Text);
                tb.Add("@cExt", ext.Text);
                tb.Add("@cAdress", address.Text);
                tb.Add("@cSuite", suite.Text);
                tb.Add("@cCrost", Crosstr.Text);
                tb.Add("@cCR", cr.Text);
                tb.Add("@cPost", postal.Text);
                tb.Add("@cDl", dl.Text);
                tb.Add("@cIsc", cic.Text);
                int newCustomerId = MainClass.SQL(sql, tb);

                if (newCustomerId > 0)
                {

                    SessionClass.CurrentCustomerId = newCustomerId;

                    MessageBox.Show("Customer saved. ID: " + newCustomerId);

                    id = 0;
                    name.Focus();

                    DashbordForm.Instance.backDashboard();
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                MessageBox.Show("Phone, Name, and Address are required.");
            }
        }
    }
}
