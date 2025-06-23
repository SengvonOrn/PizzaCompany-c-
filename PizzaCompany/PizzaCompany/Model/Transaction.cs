using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
namespace PizzaCompany.Model
{
    public partial class Transaction : Form
    {

        private List<CartItem> _items;
        private TextBox txtDetails;
        private PrintDocument printDocument = new PrintDocument();
        private string printContent = "";

        public Transaction(List<CartItem> items)
        {
            InitializeComponent();
            _items = items;
            SetupUI();
            DisplayItems();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }


        //============Set Transaction Textbox==========>
        private void SetupUI()
        {
            txtDetails = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 10),
                BackColor = Color.White
            };
            this.Controls.Add(txtDetails);

            FlowLayoutPanel panelButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(5),
                BackColor = Color.WhiteSmoke
            };

            Button btnPrint = new Button
            {
                Text = "Print Receipt",
                BackColor = Color.LightGreen,
                Width = 120,
                Height = 30
            };

            btnPrint.Click += BtnPrint_Click;
            Button btnBack = new Button
            {
                Text = "Back",
                BackColor = Color.LightSalmon,
                Width = 100,
                Height = 30
            };

            btnBack.Click += (s, e) => this.Hide();


            panelButtons.Controls.Add(btnPrint);
            panelButtons.Controls.Add(btnBack);
            this.Controls.Add(panelButtons);

        }

        //==========Display Data after Order into TextBox==============>
        private void DisplayItems()
        {
            decimal total = 0;
            txtDetails.Clear();
            var customer = _items.FirstOrDefault();
            if (customer != null)
            {


                txtDetails.AppendText("Thank you for your support our Company's\r\n");
                txtDetails.AppendText("========= TRANSACTION RECEIPT =========\r\n");
                txtDetails.AppendText($"Name           : {customer.cCustomer}\r\n");
                txtDetails.AppendText($"Phone          : {customer.cPhone}\r\n");
                txtDetails.AppendText($"Address        : {customer.cAddress}\r\n");
                if (customer.extention != string.Empty)
                { 
                
                txtDetails.AppendText($"Extention      : {customer.extention}\r\n");

                }
                if (customer.suit != string.Empty)
                {
                txtDetails.AppendText($"Suited         : {customer.suit}\r\n");

                }


                if(customer.Crosst != string.Empty)
                {
                txtDetails.AppendText($"Cross Street   : {customer.Crosst}\r\n");

                }


                if (customer.cityregion != string.Empty)
                {

                txtDetails.AppendText($"City           : {customer.cityregion}\r\n");

                }


                if (customer.CR != string.Empty)
                {

                txtDetails.AppendText($"Region         : {customer.CR}\r\n");

                }
                if (customer.Post != string.Empty)
                {
                txtDetails.AppendText($"Cross Street   : {customer.Post}\r\n");

                }

                if (customer.Dl != string.Empty)
                {
                txtDetails.AppendText($"Delivery       : {customer.Dl}\r\n");
                }
                if (customer.Isc != string.Empty)
                {
                txtDetails.AppendText($"Command        : {customer.Isc}\r\n");

                }

                txtDetails.AppendText("----------------------------------------\r\n");

            }

           


            foreach (var item in _items)
            {
                if (decimal.TryParse(item.Price, out decimal price))
                {
                    decimal subTotal = price * item.qty;
                    decimal subVat = subTotal * 0.10m;
                   
                    decimal getTotal = subTotal - subVat;
                    total += getTotal;

                txtDetails.AppendText($"Item           : {item.Name}\r\n");
                txtDetails.AppendText($"Qty            : {item.qty}\r\n");
                txtDetails.AppendText($"Price          : ${item.Price}\r\n");

                if(item.Size != "")
                {
                txtDetails.AppendText($"Size           : {item.Size}\r\n");
                }

                txtDetails.AppendText($"Type           : {item.dine_in}\r\n");
                txtDetails.AppendText($"Subtotal       : ${subTotal:0.00}\r\n");

                txtDetails.AppendText("----------------------------------------\r\n");
                }
            }
                txtDetails.AppendText($"Vat            : 10%\r\n");
                txtDetails.AppendText($"TOTAL          : ${total:0.00}\r\n");
                txtDetails.AppendText("========================================\r\n");
                txtDetails.AppendText(DateTime.Now.ToString("dd-MMM-yyyy hh:mm") + "\r");
        }

        //=======================Insert Data Into Database=========================>


        private void InsertTransactionData()
        {
            foreach (var item in _items)
            {
            string query = @"INSERT INTO OrderTable 
            (cId, pId, Quantity, Size, payment, DineType, Subtotal, Action) 
            VALUES 
            (@cId, @pId, @Quantity,  @Size, @payment, @DineType, @Subtotal, @Action)";

                decimal price = decimal.TryParse(item.Price, out price) ? price : 0;
                decimal subtotal = price * item.qty;

                Hashtable tb = new Hashtable();
                tb.Add("@cId", SessionClass.CurrentCustomerId);
                tb.Add("@pId",item.pId);  
                tb.Add("@Quantity", item.qty);
                tb.Add("@Size", item.Size);
                tb.Add("@DineType", item.dine_in);
                tb.Add("@payment", item.payment);
                tb.Add("@Subtotal", subtotal);
                tb.Add("@Action", item.action);
                MainClass.SQL(query, tb);
            }
        }


        //==============BtnPrint Event==========================>


        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printContent = txtDetails.Text;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    InsertTransactionData();
                    SessionClass.CurrentCustomerId = 0;
                   
                    printDocument.Print();
                   
                    SharedCart.Items.Clear();
                    
                    if (Dashboard.Instance != null)
                    {
                        Dashboard.Instance.RefreshCartUI();
                    }
                    MessageBox.Show("Receipt printed. Cart cleared.", "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
        }


        //================Event Print and Save Transaction=========================>

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image logo = Properties.Resources.Group_1;
            string name = "Pizza Company";

            int maxWidth = 100;
            int maxHeight = 100;

            float ratioX = (float)maxWidth / logo.Width;
            float ratioY = (float)maxHeight / logo.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int logoWidth = (int)(logo.Width * ratio);
            int logoHeight = (int)(logo.Height * ratio);

            int logoX = e.MarginBounds.Left;
            int logoY = e.MarginBounds.Top;

            e.Graphics.DrawImage(logo, new Rectangle(logoX, logoY, logoWidth, logoHeight));

            Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            float titleX = logoX + logoWidth + 20;
            float titleY = logoY + (logoHeight / 2) - (titleFont.Height / 2);

            e.Graphics.DrawString(name, titleFont, Brushes.Black, titleX, titleY);

            Font printFont = new Font("Consolas", 10);
            float textX = logoX;
            float textY = logoY + logoHeight + 20;

            e.Graphics.DrawString(printContent, printFont, Brushes.Black,
                new RectangleF(textX, textY, e.MarginBounds.Width, e.MarginBounds.Height - textY));
        }

    }
}
