using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class PizzaToppingController
    {
        static PizzaToppingRepository repository = Dependencies.CreatePizzaToppingRepository();

        public static List<PizzaBox.Domain.Models.PizzaTopping> GetPizzaToppingsByPizzaID(int id)
        {

            return repository.GetAllItemsByPizzaId(id);
        }



        public static PizzaBox.Domain.Models.PizzaTopping addPizzaTopping(int _toppingID, int _pizzaID)
        {

            PizzaBox.Domain.Models.PizzaTopping PizzaTopping = new PizzaBox.Domain.Models.PizzaTopping
            {
                PizzaId = _pizzaID,
                ToppingId = _toppingID
            };

            repository.Add(PizzaTopping);
            return repository.GetRecentlyAdded();
        }
    }
}