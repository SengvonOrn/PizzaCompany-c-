using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
using PizzaCompany.Model;
using System;
using System.Collections.Generic;

using System.Drawing;

using System.Windows.Forms;

namespace PizzaCompany.FormMenuController
{
    public partial class AppetizerForm : Form
    {
        private FlowLayoutPanel flowPanel;
        private void SetupFlowPanel()
        {
            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.Controls.Add(flowPanel);
        }
        public AppetizerForm()
        {

            InitializeComponent();
            SetupFlowPanel();
        }

        //====================>
        private void searchMenu_TextChanged(object sender, EventArgs e)
        {
            Getdata();
        }
        public void Getdata()
        {
            flowLayoutPanel1.Controls.Clear();

            MainClass mainClass = new MainClass();
            List<ProductModel> products = mainClass.GetProductsBySearch(searchMenu.Text, "Appetzer");

            foreach (var product in products)
            {
                Panel productPanel = new Panel
                {
                    Width = 350,
                    Height = 220,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                // Image placeholder (you can load actual image if available)
                PictureBox pictureBox = new PictureBox
                {
                    Width = 100,
                    Height = 80,
                    Location = new Point(10, 10),
                    BackColor = Color.Teal,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                // pictureBox.Image = product.Image; // Optional if your product has an image

                Label lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(120, 10),
                    Width = 200
                };

                Label lblCategory = new Label
                {
                    Text = product.Category,
                    Location = new Point(120, 35),
                    Width = 200
                };

                Label lblPrice = new Label
                {
                    Text = "$" + product.Price,
                    Location = new Point(10, 100),
                    Width = 100
                };

                ComboBox sizeComboBox = new ComboBox
                {
                    Location = new Point(120, 100),
                    Width = 60,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                sizeComboBox.Items.AddRange(new object[] { "6", "9", "12" });
                sizeComboBox.SelectedIndex = 0;

                Button addButton = new Button
                {
                    Text = "Add",
                    Location = new Point(190, 98),
                    Width = 80,
                    Height = 25,
                    BackColor = Color.SkyBlue
                };

                // Capture variables to avoid closure issues
                string productName = product.Name;
                string productDesc = product.Category;
                string productPrice = product.Price;
                Image productImage = pictureBox.Image;

                addButton.Click += (s, ev) =>
                {
                    int selectedSize = int.Parse(sizeComboBox.SelectedItem.ToString());

                    var existingItem = SharedCart.Items.Find(x =>
                        x.Name == productName && x.Size == selectedSize && x.dese == productDesc);

                    if (existingItem != null)
                    {
                        existingItem.qty += 1;
                        Dashboard.Instance.UpdateCartCard(existingItem);
                    }
                    else
                    {
                        var item = new CartItem
                        {
                            Name = productName,
                            dese = productDesc,
                            Price = productPrice,
                            Size = selectedSize,
                            qty = 1,
                            ProductImage = productImage
                        };

                        SharedCart.Items.Add(item);
                        Dashboard.Instance.AddCartCard(item);
                    }
                };
                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblCategory);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(sizeComboBox);
                productPanel.Controls.Add(addButton);
                flowLayoutPanel1.Controls.Add(productPanel);
            }

        }

        private void AppetizerForm_Load(object sender, EventArgs e)
        {
            Getdata();
        }

        int id = SessionClass.CurrentCustomerId;
        TextBox txtName = new TextBox();
        TextBox txtDesc = new TextBox();
        TextBox txtPrice = new TextBox();
        ComboBox cmbSize = new ComboBox();
        PictureBox productImageBox = new PictureBox();
        //=============================>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string des = txtDesc.Text;
            string price = txtPrice.Text;
            Image productImage = productImageBox.Image;

            if (!int.TryParse(cmbSize.SelectedItem.ToString(), out int size))
            {
                MessageBox.Show("Invalid size.");
                return;
            }

            var existingItem = SharedCart.Items.Find(x => x.Name == name && x.Size == size && x.dese == des);

            if (existingItem != null)
            {
                existingItem.qty += 1;
                Dashboard.Instance.UpdateCartCard(existingItem);
            }
            else
            {
                var item = new CartItem
                {
                    Name = name,
                    dese = des,
                    Price = price,
                    Size = size,
                    qty = 1,
                    ProductImage = productImage
                };

                SharedCart.Items.Add(item);
                Dashboard.Instance.AddCartCard(item);
            }
        }



    }
}
