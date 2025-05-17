using System;
using PizzaCompany.LoadingController;
using PizzaCompany.FormMenuController;
using System.Windows.Forms;
using PizzaCompany.Helper;
using PizzaCompany.Model;
using Guna.UI2.WinForms;
using System.Drawing;
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
        //==============================================>



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


        //======================================================>




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


            Guna2PictureBox pictureBox = new Guna2PictureBox
            {
                Size = new Size(70, 70),
                Location = new Point(5, 5),
                Image = item.ProductImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderRadius = 5
            };


            //===========label1===>


            Label lblTitle = new Label
            {
                Text = item.Name,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(85, 5),
                AutoSize = true
            };


            //====================>


            Label lblQty = new Label
            {
                Name = "lblQty",
                Text = "x: " + item.qty,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 30),
                AutoSize = true
            };


            //===================>

            Label lblSize = new Label
            {
                Text = "Size: " + item.Size,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 50),
                AutoSize = true
            };

            //===================>

            Label lblDesc = new Label
            {
                Text = item.dese,
                Font = new Font("Segoe UI", 8),
                Location = new Point(85, 70),
                AutoSize = true
            };



            Label lblPrice = new Label
            {
                Text = item.Price.ToString(),
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
                Location = new Point(270, 10),
                Font = new Font("Segoe UI", 8)
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
                Location = new Point(200, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)


            };

            btnDecrement.Click += (s, e) => DecrementCartItem(item, lblQty, guna2Panel);


            //====================>
            // Add controls
            guna2Panel.Controls.Add(pictureBox);
            guna2Panel.Controls.Add(lblTitle);
            guna2Panel.Controls.Add(lblQty);
            guna2Panel.Controls.Add(lblSize);
            guna2Panel.Controls.Add(lblDesc);
            guna2Panel.Controls.Add(btnDelete);
            guna2Panel.Controls.Add(btnDecrement);
            guna2Panel.Controls.Add(lblPrice);
            flowLayoutPanel1.Controls.Add(guna2Panel);
            Payment();
        }


        //===========================================>


        public void RemoveCartItem(CartItem item, Guna2Panel panel)
        {
            SharedCart.Items.Remove(item);
            flowLayoutPanel1.Controls.Remove(panel);
            Payment();
        }
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


        public void RefreshCartUI()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in SharedCart.Items)
            {
                AddCartCard(item);
            }
            Payment();

        }

        //=================================================>


        public string Subtotals { get; set; }
        public string Totals { get; set; }
        public decimal subtotal = 0;
        public decimal tax = 0;
        public decimal total = 0;



        public void Payment()
        {
            subtotal = 0;

            foreach (var item in SharedCart.Items)
            {
                if (decimal.TryParse(item.Price, out decimal price))
                {
                    subtotal += price * item.qty;
                }
            }

            tax = subtotal * 0.10m; // 10% tax
            total = subtotal - tax;

            Subtotals = subtotal.ToString("0.00");
            Totals = total.ToString("0.00");

            Subtotal.Text = $"${Subtotals}";
            Tax.Text = $"${tax:0.00}";
            Total.Text = $"${Totals}";
        }





        //=================================================>



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
            SessionClass.CurrentCustomerId = 0;

            if (SharedCart.Items.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }

            Transaction t = new Transaction(SharedCart.Items);
            t.ShowDialog();

        }





        internal void RemoveCartItem(CartItem existingItem)
        {
            throw new NotImplementedException();
        }

        private void btnDinin_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.dine_in = "Dine-in";
            }

            MessageBox.Show("Order type set to Dine-in.");
        }

        private void btnpayLater_Click(object sender, EventArgs e)
        {
            foreach (var item in SharedCart.Items)
            {
                item.dine_in = "Pay Later";
            }

            MessageBox.Show("Order type set to Dine-in.");
        }
    }
}
