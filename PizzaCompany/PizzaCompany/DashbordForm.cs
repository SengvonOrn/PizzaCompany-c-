using PizzaCompany.FormSidbarController;
using PizzaCompany.Helper;
using PizzaCompany.LoadingController;
using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PizzaCompany
{
    public partial class DashbordForm : Form
    {
      



        public DashbordForm()
        {
            InitializeComponent();
            string u = MainClass.USER;
     
            user1.Text = u.TrimEnd();
            role.Text = DateTime.Now.ToString("dd/MM/yyyy");
      

        }



        //======for accessing everywhere =========>
        static DashbordForm _obj;



        customerCheckOutform customer = new customerCheckOutform();

        
        public static DashbordForm Instance
        {
            get { if (_obj == null) { _obj = new DashbordForm(); } return _obj; }
        }


        //=============>
        FromController contform = new FromController();
        public void backDashboard()
        {
            contform.AddControlsSidebar(new HomePage(), PanelContainer);
        }
        public void DashbordForm_Load(object sender, EventArgs e)
        {

            contform.AddControlsSidebar(new HomePage(), PanelContainer);
            _obj = this;

        }
        //================>
    


        private void btnDashboard_Click(object sender, EventArgs e)
        {

            contform.AddControlsSidebar(new HomePage(), PanelContainer);

        }


        //===============>


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new customerManagement(), PanelContainer);
        }





        private OrderPage OrderPage;

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (OrderPage == null || OrderPage.IsDisposed)
            {
                OrderPage = new OrderPage();
            }

            if (OrderPage.WindowState == FormWindowState.Minimized)
            {
                OrderPage.WindowState = FormWindowState.Maximized;
            }

            OrderPage.BringToFront();
            OrderPage.Show();
        }


        private void btnOrderManages_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new OrderManagementForm(), PanelContainer);
        }

        private void btnUserManages_Click(object sender, EventArgs e)
        {

            contform.AddControlsSidebar(new UserManagementForm(), PanelContainer);

        }

        private void btnRep_Analy_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new ReportAnalytics(), PanelContainer);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new ProductManagement(), PanelContainer);

        }
        private void btnStock_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new StockProduct(), PanelContainer);
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }



        private void btnCheckOut_Click(object sender, EventArgs e)
        {


            MainClass.BlurBackround(new customerCheckOutform());

        }

        private void btnTimeClock_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackround(new TimeClock());

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //MainClass.BlurBackround(new  Thankyou());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizeBox_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

 
        }
    } 
    }
       