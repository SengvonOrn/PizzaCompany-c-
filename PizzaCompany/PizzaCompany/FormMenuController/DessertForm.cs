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

 




        public int id = SessionClass.CurrentCustomerId;
        public DessertForm()
        {
            InitializeComponent();
         
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

                    Width = 265,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.White

                };
                ConvertToImage convertTo = new ConvertToImage();
                PictureBox pictureBox = new PictureBox
                {
                    Image = convertTo.Imageconvert(product.ImageBytes) ?? Properties.Resources.empy,
                    Width = 270,
                    Height = 160,
                    Location = new Point(0, 0),
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                };
                Label lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(10, 180),
                    BackColor = Color.Transparent,
                    Size = new Size(230, 20),
                    AutoSize = false,
                    AutoEllipsis = true,

                };



                Label lblPrice = new Label
                {
                    Text = "$" + product.Price,
                    Location = new Point(10, 205),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    Width = 50
                };
              
                string productName = product.Name;
                //string productDesc = product.command;
                string productPrice = product.Price.ToString();
                Image productImage = pictureBox.Image;
                string pId = product.pId;
                //=======================================>

                pictureBox.Click += (s, ev) =>
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
                            OrderPage.Instance.UpdateCartCard(existingItem);
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
                            OrderPage.Instance.AddCartCard(item);
                        }

                    }
                };
                //=======================================>
                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
   
                productPanel.Controls.Add(lblPrice);
            
                flowLayoutPanel1.Controls.Add(productPanel);
            }
        }
        private void DessertForm_Load(object sender, EventArgs e)
        {
            Getdata();
        }
    }
}
