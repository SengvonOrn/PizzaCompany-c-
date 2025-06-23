using System;
using System.Windows.Forms;
namespace PizzaCompany.FormSidbarController
{
    public partial class OrderManagementForm : Form
    {
        public OrderManagementForm()
        {
            InitializeComponent();
          
        }
        private DateTime? _selectedDate = null;


        private string _selectedFilterType = "";


        private string _customerSearch = "";

        private bool _onlyUnpaid = false;
        private bool _mycarryout = false;
        private bool _mydelivery = false;
        private bool _mydinein = false;
        private bool _mysuccess = false;

        private string _orderBy = "o.CreatedAt DESC";
        public void GetData(
                string filterType = null,
                DateTime? selectedDate = null,
                string customerSearch = null,
                bool? onlyUnpaid = null,
                bool? carryOut = null,
                bool? delivery = null,
                bool? mydinein = null,
                bool? mysuccess = null,
                string orderBy = null
                )
           {
            _selectedFilterType = filterType ?? _selectedFilterType;



            _selectedDate = selectedDate ?? _selectedDate;
            _customerSearch = customerSearch ?? _customerSearch;
            _onlyUnpaid = onlyUnpaid ?? _onlyUnpaid;
            _mycarryout = carryOut ?? _mycarryout;
            _mydelivery = delivery ?? _mydelivery;
            _mydinein = mydinein ?? _mydinein;
            _mysuccess = mysuccess ?? _mysuccess;
            _orderBy = orderBy ?? _orderBy;
            string dateCondition = "WHERE 1=1";




            if (_selectedDate.HasValue)
            {
                dateCondition += $" AND CAST(o.CreatedAt AS DATE) = '{_selectedDate.Value:yyyy-MM-dd}'";
            }
            else
            {
                if (_selectedFilterType == "Today")
                {
                    dateCondition += " AND CAST(o.CreatedAt AS DATE) = CAST(GETDATE() AS DATE)";
                }
                else if (_selectedFilterType == "Weekend")
                {
                    dateCondition += " AND o.CreatedAt >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";
                    dateCondition += " AND o.CreatedAt < DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";
                }
                else if (_selectedFilterType == "Month")
                {
                    dateCondition += " AND MONTH(o.CreatedAt) = MONTH(GETDATE()) AND YEAR(o.CreatedAt) = YEAR(GETDATE())";
                }
                else if (_selectedFilterType == "Year")
                {
                    dateCondition += " AND YEAR(o.CreatedAt) = YEAR(GETDATE())";
                }



            }







            if (!string.IsNullOrEmpty(_customerSearch))
            {
                dateCondition += $" AND c.cName LIKE '%{_customerSearch.Replace("'", "''")}%' ";

            }









            if (_onlyUnpaid)
            {
                dateCondition += " AND o.payment = 'Pending'";
            }
            if (_mycarryout)
            {
                dateCondition += " AND o.DineType = 'CarryOut'";
            }
            if (_mydelivery)
            {
                dateCondition += " AND o.DineType = 'Delivery'";
            }
            if (_mydinein)
            {
                dateCondition += " AND o.DineType = 'Dine-in'";
            }
            if (_mysuccess)
            {
                dateCondition += " AND o.payment = 'Success'";
            }






            //===> Selection with condition

            string sql = $@"
            SELECT 
            o.oId,
            c.cName, 
            c.cPhone, 
            p.pName,  
            p.pCategory,  
            p.pPrice,  
            o.Quantity,  
            o.Size,
            o.payment,
            o.DineType, 
            o.Subtotal, 
            o.CreatedAt,
            CONCAT(
                DATEDIFF(MINUTE, c.CreatedAt, o.CreatedAt) / 60, ' hr /',
                DATEDIFF(MINUTE, c.CreatedAt, o.CreatedAt) % 60, ' mn'
            ) AS OverTimeFormatted,
            o.Action

            FROM OrderTable o 
            JOIN Custmer c ON o.cId = c.cId 
            JOIN productManagement p ON o.pId = p.pId 
            {dateCondition}
            ORDER BY {_orderBy};
            ";




            //==> Populate ListBox and grid

            ListBox lb = new ListBox();
            lb.Items.Add(oId);
            lb.Items.Add(customer);
            lb.Items.Add(phone);
            lb.Items.Add(pName);
            lb.Items.Add(pItems);
            lb.Items.Add(price);
            lb.Items.Add(qty);
            lb.Items.Add(size);
            lb.Items.Add(payment);
            lb.Items.Add(status);
            lb.Items.Add(sbt); 
            lb.Items.Add(datetime);
            lb.Items.Add(overtime);
            lb.Items.Add(order);

            MainClass.LoadingData(sql, guna2DataGridView1, lb);

            //==>  Check Order Count ==================>

        string countSql = $@"
        SELECT COUNT(*) 
        FROM OrderTable o 
        JOIN Custmer c ON o.cId = c.cId 
        JOIN productManagement p ON o.pId = p.pId 
        {dateCondition};";
        totalorder.Text = $"Total: {MainClass.GetOrderCount(countSql)} -";

            //==>

        int thisWeekCount = MainClass.GetOrderCount(@"
        SELECT COUNT(*) FROM OrderTable
        WHERE DATEPART(WEEK, CreatedAt) = DATEPART(WEEK, GETDATE())
        AND DATEPART(YEAR, CreatedAt) = DATEPART(YEAR, GETDATE());");

            //==>

        int lastWeekCount = MainClass.GetOrderCount(@"
        SELECT COUNT(*) FROM OrderTable
        WHERE DATEPART(WEEK, CreatedAt) = DATEPART(WEEK, GETDATE()) - 1
        AND DATEPART(YEAR, CreatedAt) = DATEPART(YEAR, GETDATE());");

            //==>

            double percentageChange = lastWeekCount > 0 ? ((double)(thisWeekCount - lastWeekCount) / lastWeekCount) * 100 : 0;
            ThisWeek.Text = $"This Week: {thisWeekCount} Orders";
            LastWeek.Text = $"Last Week: {lastWeekCount} Orders";
            Growth.Text = $"Growth: {percentageChange:+0.00;-0.00;0}%";


            //==> 


            string overtimeItemCountSql = $@"
        SELECT COUNT(o.oId)
        FROM OrderTable o
        JOIN Custmer c ON o.cId = c.cId
        {dateCondition.Replace("WHERE 1=1", "")}
        AND DATEDIFF(MINUTE, c.CreatedAt, o.CreatedAt) > 5;";

            int overtimeItemCount = MainClass.GetOrderCount(overtimeItemCountSql);



            lblItemsovertime.Text = $"Total: {overtimeItemCount} -";

            //===>

            string totalOrderCountSql = $@"
        SELECT COUNT(*)
        FROM OrderTable o
        JOIN Custmer c ON o.cId = c.cId
        JOIN productManagement p ON o.pId = p.pId
        {dateCondition};";
            int totalOrderCount = MainClass.GetOrderCount(totalOrderCountSql);


            //==> 


            double overtimePercentage = 0;

            if (totalOrderCount > 0)
            {
                overtimePercentage = ((double)overtimeItemCount / totalOrderCount) * 100;
            }
            lblOvertimePercentage.Text = $"This Week: {overtimePercentage:0.00}%"; // Format to 2 decimal places


            //==> 


        string overtimeMinutesSql = $@"
        SELECT ISNULL(SUM(DATEDIFF(MINUTE, c.CreatedAt, o.CreatedAt)), 0)
        FROM OrderTable o
        JOIN Custmer c ON o.cId = c.cId
        {dateCondition.Replace("WHERE 1=1", "")}
        AND DATEDIFF(MINUTE, c.CreatedAt, o.CreatedAt) > 5;";


            int totalOvertimeMinutes = (int)MainClass.GetScalarValue(overtimeMinutesSql);
            int hours = totalOvertimeMinutes / 60;
            int minutes = totalOvertimeMinutes % 60;
            lblOvertimeSummary.Text = $"Over time: {hours} hours ";
            minute.Text = $"Minute: {minutes}min";



            //===>

        string returnsOrderItemsbad = $@"
        SELECT COUNT(*)
        FROM OrderTable o
        JOIN Custmer c ON o.cId = c.cId
        WHERE o.Action = 'bad' {dateCondition.Replace("WHERE", "AND")}
        ";
            int returnCountbad = MainClass.GetOrderCount(returnsOrderItemsbad);
            lblreturn.Text = $"Total: {returnCountbad}-";



            string returnsOrderItemsgood = $@"
        SELECT COUNT(*)
        FROM OrderTable o
        JOIN Custmer c ON o.cId = c.cId
        WHERE o.Action = 'good' {dateCondition.Replace("WHERE", "AND")}
        ";
            int returnCountgood = MainClass.GetOrderCount(returnsOrderItemsgood);

            int total = returnCountbad + returnCountgood;

            double badPercentage = total > 0 ? (returnCountbad * 100.0) / total : 0;
            returnpercentage.Text = $"This Week: {badPercentage:F2}%";


            string badOrdersSql = $@"SELECT ISNULL(SUM(Subtotal), 0)  FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.Action = 'bad' {dateCondition.Replace("WHERE", "AND")}";

            decimal badOrders = Convert.ToDecimal(MainClass.GetScalarValue(badOrdersSql));

            label7.Text = $"Price: {badOrders:N2}";



            //===================================>




            string totalOrdersSql = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId {dateCondition}";
            int totalOrders = MainClass.GetOrderCount(totalOrdersSql);


            string unpaidOrdersSql = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.payment = 'Pending' {dateCondition.Replace("WHERE", "AND")}";
            int unpaidOrders = MainClass.GetOrderCount(unpaidOrdersSql);
            decimal unpaidPercentage = totalOrders > 0 ? ((decimal)unpaidOrders / totalOrders) * 100 : 0;



            string goodOrdersSql = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.Action = 'good' {dateCondition.Replace("WHERE", "AND")}";
            int goodOrders = MainClass.GetOrderCount(goodOrdersSql);
            decimal goodPercentage = totalOrders > 0 ? ((decimal)goodOrders / totalOrders) * 100 : 0;




            unpaid.Text = $"Unpaid: {unpaidOrders} ({unpaidPercentage:F2}%)";

            //  bad.Text = $"Bad Orders: {returnCountbad} ({badPercentage:F2}%)";


            // Amount Calculations


            string totalAmountSql = $@"SELECT ISNULL(SUM(Subtotal), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId {dateCondition}";
            decimal totalAmount = Convert.ToDecimal(MainClass.GetScalarValue(totalAmountSql));




            string unpaidAmountSql = $@"SELECT ISNULL(SUM(Subtotal), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.DineType = 'Pay Later' {dateCondition.Replace("WHERE", "AND")}";
            decimal unpaidAmount = Convert.ToDecimal(MainClass.GetScalarValue(unpaidAmountSql));


            decimal netRevenuecalculate = totalAmount - unpaidAmount;
            decimal getNetsale = netRevenuecalculate - badOrders;



            decimal taxRate = 0.10m;
            decimal taxAmount = getNetsale * taxRate;
            decimal finalRevenue = getNetsale - taxAmount;


            amounttotalPrice.Text = $"Sale: ${getNetsale:N2}";





            label2.Text = $"Net Sale (After 10% Tax): ${finalRevenue:N2}";



            decimal netSalePercentage = totalAmount > 0 ? (getNetsale / totalAmount) * 100 : 0;
            thisweeksale.Text = $"This Week: {netSalePercentage:F2}%";


            decimal affectedPercentage = totalAmount > 0 ? ((unpaidAmount + badOrders) / totalAmount) * 100 : 0;
            Affected.Text = $"Affected: {affectedPercentage:F2}%";



        }

        //=============================>

        private void searchOrder_TextChanged(object sender, EventArgs e)
        {
            _customerSearch = searchOrder.Text.Trim();
            GetData();
        }




        private void btnSchedul_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedFilterType = btnSchedul.SelectedItem?.ToString() ?? "";
            GetData();
        }








        private void btnDatetime_ValueChanged(object sender, EventArgs e)
        {
            _selectedDate = btnDatetime.Value.Date;
            _onlyUnpaid = false;
            GetData();
        }




        private void btnAll_Click(object sender, EventArgs e)
        {
            searchOrder.Text = "";
            btnSchedul.SelectedIndex = 0;
            btnDatetime.Checked = false;
        

            _selectedDate = null;
            _selectedFilterType = "Selected";
            _onlyUnpaid = false;
            _mycarryout = false;
            _mydelivery = false;
            _mydinein = false;
            _mysuccess = false;
            _customerSearch = "";
            _orderBy = "o.CreatedAt DESC";

            GetData();
        }





        public DateTime DateTime { get; set; }
        private void btnUnpaid_Click(object sender, EventArgs e)
        {

            _onlyUnpaid = true;
            _mycarryout = false;
            _mydelivery = false;
            _mydinein = false;
            _mysuccess = false;
            GetData();

        }
        private void btnCarryOut_Click(object sender, EventArgs e)
        {
            _mycarryout = true;
            _onlyUnpaid = false;
            _mydelivery = false;
            _mydinein = false;
            _mysuccess = false;

            GetData();
        }
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            _mydelivery = true;
            _onlyUnpaid = false;
            _mycarryout = false;
            _mydinein = false;
            _mysuccess = false;
            GetData();

        }
        private void btndinein_Click(object sender, EventArgs e)
        {
            _mydinein = true;
            _mydelivery = false;
            _onlyUnpaid = false;
            _mycarryout = false;
            _mysuccess = false;

            GetData();
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            _mysuccess = true;
            _mydinein = false;
            _mydelivery = false;
            _onlyUnpaid = false;
            _mycarryout = false;

            GetData();

        }






