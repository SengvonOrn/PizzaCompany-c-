using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
namespace PizzaCompany.Model
{
    public partial class mProductForm : SampleAddForm
    {
        public mProductForm()
        {
            InitializeComponent();
        }
        public override void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "INSERT INTO productManagement(pName, pCategory, pPrice) VALUES(@pName, @pCategory, @pPrice)";
            }
            else
            {
                qry = "UPDATE productManagement SET pName = @pName, pCategory = @pCategory, pPrice = @pPrice WHERE pId = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@pName", pName.Text);
            ht.Add("@pCategory", pCategory.Text);
            ht.Add("@pPrice", pPrice.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                pName.Focus();
            }
        }
        private void mProductForm_Load(object sender, EventArgs e)
        {
        }
        string filePath;
        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg, *.png)|*.jpg;*.png"; 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                pImageSet.Image = new Bitmap(filePath);
            }
        }

    }
}
