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

        public static PizzaBox.Storing.Entities.Store GetStoreByName()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();
            return repository.GetByName(_Name);
        }

        public static PizzaBox.Storing.Entities.Store GetStoreById(int id)
        {
            return repository.GetById(id);
        }


        public static PizzaBox.Storing.Entities.Store addStore()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();

            PizzaBox.Storing.Entities.Store person = new PizzaBox.Storing.Entities.Store
            {
                Name = _Name,

            };

            repository.Add(person);
            Console.WriteLine($"{_Name},  is added");
            return repository.GetByName(_Name);
        }

        public static void UpdateStoreById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
            var Store = repository.GetByName(_firstName);

            Console.WriteLine("Please enter a new Name");
            Store.Name = Console.ReadLine();

            repository.Update(Store);

        }
    }
}