using Guna.UI2.WinForms;
using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
using PizzaCompany.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PizzaCompany.DicountPage
{
    public partial class Discount : Form
    {
        private decimal getDiscount;
        private decimal calculateDiscount;
        private decimal getSubTotal;
        private decimal finalAmount = 0;

        private decimal initialPercent = 0;

        public Discount(decimal passedPercent)
        {
            InitializeComponent();
            RefreshCartUI();
            initialPercent = passedPercent;
        }

        public void AddCartCard(CartItem item)
        {
            Guna2Panel guna2Panel = new Guna2Panel
            {
                Size = new Size(350, 85),
                BorderRadius = 10,
                BorderColor = Color.Gray,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(5),
                Tag = item
            };

            Guna2Panel imageWrapper = new Guna2Panel
            {
                Size = new Size(50, 50),
                Location = new Point(5, 5),
                BorderRadius = 3,
            };

            ConvertToImage convertTo = new ConvertToImage();
            Guna2PictureBox pictureBox = new Guna2PictureBox
            {
                Image = convertTo.Imageconvert(item.ProductImage) ?? Properties.Resources.empy,
                Size = new Size(70, 70),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderRadius = 3,
            };
            imageWrapper.Controls.Add(pictureBox);

            Label lblTitle = new Label
            {
                Text = item.Name,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(85, 5),
                BackColor = Color.Transparent,
                AutoSize = false,
                Width = 200,
                Height = 20,
                AutoEllipsis = true,
            };

            Label lblDesc = new Label
            {
                Text = item.dese,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 30),
                AutoSize = false,
                Width = 200,
                Height = 18,
                BackColor = Color.Transparent,
                AutoEllipsis = true,
            };

            Label lblQty = new Label
            {
                Name = "lblQty",
                Text = "x" + item.qty,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 50),
                AutoSize = true
            };

            decimal originalPrice = Convert.ToDecimal(item.Price) * item.qty;
            decimal discountPercent = GetDiscountValue();
            decimal finalPrice = originalPrice - (originalPrice * discountPercent / 100);

            Label lblPrice = new Label
            {
                Text = discountPercent > 0 ? $"${finalPrice:F2} (-{discountPercent}%)" : $"${originalPrice:F2}",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Location = new Point(250, 68),
                AutoSize = true,
                ForeColor = discountPercent > 0 ? Color.Red : Color.Black
            };

            guna2Panel.Controls.Add(imageWrapper);
            guna2Panel.Controls.Add(lblTitle);
            guna2Panel.Controls.Add(lblDesc);
            guna2Panel.Controls.Add(lblQty);
            guna2Panel.Controls.Add(lblPrice);

            flowLayoutPanel1.Controls.Add(guna2Panel);
        }

        public void RefreshCartUI()
        {
            getDiscount = 0;
            getSubTotal = 0;

            flowLayoutPanel1.Controls.Clear();
            foreach (var item in SharedCart.Items)
            {
                getDiscount += Convert.ToDecimal(item.Price) * item.qty;
                getSubTotal += Convert.ToDecimal(item.Price) * item.qty;
                AddCartCard(item);
            }

            lblSubTotal.Text = getSubTotal.ToString("0.00") + "$";
            ApplyDiscount();
            OrderPage.Instance.Payment();
        }
        public decimal discountPercent { get; set; }
        private decimal GetDiscountValue()
        {
            return decimal.TryParse(txtDiscount.Text, out decimal value) ? value : discountPercent;
        }


        private void ApplyDiscount()
        {
            discountPercent = GetDiscountValue();
            calculateDiscount = getDiscount * discountPercent / 100;
            finalAmount = getDiscount - calculateDiscount;
            lblDiscount.Text = finalAmount.ToString("0.00") + "$";
        }
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            RefreshCartUI();
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ShareDiscount.DiscountPercent = discountPercent;
            this.Close();
        }
        private void Discount_Load(object sender, EventArgs e)
        {
            txtDiscount.Text = initialPercent.ToString();
            RefreshCartUI();
        }
    }
}
