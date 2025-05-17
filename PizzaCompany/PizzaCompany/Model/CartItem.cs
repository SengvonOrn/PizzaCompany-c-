using System.Drawing;
namespace PizzaCompany.Model
{
  
        public class CartItem
        {
            public Image ProductImage { get; set; }
            public string cCustomer {  get; set; }
            public string cPhone { get; set; }

            public string cAddress { get; set; }

            public string cStreet { get; set; }

            public string Name { get; set; }

            public string dine_in { get; set; } = "Dine-in";
            public string dese { get; set; }

            public string Price { get; set; }

           public decimal qty { get; set; }
           public int Size { get; set; }

        //=================>
    }
    
}
