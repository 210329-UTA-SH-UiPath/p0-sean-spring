using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    ///  Represents the pizza abstract class
    /// </summary>

    [XmlInclude(typeof(PepperoniPizza))]
    [XmlInclude(typeof(VeganPizza))]
    public abstract class APizza
    {

        public Crust Crust { get; set; }

        public Size Size { get; set; }

        public List<Topping> toppings { get; set; }

        public double Price { get; set; }

        protected APizza()
        {
            Factory();
        }

        private void Factory()
        {
            toppings = new List<Topping>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public virtual void AddCrust()
        {
            Crust = new Crust();
        }

        public virtual void AddSize()
        {
            Size = new Size();
        }

        public abstract void AddToppings();


    }
}