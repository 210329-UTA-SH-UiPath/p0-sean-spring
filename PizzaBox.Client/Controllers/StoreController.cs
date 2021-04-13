using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class StoreController
    {
        static StoreRepository repository = Dependencies.CreateStoreRepository();

        public static List<PizzaBox.Domain.Models.Store> GetStores()
        {
            var stores = repository.GetAllItems();
            return stores;
        }

        public static PizzaBox.Domain.Models.Store GetStoreById(int id)
        {
            return repository.GetById(id);
        }
    }
}