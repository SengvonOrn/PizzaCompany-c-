using System;
using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    public static class ControlHelper
    {
        public static void MakePanelFullyClickable(Control panel, EventHandler onClick)
        {
            panel.Click += onClick;

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button) continue; // Skip buttons
                ctrl.Click += onClick;
            }
        }
    }
}
