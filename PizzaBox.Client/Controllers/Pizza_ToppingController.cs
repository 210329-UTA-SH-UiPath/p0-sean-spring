using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class PizzaToppingController
    {
        static PizzaToppingRepository repository = Dependencies.CreatePizzaToppingRepository();

        public static List<PizzaBox.Storing.Entities.PizzaTopping> GetPizzaToppingsByPizzaID(int id)
        {

            return repository.GetAllItemsByPizzaId(id);
        }



        public static PizzaBox.Storing.Entities.PizzaTopping addPizzaTopping(int _toppingID, int _pizzaID)
        {

            PizzaBox.Storing.Entities.PizzaTopping PizzaTopping = new PizzaBox.Storing.Entities.PizzaTopping
            {
                PizzaId = _pizzaID,
                ToppingId = _toppingID
            };

            repository.Add(PizzaTopping);
            return PizzaTopping;
        }
    }
}