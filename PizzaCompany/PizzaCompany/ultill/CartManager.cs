

using Guna.UI2.WinForms;
using PizzaCompany.Model;
using System.Windows.Forms;

namespace PizzaCompany.ultill
{
    public class CartManager
    {
        private FlowLayoutPanel flowLayoutPanel;
        public void UpdateCartCard(CartItem item)
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is Guna2Panel panel && panel.Tag is CartItem cartItem)
                {
                    if (cartItem.Name == item.Name && cartItem.Size == item.Size)
                    {
                        foreach (Control inner in panel.Controls)
                        {
                            if (inner is Label lbl && lbl.Name == "lblQty")
                            {
                                lbl.Text = "Qty: " + item.qty;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
