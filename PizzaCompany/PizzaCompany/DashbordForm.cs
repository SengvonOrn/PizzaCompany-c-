using System;
using PizzaCompany.LoadingController;
using System.Windows.Forms;
using PizzaCompany.FormSidbarController;
namespace PizzaCompany
{
    public partial class DashbordForm : Form
    {
        public DashbordForm()
        {
            InitializeComponent();
            string u = MainClass.USER;
            user1.Text = u.TrimEnd(); 
        }
        //======for accessing everywhere =========>
        static DashbordForm _obj;
        public static DashbordForm Instance
        {
            get { if (_obj == null) { _obj = new DashbordForm();  } return _obj; }
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
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new Customer(), PanelContainer);
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            contform.AddControlsSidebar(new InventoryForm(), PanelContainer);

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
    }
   
}
