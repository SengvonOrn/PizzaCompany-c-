using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PizzaCompany.LoadingController
{
    public class FromController
    {

        //======For Controller Sidbar=========>
        public void AddControlsSidebar(Form f, Panel targetPanel)
        {
            targetPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            targetPanel.Controls.Add(f);
            f.Show();

        }


        //=======For Contoroller MenuBar=====>

        public void AddMenuControls(Form form, Panel targetoPanel)
        {
            targetoPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Size = targetoPanel.ClientSize;
            form.Dock = DockStyle.None;
            targetoPanel.Controls.Add(form);
            form.Show();
        }


     
    }
}
