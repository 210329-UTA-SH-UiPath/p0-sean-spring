using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class ToppingController
    {
        static ToppingRepository repository = Dependencies.CreateToppingRepository();

        public static List<PizzaBox.Domain.Models.Topping> GetToppings()
        {
            var Toppings = repository.GetAllItems();
            return Toppings;
        }

        public static PizzaBox.Domain.Models.Topping GetToppingById(int id)
        {
            return repository.GetById(id);
        }
    }
}