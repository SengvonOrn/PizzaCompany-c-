using PizzaCompany.Helper;
using PizzaCompany.Model;
using PizzaCompany.ultill;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Linq;
using System.Data;
using System.IO;
namespace PizzaCompany.FormSidbarController
{
    public partial class ReportAnalytics : Form
    {
        public ReportAnalytics()
        {
            InitializeComponent();
            PopulerProducts();
            LoadDataFromDatabase();
           
        }

        //==================== Populer Product ===================>
        MainClass mainClass = new MainClass();
        public void PopulerProducts()
        {

            flowLayoutPanel1.Controls.Clear();

            List<ProductModel> products = mainClass.PopulerProducts();

            foreach (var product in products)
            {

                Rating ratingHelper = new Rating();
                
                int getqty_Byname =  mainClass.CountPopuler(product.Name);
                double sumPrice = Convert.ToDouble(product.Price) * getqty_Byname;
                decimal khr = Convert.ToDecimal(sumPrice);


                string shortKhr = formatMoney.ConvertUsdToKM(khr);
                int getratting = ratingHelper.GetRatingByKhr(khr);
                // Create a new Guna2Panel
                Guna.UI2.WinForms.Guna2Panel productPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(413, 90),
                    FillColor = Color.LightBlue,
                    Margin = new Padding(5),
                    BorderRadius = 4,
                    BorderThickness = 1,
                    BorderColor = Color.White,
                };


                //=====>


                ConvertToImage convertTo = new ConvertToImage();
                Guna.UI2.WinForms.Guna2PictureBox gunaPictureBox = new Guna.UI2.WinForms.Guna2PictureBox
                {
                    Image = convertTo.Imageconvert(product.ImageBytes) ?? Properties.Resources.edit,
                    FillColor = Color.White,
                    Size = new Size(50, 50),
                    Location = new Point(12, 12),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    BorderRadius = 6,
                    ShadowDecoration = { Parent = null }
                };


                //=============>

                // Product name
                Label productName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Location = new Point(95, 22),
                    Size = new Size(180, 20),
                    AutoSize = false,
                    AutoEllipsis = true,
                };


                Label price = new Label
                {
                    Text = $"${product.Price:0.00}", // Formats to two decimal places
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Blue,
                    BackColor = Color.Transparent,
                    Location = new Point(95, 50),
                    AutoSize = true
                };


                // dividual

                Label between = new Label

                {
                    Text = "/",
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    Location = new Point(145, 50),
                    AutoSize = true
                };


                // Star rating
                Panel starsPanel = new Panel
                {
                    Size = new Size(200, 30),
                    Location = new Point(153, 43),
                    BackColor = Color.Transparent,
                };
                //this.Controls.Add(starsPanel);
                ratingHelper.SetRating(getratting, starsPanel);




                //Icon circle and sold count
                Guna.UI2.WinForms.Guna2PictureBox icon = new Guna.UI2.WinForms.Guna2PictureBox
                {
                    Size = new Size(30, 30),
                    Location = new Point(300, 18),
                    BackColor = Color.Transparent,
                    FillColor = Color.FromArgb(55, 100, 200),
                    ImageRotate = 0F,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.sold_out
                };



                Label soldLabel = new Label
                {
                    Text = $"Sold {shortKhr}",
                    Font = new Font("Segoe UI", 9),
                    BackColor = Color.Transparent,
                    ForeColor = System.Drawing.Color.Black,
                    Location = new Point(330, 26),
                    AutoSize = true
                };

