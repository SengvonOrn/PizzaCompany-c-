using System;
using PizzaCompany.LoadingController;
using System.Windows.Forms;
using PizzaCompany.FormSidbarController;
using PizzaCompany.LearnMore;
using PizzaCompany.Helper;

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

        private int notificationCount = 0;


        //PermissionForm permission = new PermissionForm();


        customerCheckOutform customer = new customerCheckOutform();

        
        public static DashbordForm Instance
        {
            get { if (_obj == null) { _obj = new DashbordForm(); } return _obj; }
        }


        //=============>
        FromController contform = new FromController();
        public void backDashboard()
        {
            contform.AddControlsSidebar(new Dashboard(), PanelContainer);
        }
        public void DashbordForm_Load(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new Dashboard(), PanelContainer);
            _obj = this;
     
        }
        //================>
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new Dashboard(), PanelContainer);

        }


        //===============>


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new customerManagement(), PanelContainer);
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
             MessageBox.Show("I'm sorry for this option, we spend our the time on this option just for money 😢. ");
            //contform.AddControlsSidebar(new InventoryForm(), PanelContainer);

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
    } 
    }
       