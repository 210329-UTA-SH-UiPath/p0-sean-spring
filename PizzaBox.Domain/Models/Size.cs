using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AComponent
    {

        public void SmallSize()
        {
            Name = "Small";
            Price = 3;
        }

        public void MediumSize()
        {
            Name = "Medium";
            Price = 5;
        }

        public void LargeSize()
        {
            Name = "LargeSize";
            Price = 9;
        }
    }
}