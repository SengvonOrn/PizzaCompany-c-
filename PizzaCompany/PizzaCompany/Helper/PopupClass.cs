using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    public class PopupClass
    {
        private Timer slideTimer = new Timer();
        private bool isPanelVisible = false;
        private int slideSpeed = 40;
        private int hiddenX = 1188;        // Start a bit off-screen
        private int visibleX = 20;         // Stick here when shown
        private Guna2Panel popupPanel;

        public PopupClass(Guna2Panel popup)
        {
            this.popupPanel = popup;
            slideTimer.Interval = 10;
            slideTimer.Tick += SlidePanel;

            // Start position is hidden
            popupPanel.Location = new Point(hiddenX, popupPanel.Location.Y);
        }

        public void SlidePanel(object sender, EventArgs e)
        {
            int currentX = popupPanel.Location.X;
            int targetX = isPanelVisible ? visibleX : hiddenX;

            // Sliding right (showing)
            if (isPanelVisible && currentX < targetX)
            {
                popupPanel.Location = new Point(currentX + slideSpeed, popupPanel.Location.Y);
            }
            // Sliding left (hiding)
            else if (!isPanelVisible && currentX > targetX)
            {
                popupPanel.Location = new Point(currentX - slideSpeed, popupPanel.Location.Y);
            }
            else
            {
                popupPanel.Location = new Point(targetX, popupPanel.Location.Y);
                slideTimer.Stop();
            }
        }


        public void TogglePopupVisibility()
        {
            isPanelVisible = !isPanelVisible;
            slideTimer.Start();
        }
     

    }
}