                // Add all controls to the panel
                productPanel.Controls.Add(gunaPictureBox);
                productPanel.Controls.Add(productName);
                productPanel.Controls.Add(price);
                productPanel.Controls.Add(starsPanel);
                productPanel.Controls.Add(between);
                productPanel.Controls.Add(icon);
                productPanel.Controls.Add(soldLabel);
                flowLayoutPanel1.Controls.Add(productPanel);

            }
        }


        //========================Get All Data==================>

        private string _selectFileType = "";
        private decimal finalRevenue = 0;
        private List<DataPointModel> allData;
        public void getData(string selected = null)
        {

            _selectFileType = selected ?? _selectFileType;
            string condition = "WHERE 1=1";

            if(_selectFileType == "Daily")
            {
                // o.CreatedAt between '2025-06-07 00:00:00' and '2025-06-07 23:59:59'
                condition += " AND CAST(o.CreatedAt AS DATE) = CAST(GETDATE() AS DATE)"; 

            }
            else if(_selectFileType == "Weekly")
            {
                // Monday, June 3 → Sunday, June 9  ||  o.CreatedAt BETWEEN [start of week] AND [end of week] using DATEPART()
                condition += " AND o.CreatedAt >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";
                condition += " AND o.CreatedAt < DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";


            }
            else if (_selectFileType == "Monthly")
            {
                condition += " AND MONTH(o.CreatedAt) = MONTH(GETDATE()) AND YEAR(o.CreatedAt) = YEAR(GETDATE())";
            }

            //===get all for sale and SubTotal chart=======>


            string subTotalAmountSql = $@"SELECT ISNULL(SUM(Subtotal), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE (o.payment = 'Success' OR o.Action = 'good')AND o.payment != 'Pending' {condition.Replace("WHERE", "AND")}";
            decimal subtotalAmount = Convert.ToDecimal(MainClass.GetScalarValue(subTotalAmountSql));


            //== Get all for sale Total and chart ========>


            string TotalAmountSql = $@"SELECT ISNULL(SUM(Total), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE (o.payment = 'Success' OR o.Action = 'good')AND o.payment != 'Pending' {condition.Replace("WHERE", "AND")}";
            finalRevenue = Convert.ToDecimal(MainClass.GetScalarValue(TotalAmountSql));

            decimal getTotalAmountExpent = subtotalAmount - finalRevenue;

            ValuesSet.Text = $"Sale: ${subtotalAmount:F}";
            netsale.Text = $"Net sale: ${finalRevenue:F}";




            //=======Purchase===================>

            string countSql = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId  WHERE (o.Action = 'good' OR o.payment = 'Success')AND o.payment != 'Pending' {condition.Replace("WHERE", "AND")}";
            decimal purchasesum = MainClass.GetOrderCount(countSql);
            purchaseSummary.Text = $"Count: {purchasesum} -";


            getTotalpurchas.Text = $"${finalRevenue:F}";
            decimal netSalePercentage = finalRevenue > 0 ? (purchasesum /  finalRevenue) * 100 : 0;
            purchasePersontage.Text = $"Average: {netSalePercentage:F}%";


            //=======Expense================>



            string countExpand = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE (o.Action = 'bad' OR o.payment = 'Pending')AND o.payment != 'Success' {condition.Replace("WHERE", "AND")}";
            decimal getcountExpand = Convert.ToDecimal(MainClass.GetScalarValue(countExpand));
      
             string Expens = $@"SELECT ISNULL(SUM(Subtotal), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE (o.Action = 'bad' OR o.payment = 'Pending')AND o.payment != 'Success' {condition.Replace("WHERE", "AND")}";
             decimal getExpenExpand = Convert.ToDecimal(MainClass.GetScalarValue(Expens));

             decimal getExpens = getExpenExpand + getTotalAmountExpent;

            label16.Text = $"${getExpenExpand:F}";

            decimal averageExpens = getExpens > 0 ? (getcountExpand / getExpens)  * 100 : 0;

            Average_expsum.Text = $"Average: {averageExpens:F}%";



            //======Sale and Dicount===========>



            getnetsale.Text =  $"${subtotalAmount:F}";
            dicount.Text = $"${getTotalAmountExpent:F}";

            decimal getAverage_s_d = getTotalAmountExpent > 0 ? (purchasesum / getTotalAmountExpent) * 100 : 0 ;
            sale_disc_avr.Text = $"Average: {getAverage_s_d:F}%";




            //========Dues and Pending==================>


            string dues  = $@"SELECT COUNT(*) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.payment = 'Pending' {condition.Replace("WHERE", "AND")}";
            decimal getdues = Convert.ToDecimal(MainClass.GetScalarValue(dues));
            setDues.Text = $"Total: {getdues}";



            string pending = $@"SELECT ISNULL(SUM(Subtotal), 0) FROM OrderTable o JOIN Custmer c ON o.cId = c.cId WHERE o.payment = 'Pending' {condition.Replace("WHERE", "AND")}";
            decimal getPending = Convert.ToDecimal(MainClass.GetScalarValue(pending));
            pendingSummary.Text = $"${getPending:F}";


            decimal getPedingAvr = getPending > 0 ? (getdues / getPending) * 100 : 0;

            pendAvr.Text = $"Average: {getPedingAvr:F}%";



         //=======Customer=================>



            string Customer = $@"SELECT COUNT(*) FROM Custmer c JOIN OrderTable o ON c.cId = o.cId {condition.Replace("WHERE", "AND")}";
            decimal getCustomer = Convert.ToDecimal(MainClass.GetScalarValue(Customer));
            customer.Text = $"Total: {getCustomer}";
            custExpens.Text = $"${finalRevenue:F}";
            decimal getAvr = finalRevenue > 0 ? getCustomer / finalRevenue : 0 ;
            cusAvr.Text = $"Average: {getAvr:F}%";


           
        }
        //=============== laoding to chart=============>

        private void LoadDataFromDatabase()
        {
            allData = new List<DataPointModel>();

            // Start with a safe always-true condition
            string condition = "1=1";

            if (_selectFileType == "Daily")
            {
                condition += " AND CAST(o.CreatedAt AS DATE) = CAST(GETDATE() AS DATE)";
            }
            else if (_selectFileType == "Weekly")
            {
                condition += " AND o.CreatedAt >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";
                condition += " AND o.CreatedAt < DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))";
           
            }
            else if (_selectFileType == "Monthly")
            {
                condition += " AND MONTH(o.CreatedAt) = MONTH(GETDATE()) AND YEAR(o.CreatedAt) = YEAR(GETDATE())";
            }

            string sql = $@"
                            SELECT o.CreatedAt, o.Subtotal
                            FROM OrderTable o
                            JOIN Custmer c ON o.cId = c.cId
                            WHERE (o.payment = 'Success' OR o.Action = 'good')AND o.payment != 'Pending' AND {condition}";

            DataTable dt = MainClass.GetDataTableforchart(sql);
            foreach (DataRow row in dt.Rows)
            {
                allData.Add(new DataPointModel
                {
                    Date = Convert.ToDateTime(row["CreatedAt"]),
                    Value = Convert.ToDecimal(row["Subtotal"])
                });
            }
        }


        //=========Button event to trigger chart display=========>
        public void cmdEventbox()
        {
            _selectFileType = cmdanalysist.SelectedItem.ToString();

            getData(_selectFileType);         
            LoadDataFromDatabase();          

            Dictionary<string, decimal> groupedData = null;

            if (_selectFileType == "Daily")
            {
                groupedData = allData
                    .GroupBy(d => d.Date.Date)
                    .ToDictionary(g => g.Key.ToShortDateString(), g => g.Sum(x => x.Value));
            }
            else if (_selectFileType == "Weekly")
            {
               
                groupedData = allData
                 .GroupBy(d => d.Date.Date)
                 .ToDictionary(g => g.Key.ToShortDateString(), g => g.Sum(x => x.Value));
            }
            else if (_selectFileType == "Monthly")
            {
               
                groupedData = allData
                 .GroupBy(d => d.Date.Date)
                 .ToDictionary(g => g.Key.ToShortDateString(), g => g.Sum(x => x.Value));
            }

            DisplayChart(groupedData);
        }



        private void DisplayChart(Dictionary<string, decimal> groupedData)
        {
            chart1.Series.Clear();

            Series orderSeries = new Series("Analysis")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue,
                IsValueShownAsLabel = true
            };



            foreach (var item in groupedData)
            {
                orderSeries.Points.AddXY(item.Key, item.Value);
            }



            chart1.Series.Add(orderSeries);



            Series revenueSeries = new Series("Final Revenue")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green,
                IsValueShownAsLabel = true
            };

            revenueSeries.Points.AddXY("Final Revenue", finalRevenue);
          
           chart1.Series.Add(revenueSeries);
           chart1.ChartAreas[0].RecalculateAxesScale();
        }


        //==========================================================================>
        private void cmdanalysist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEventbox();
            getData();
        }

        private void ReportAnalytics_Load(object sender, EventArgs e)
        {
            cmdEventbox();
            getData();
            var area = chart1.ChartAreas[0];


            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            area.AxisX.LabelStyle.Angle = -45;  // Tilt X labels
            area.AxisX.LabelStyle.Interval = 1; // Show every label


            area.AxisX.LabelStyle.ForeColor = Color.Black;
            area.AxisY.LabelStyle.ForeColor = Color.Black;

        
        }
    }
}


