

using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

    public class Order
    {
        public AStore Store { get; set; }

        public Customer Customer { get; set; }

        public APizza Pizza { get; set; }


        public override string ToString()
        {
            return $"{Store.Name} + {Pizza.Crust.Name} + ";
        }
        public void Save()
        {

        }
    }
}