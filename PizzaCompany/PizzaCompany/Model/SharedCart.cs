
using System.Collections.Generic;
namespace PizzaCompany.Model
{
    public static class SharedCart
    {
        public static List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
