using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
using PizzaCompany.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace PizzaCompany.FormMenuController
{
    public partial class DessertForm : Form
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
        public int id = SessionClass.CurrentCustomerId;
        public DessertForm()
        {
            InitializeComponent();
            SetupFlowPanel();
        }

        public void Getdata()
        {
            flowLayoutPanel1.Controls.Clear();

            MainClass mainClass = new MainClass();
            List<ProductModel> products = mainClass.GetProductsBySearch(searchMenu.Text, "Desserts", "", "");
            foreach (var product in products)
            {
                Panel productPanel = new Panel
                {
                    Width = 390,
                    Height = 220,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White

                };
                ConvertToImage convertTo = new ConvertToImage();
                PictureBox pictureBox = new PictureBox
                {
                    Image = convertTo.Imageconvert(product.ImageBytes) ?? Properties.Resources.empy,
                    Width = 230,
                    Height = 150,

                    Location = new Point(-3, 15),
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                Label lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(228, 15),
                    BackColor = Color.Transparent,
                    Size = new Size(160, 20),
                    Width = 200
                };
                Label lblCategory = new Label
                {
                    Text = product.command,
                    Location = new Point(228, 40),
                    Size = new Size(150, 100),
                    BackColor = Color.Transparent,
                    Margin = new Padding(10),
                    AutoSize = false,
                    AutoEllipsis = true,
                    Font = new Font("Segoe UI", 9)
                };
                Label lblPrice = new Label
                {
                    Text = "$" + product.Price,
                    Location = new Point(10, 180),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    Width = 50
                };
                Button addButton = new Button
                {
                    Text = "Add",
                    Location = new Point(280, 160),
                    Width = 100,
                    Height = 50,
                    BackColor = Color.SkyBlue
                };
                string productName = product.Name;
                //string productDesc = product.command;
                string productPrice = product.Price.ToString();
                Image productImage = pictureBox.Image;
                string pId = product.pId;
                //=======================================>

                addButton.Click += (s, ev) =>
                {

                    if (id == 0)
                    {
                        MessageBox.Show("User invalid");
                    }
                    else
                    {
                        CustomerModel customer = MainClass.GetCustomerById(id);
                        var existingItem = SharedCart.Items.Find(x => x.Name == productName);

                        if (existingItem != null)
                        {
                            existingItem.qty += 1;
                            Dashboard.Instance.UpdateCartCard(existingItem);
                        }
                        else
                        {
                            var item = new CartItem
                            {
                                pId = pId,
                                cCustomer = customer.Name,
                                cPhone = customer.Phone,
                                cAddress = customer.Address,
                                Crosst = customer.Crosst,
                                CR = customer.CR,
                                Post = customer.Post,
                                cityregion = customer.cityR,
                                extention = customer.Ext,
                                suit = customer.Suite,
                                Isc = customer.Isc,
                                Dl = customer.Dl,


                                Name = productName,
                                //dese = productDesc,
                                Price = productPrice,
                                Size = "",
                                qty = 1,
                                ProductImage = product.ImageBytes
                            };

                            SharedCart.Items.Add(item);
                            Dashboard.Instance.AddCartCard(item);
                        }

                    }
                };
                //=======================================>
                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblCategory);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(addButton);
                flowLayoutPanel1.Controls.Add(productPanel);
            }
        }
        private void DessertForm_Load(object sender, EventArgs e)
        {
            Getdata();
        }
    }
}