        bool isCustomerAsc = true;
        private void btnAZ_Click(object sender, EventArgs e)
        {
            string a_to_z = isCustomerAsc ? "c.cName ASC" : "c.cName DESC";
            isCustomerAsc = !isCustomerAsc;
            GetData(orderBy: a_to_z);
        }



        bool isPriceAsc = true;
        private void btnSortBy_Click(object sender, EventArgs e)
        {
            string orderBy = isPriceAsc ? "p.pPrice ASC" : "p.pPrice DESC";
            isPriceAsc = !isPriceAsc;
            GetData(orderBy: orderBy);
        }

   


        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

            GetData();
            //Hover.ColorActionCells(guna2DataGridView1);
            searchOrder.Text = "";
            btnSchedul.SelectedIndex = 0;
            btnDatetime.Checked = false;
            btnDatetime.Value = DateTime.Today;
     
            GetData(selectedDate: btnDatetime.Value.Date);
            btnAll.Checked = false;
         

        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

            if (guna2DataGridView1 == null || guna2DataGridView1 == null)
                return;
            string columnName = guna2DataGridView1.CurrentCell.OwningColumn.Name;

            if (columnName == "order")
            {

            int id =   Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["oId"].Value);

            MainClass.UpdateAction(id);
            GetData();

            //Hover.ColorActionCells(guna2DataGridView1);


            }

        }

 
    }
}
