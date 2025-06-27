using System;

using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    public partial class TimeClock : Form
    {
        private readonly RealTimeClock rtc;

        public TimeClock()
        {
            InitializeComponent();


            rtc = new RealTimeClock();
            rtc.AttachClock(dateTime);
            dates.Text = DateTime.Now.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
