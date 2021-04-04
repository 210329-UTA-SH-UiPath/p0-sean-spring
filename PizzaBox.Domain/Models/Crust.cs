using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AComponent
    {
        public void RegularCrust()
        {
            Name = "Regular";
            Price = 5;
        }

        public void ChessyCrust()
        {
            Name = "Chessy";
            Price = 7;
        }
    }
}
