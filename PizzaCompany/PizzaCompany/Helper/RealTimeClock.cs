using System;
using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    public class RealTimeClock
    {
        private Timer timer;
        private Label clockLabel;

        public void AttachClock(Label label)
        {
            clockLabel = label;

            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(UpdateClock);
            timer.Start();
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


    }
}
