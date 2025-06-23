using System;
using PizzaCompany.LoadingController;
using PizzaCompany.FormMenuController;
using System.Windows.Forms;
using PizzaCompany.Model;
using Guna.UI2.WinForms;
using System.Drawing;
using PizzaCompany.Helper;
namespace PizzaCompany.FormSidbarController
{
    public partial class Dashboard : Form
    {
        public static Dashboard Instance { get; private set; }
        public  Dashboard()
        {
            InitializeComponent();
            PizzaForm  pizzaForm = new PizzaForm();
            Instance = this;
            RefreshCartUI();
            Payment();
       
        }
        PermissionForm permission = new PermissionForm();

        //=========================Update Item=====================>

        public void UpdateCartCard(CartItem item)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Panel panel && panel.Tag is CartItem cartItem)
                {
                    if (cartItem.Name == item.Name && cartItem.Size == item.Size)
                    {
                        foreach (Control inner in panel.Controls)
                        {
                            if (inner is Label lbl && lbl.Name == "lblQty")
                            {
                                lbl.Text = "x" + item.qty;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            Payment();
        }


        //==========================Add To Cart==================>

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



            //=====image==>

            Guna2Panel imageWrapper = new Guna2Panel
            {
                Size = new Size(74, 74),
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

            //===========label1===>
            Label lblTitle = new Label
            {
                Text = item.Name,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(85, 5),
                BackColor = Color.Transparent,
                AutoSize = false,                
                AutoEllipsis = true,
            };

            //===================>

            Label lblDesc = new Label
            {
                Text = item.dese,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 30),
                AutoSize = false,
                BackColor = Color.Transparent,
                AutoEllipsis = true,
            };


            //====================>
            Label lblQty = new Label
            {
                Name = "lblQty",
                Text = "x" + item.qty,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 50),
                AutoSize = true
            };

            //===================>
            Label lblSize = new Label
            {
                Text = int.TryParse(item.Size, out int size)
                    ? (size == 6 ? "6S" : size == 9 ? "9M" : "12L") : "",
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 68),
                AutoSize = true
            };

          //==================>

            Label lblPrice = new Label
            {
                Text = "$" + item.Price.ToString(),
                Font = new Font("Segoe UI", 8),
                Location = new Point(300, 68),
                AutoSize = true
            };
            //=====================>
            // Delete Button
            Guna2Button btnDelete = new Guna2Button
            {
                Text = "Delete",
                FillColor = Color.Red,
                ForeColor = Color.White,
                Size = new Size(60, 25),
                Location = new Point(280, 10),
                Font = new Font("Segoe UI", 8),
                BorderRadius = 3
            };
            btnDelete.Click += (s, e) => RemoveCartItem(item, guna2Panel);
            //=====================>
            // Decrement Button
            Guna2Button btnDecrement = new Guna2Button
            {
                Text = "-",
                Size = new Size(60, 25),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(112, 31, 242),
                Location = new Point(210, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BorderRadius = 3


            };



            btnDecrement.Click += (s, e) => DecrementCartItem(item, lblQty, guna2Panel);


            //====================>
            // Add controls
            guna2Panel.Controls.Add(imageWrapper);
            guna2Panel.Controls.Add(lblTitle);
            guna2Panel.Controls.Add(lblDesc);
            guna2Panel.Controls.Add(lblQty);
            guna2Panel.Controls.Add(lblSize);       
            guna2Panel.Controls.Add(btnDelete);
            guna2Panel.Controls.Add(btnDecrement);
            guna2Panel.Controls.Add(lblPrice);
            flowLayoutPanel1.Controls.Add(guna2Panel);
            Payment();
        }


        //==================Remove Item=========================>
        public void RemoveCartItem(CartItem item, Guna2Panel panel)
        {
            SharedCart.Items.Remove(item);
            flowLayoutPanel1.Controls.Remove(panel);
            Payment();
        }
        public void RemoveCartItem(CartItem existingItem)
        {
            throw new NotImplementedException();
        }


        //=================add DecrementCart=======================>
        public void DecrementCartItem(CartItem item, Label lblQty, Guna2Panel panel)
        {
            item.qty--;

            if (item.qty <= 0)
            {
                RemoveCartItem(item, panel);
            }
            else
            {
                lblQty.Text = "x: " + item.qty;
            }
            Payment();
        }
        //====================For Refresh==========================>
        

        public void RefreshCartUI()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in SharedCart.Items)
            {
                AddCartCard(item);
            }
            Payment();
            contform.AddMenuControls(new PizzaForm(), PanelMenuContainner);
        }

        //==================Calculate Total payment===============================>

        public string Subtotals { get; set; }
        public string Totals { get; set; }
        public decimal subtotal = 0;
        public decimal vat = 0;
        public decimal total = 0;

        public  void Payment()
        {
            subtotal = 0;

            foreach (var item in SharedCart.Items)
            {
                if (decimal.TryParse(item.Price, out decimal price))
                {
                    subtotal += price * item.qty;
                }
            }
            vat = subtotal * 0.10m;
            total = subtotal - vat ;

            Subtotals = subtotal.ToString("0.00");
            Totals = total.ToString("0.00");

            Subtotal.Text = $"${Subtotals}";
            Tax.Text = $"$(10%)";
            Total.Text = $"${Totals}";
        }





        //====================All btn Event=============================>





        FromController contform = new FromController();

        private void Dashboard_Load(object sender, EventArgs e)
        {

            contform.AddMenuControls(new PizzaForm(), PanelMenuContainner);
      

        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            contform.AddMenuControls(new PizzaForm(), PanelMenuContainner);
        }

        private void btnBuffPizza_Click(object sender, EventArgs e)
        {
            contform.AddMenuControls(new BuffPizzaForm(), PanelMenuContainner);

        }

        private void btnBitePizza_Click(object sender, EventArgs e)
        {

            contform.AddControlsSidebar(new BitePizzaForm(), PanelMenuContainner);

        }

        private void btnMainBish_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new MainBishForm(), PanelMenuContainner);
        }

        private void btnCheckenForm_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new CheckenForm(), PanelMenuContainner);
        }

        private void btnSalad_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new SaladForm(), PanelMenuContainner);
        }

        private void btnKitMenu_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new KitMenuForm(), PanelMenuContainner);
        }

        private void btnAppetizer_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new AppetizerForm(), PanelMenuContainner);
        }

        private void btnDesserts_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new DessertForm(), PanelMenuContainner);
        }

        private void btnBeverages_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new BeverageForm(), PanelMenuContainner);
        }




        private void btnplaceorder_Click(object sender, EventArgs e)
        {




            if (SharedCart.Items.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }
            else
            {
                permission.ShowDialog();

                if (permission.popup == true)
                {
                    Transaction t = new Transaction(SharedCart.Items);
                    t.ShowDialog();
                }
            }
        }

        private void btnDinin_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.dine_in = "Dine-in";
            }

            MessageBox.Show("Order type set to Dine-in.");
        }
        private void btnDelivery_Click(object sender, EventArgs e)
        {

            foreach (var item in SharedCart.Items)
            {
                item.dine_in = "Delivery";
            }

            MessageBox.Show("Order type set to Delivery.");

        }

        private void btnCarryout_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.dine_in = "CarryOut";
            }

            MessageBox.Show("Order type set to Carry Out.");

        }



        private void btnpayLater_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.payment = "Pending";
            }

            MessageBox.Show("Order type set to Pay Latter.");
        }



        private void btnCash_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.payment = "Success";
            }

            MessageBox.Show("Order type set to Cash.");

        }

        private void btnCredit_Click(object sender, EventArgs e)
        {

            foreach (var item in SharedCart.Items)
            {
                item.payment = "Success";
            }

            MessageBox.Show("Order type set to Credit Cart.");

        }
    }
}
