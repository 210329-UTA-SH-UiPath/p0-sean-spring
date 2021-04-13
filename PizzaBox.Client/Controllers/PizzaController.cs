using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class PizzaController
    {
        static PizzaRepository repository = Dependencies.CreatePizzaRepository();

        public static List<PizzaBox.Storing.Entities.Pizza> GetPizzas()
        {
            var Pizzas = repository.GetAllItems();
            return Pizzas;
        }

        public static PizzaBox.Storing.Entities.Pizza GetPizzaById(int id)
        {

            return repository.GetByID(id);
        }


        public static PizzaBox.Storing.Entities.Pizza addCustomPizza(int _sizeID, int _crustID)
        {

            PizzaBox.Storing.Entities.Pizza Pizza = new PizzaBox.Storing.Entities.Pizza
            {
                Name = "CustomPizza",
                SizeId = _sizeID,
                CrustId = _crustID
            };

            repository.Add(Pizza);
            return Pizza;
        }

    }
}