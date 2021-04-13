using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Storing.Entities
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaToppings = new HashSet<PizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
