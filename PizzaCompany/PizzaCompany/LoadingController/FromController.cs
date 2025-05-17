using System.Windows.Forms;

namespace PizzaCompany.LoadingController
{
    public class FromController
    {

        //===============>
        public void AddControlsSidebar(Form f, Panel targetPanel)
        {
            targetPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            targetPanel.Controls.Add(f);
            f.Show();

        }


        //============>

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
