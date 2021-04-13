using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class PizzaController
    {
        static PizzaRepository repository = Dependencies.CreatePizzaRepository();

        public static List<PizzaBox.Domain.Models.Pizza> GetPizzas()
        {
            var Pizzas = repository.GetAllItems();
            return Pizzas;
        }

        public static PizzaBox.Domain.Models.Pizza GetPizzaById(int id)
        {

            return repository.GetByID(id);
        }


        public static PizzaBox.Domain.Models.Pizza addCustomPizza(int _sizeID, int _crustID)
        {

            PizzaBox.Domain.Models.Pizza Pizza = new PizzaBox.Domain.Models.Pizza
            {
                Name = "CustomPizza",
                SizeId = _sizeID,
                CrustId = _crustID
            };

            repository.Add(Pizza);
            return repository.GetRecentlyAdded();
        }
    }
}