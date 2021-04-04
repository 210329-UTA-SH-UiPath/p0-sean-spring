using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{

    public class PepperoniPizza : APizza
    {

        public override void AddCrust()
        {
            Crust = new Crust();
            Crust.RegularCrust();
        }

        public override void AddSize()
        {
            Size = new Size();
            Size.MediumSize();
        }

        public override void AddToppings()
        {
            toppings.Add(new Topping());
        }
    }
}