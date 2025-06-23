
using System;
using System.Drawing;
using System.IO;
using System.Windows;


namespace PizzaCompany.Model



{
    public class ProductModel
    {

        public  string pId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string qty { get; set; } 
        public string Price { get; set; } 

        public string Size { get; set; }
        public byte[] ImageBytes { get; set; }

        public string command  { get; set; }



    }
}
