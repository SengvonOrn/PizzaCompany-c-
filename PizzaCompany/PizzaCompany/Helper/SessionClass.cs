using System;
using System.Windows.Forms;

namespace PizzaCompany.Helper
{
    internal class SessionClass
    {
        public static int CurrentCustomerId { get; set; }

        public struct customet
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Phone { get; set; }

            public string Address { get; set; }

        }
    }
}
