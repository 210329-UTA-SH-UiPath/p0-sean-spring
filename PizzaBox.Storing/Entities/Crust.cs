using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    public partial class Crust
    {
        public Crust()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int CrustId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
