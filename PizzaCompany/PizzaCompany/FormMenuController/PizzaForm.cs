
using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
using PizzaCompany.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace PizzaCompany.FormMenuController
{
    public partial class PizzaForm : Form
    {

        //===============SetupFlowPanel=============>

 


        //========================================>

        public int id = SessionClass.CurrentCustomerId;
       
        public PizzaForm()
        {

            InitializeComponent();
      
       
        }

        // ================search=================>


        private void searchMenu_TextChanged(object sender, EventArgs e)
        {
            Getdata();
        }



        //===================loading=========================>
        private void PizzaForm_Load(object sender, EventArgs e)
        {
            Getdata();
        }

        //=====================getAl data====================>

        private string myselectOption;
        private string myselectgroup;

        private void selectOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            myselectOption = selectOptions.SelectedItem.ToString();
            Getdata();
        }




        private void btnClassicpizza_Click(object sender, EventArgs e)
        {
            myselectgroup = "seafood Deluxe";
            Getdata();

        }
        private void btnDeluxpizza_Click(object sender, EventArgs e)
        {
            myselectgroup = "deluxe pizza";
            Getdata();
        }
        private void btnSeafood_Click(object sender, EventArgs e)
        {
            myselectgroup = "seafood Deluxe";
            Getdata();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            myselectgroup = "All";
            myselectOption = "clear";
            myselectOption = Convert.ToString(selectOptions.SelectedIndex = 0);
            Getdata();
        }



        public void Getdata()
        {
            flowLayoutPanel1.Controls.Clear(); 

            MainClass mainClass = new MainClass();


            List<ProductModel> products = mainClass.GetProductsBySearch(searchMenu.Text, "Pizza", myselectOption, myselectgroup);


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
                    SizeMode = PictureBoxSizeMode.Zoom
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


                Label lblSize = new Label
                {
                    Text = int.TryParse(product.Size, out int size)
                    ? (size == 6 ? "6S" : size == 9 ? "9M" : "12L") : "No",
                    Location = new Point(218, 215),
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    Width = 60
                };




                string productName = product.Name;
                string productDesc = product.command;
                string productPrice =product.Price.ToString();
                string productSize = product.Size;
                string pId = product.pId;



                pictureBox.Click += (s, ev) =>
                {
                    if(id == 0)
                    {
                        MessageBox.Show("Invalid Customer");
                        return;
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
                                Post = customer.Post,
                                cityregion = customer.cityR,
                                CR        = customer.CR,
                                extention = customer.Ext,
                                suit = customer.Suite,
                                Isc = customer.Isc,
                                Dl = customer.Dl,

                                //===>

                                Name = productName,
                                Price = productPrice,
                                Size = productSize,
                                qty = 1,
                                ProductImage = product.ImageBytes

                            };
                            SharedCart.Items.Add(item);
                            OrderPage.Instance.AddCartCard(item);
                        }
                        return;

                    }                   
                };
                productPanel.Controls.Add(pictureBox);
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(lblPrice);
                productPanel.Controls.Add(lblSize);
                flowLayoutPanel1.Controls.Add(productPanel);
            }

        }

    }
}




