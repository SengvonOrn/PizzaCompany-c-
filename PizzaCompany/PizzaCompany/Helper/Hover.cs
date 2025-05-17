using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

public class Hover
{
    public void BtnToggle_MouseEnter(object sender, EventArgs e)
    {
        if (sender is Guna2Button btnToggle)
        {
            btnToggle.Location = new Point(1440, 369);
            btnToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggle.ShadowDecoration.Depth = 20;
            btnToggle.ShadowDecoration.Color = Color.Gray;
        }
    }

    public void BtnToggle_MouseLeave(object sender, EventArgs e)
    {
        if (sender is Guna2Button btnToggle)
        {
            btnToggle.Location = new Point(1445, 369);
            btnToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggle.ShadowDecoration.Depth = 10;
            btnToggle.ShadowDecoration.Color = Color.Black;
        }
    }


   
}
