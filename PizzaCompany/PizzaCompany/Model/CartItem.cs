using System;
using System.Drawing;
namespace PizzaCompany.Model
{
  
        public class CartItem
        {
            public string pId {  get; set; }

            public string cCustomer {  get; set; }
            public string cPhone { get; set; }

            public string cAddress { get; set; }

            public string Name { get; set; }

            public string dine_in { get; set; } = "Dine-in";

            public string payment { get; set; } = "Pending";

            public string dese { get; set; }

            public string Price { get; set; }

           public decimal qty { get; set; }
           public string Size { get; set; }

           public byte[] ProductImage { get; set; }


           public string Crosst { get; set; }

           public string cityregion { get; set; }

           public string CR { get; set; }

           public string Post { get; set; }

           public string Dl { get; set; }

           public string Isc { get; set; }

          

           public string extention  { get; set; }
           public string suit  { get; set; }

           public string action { get; set; } = "good";

           public int DiscountPercent { get; set; }
        public void Clear()
        {
            pId = "";
            cCustomer = "";
            cPhone = "";
            cAddress = "";
            Name = "";
            dine_in = "Dine-in";
            payment = "Pending";
            dese = "";
            Price = "0";
            qty = 0;
            Size = "";
            ProductImage = null;
            Crosst = "";
            cityregion = "";
            CR = "";
            Post = "";
            Dl = "";
            Isc = "";
            extention = "";
            suit = "";
            action = "good";
            DiscountPercent = 0;
        }


    }
   
  }
