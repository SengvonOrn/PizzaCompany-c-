using System;
using System.Collections;
using System.Drawing;
using System.IO;
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
            this.Close();
        }



        public int id = 0;
      



        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO productManagement(pName, pCategory, pPrice, pSize, pGroup, pImage, command) VALUES(@pName, @pCategory, @pPrice, @pSize, @pGroup, @pImage, @command)";
            }
            else
            {
                qry = "UPDATE productManagement SET pName = @pName, pCategory = @pCategory, pPrice = @pPrice, pSize = @pSize, pGroup = @pGroup,  pImage =  @pImage, command = @command WHERE pId = @id";
            }

            // for image ===================>

            Image temp = new Bitmap(pImageSet.Image);
            MemoryStream memoryStream = new MemoryStream();
            temp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = memoryStream.ToArray();

            //===============================>

            // Create and populate parameters
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@pName", pName.Text);
            ht.Add("@pCategory", pCategory.Text);
            ht.Add("@pPrice", pPrice.Text);
            // If "Selected", treat it as no size selected
            string size = pSize.Text == "Selected" ? "" : pSize.Text;
            ht.Add("@pSize", size);
            string group = pGroup.Text == "Selected" ? "" : pGroup.Text;
            ht.Add("@pGroup", pGroup.Text); // Fixed capital letter
            ht.Add("@pImage", imageByteArray);
            ht.Add("@command", cmd.Text);

            // Execute query
            if (MainClass.SQL(qry, ht) > 0)
            {
                MessageBox.Show("Saved successfully");
                id = 0;
                pCategory.SelectedIndex = 0;
                pPrice.Text = "";
                pSize.Text = "";
                cmd.Text = "";
                pGroup.SelectedIndex = 0;
                pImageSet.Image = Properties.Resources.product_photo;
                pName.Focus();
            }

            id = 0;
        }







        private void mProductForm_Load(object sender, EventArgs e)
        {


      

        }




        string filePath;
        byte[] imageByteArray;
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





        private void pCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear previous items to avoid duplication
            pGroup.Items.Clear();
            pSize.Items.Clear();

            if (pCategory.SelectedItem != null && pCategory.SelectedItem.ToString() == "Pizza")
            {
                pGroup.Items.Add("Selected");
                pGroup.Items.Add("classic pizza");
                pGroup.Items.Add("deluxe pizza");
                pGroup.Items.Add("seafood Deluxe");

                pSize.Items.Add("selected");
                pSize.Items.Add("6");
                pSize.Items.Add("9");
                pSize.Items.Add("12");

                pGroup.SelectedIndex = 0; 
                pSize.SelectedIndex = 0;  
            }
            if (pCategory.SelectedItem != null && pCategory.SelectedItem.ToString() == "Beverage")
            {
                pGroup.Items.Add("Selected");
                pGroup.Items.Add("soft drink && water");
                pGroup.Items.Add("Alcohol");           
                pSize.Items.Add("Selected");     
                
                pGroup.SelectedIndex = 0;
                pSize.SelectedIndex = 0;
            }
            if (pCategory.SelectedItem != null && pCategory.SelectedItem.ToString() == "Checken")
            {
                pSize.Items.Add("Selected");
                pSize.Items.Add("10");
                pSize.Items.Add("6");
                pGroup.Items.Add("Selected");
                pSize.SelectedIndex = 0;
                pGroup.SelectedIndex = 0;

            } ;
        }


    }
}
