using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class StoreController
    {
        static StoreRepository repository = Dependencies.CreateStoreRepository();

        public static List<PizzaBox.Storing.Entities.Store> GetStores()
        {
            var stores = repository.GetAllItems();
            return stores;
        }

        public static PizzaBox.Storing.Entities.Store GetStoreById(int id)
        {
            return repository.GetById(id);
        }
    }
}