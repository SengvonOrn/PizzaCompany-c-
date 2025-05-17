using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using QRCoder;
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

            btnBack.Click += (s, e) => this.Close();
            Button btnKhqr = new Button
            {
                Text = "Pay with KHQR",
                BackColor = Color.LightSkyBlue,
                Width = 120,
                Height = 30
            };
            btnKhqr.Click += BtnKhqr_Click;
            panelButtons.Controls.Add(btnPrint);
            panelButtons.Controls.Add(btnKhqr);
            panelButtons.Controls.Add(btnBack);
            this.Controls.Add(panelButtons);
        }
        private void DisplayItems()
        {
            decimal total = 0;
            txtDetails.Clear();
            var firstItem = _items.FirstOrDefault();
            if (firstItem != null)
            {
                txtDetails.AppendText("========= TRANSACTION RECEIPT =========\r\n");
                txtDetails.AppendText($"Name      : {firstItem.cCustomer}\r\n");
                txtDetails.AppendText($"Phone     : {firstItem.cPhone}\r\n");
                txtDetails.AppendText($"Addres   : {firstItem.cAddress}\r\n");
                //txtDetails.AppendText($"Street   : {firstItem.cStreet}\r\n");
            }
            foreach (var item in _items)
            {
                if (decimal.TryParse(item.Price, out decimal price))
                {
                    decimal subTotal = price * item.qty;
                    total += subTotal;

                    txtDetails.AppendText($"\r\nItem      : {item.Name}\r\n");
                    txtDetails.AppendText($"Qty       : {item.qty}\r\n");
                    txtDetails.AppendText($"Price     : ${item.Price}\r\n");
                    txtDetails.AppendText($"Size      : {item.Size}\r\n");
                    txtDetails.AppendText($"Type      : {item.dine_in}\r\n");
                    txtDetails.AppendText($"Note      : {item.dese}\r\n");
                    txtDetails.AppendText($"Subtotal  : ${subTotal:0.00}\r\n");
                    txtDetails.AppendText("----------------------------------------\r\n");
                }
            }
            txtDetails.AppendText($"\r\nTOTAL: ${total:0.00}\r\n");
            txtDetails.AppendText("========================================\r\n");
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printContent = txtDetails.Text;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    SharedCart.Items.Clear();
                    MessageBox.Show("Receipt printed. Cart cleared.", "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Consolas", 10);
            e.Graphics.DrawString(printContent, printFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
        }

        // ========== KHQR Section ==========

        private void BtnKhqr_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                if (decimal.TryParse(item.Price, out decimal price))
                {
                    total += price * item.qty;
                }
            }

            string khqrData = GenerateKHQR(total);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(khqrData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);
                ShowQrPopup(qrImage);
            }
        }

        private string GenerateKHQR(decimal amount)
        {
            string merchantId = "1255725"; // ABA merchant ID
            string merchantName = "orn Sengvun";
            string city = "Phnom Penh";
            string amountStr = amount.ToString("0.00");

            return
                "000201" +
                "010212" +
                "2937" +
                "0016A000000677010111" +
                "0113" + merchantId +
                "52040000" +
                "530376" +
                $"5404{amountStr}" +
                "5802KH" +
                $"59{merchantName.Length:D2}{merchantName}" +
                $"60{city.Length:D2}{city}";
        }

        private void ShowQrPopup(Bitmap qrImage)
        {
            Form qrForm = new Form
            {
                Text = "Scan to Pay (KHQR)",
                Size = new Size(300, 350),
                StartPosition = FormStartPosition.CenterParent
            };

            PictureBox qrBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = qrImage,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            qrForm.Controls.Add(qrBox);
            qrForm.ShowDialog();
        }
    }
}
