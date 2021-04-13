using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class StoreRepository : IRepository<PizzaBox.Storing.Entities.Store>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Store, PizzaBoxLib.Models.Store> mapper = new StoreMapper();

        public StoreRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Store store)
        {
            context.Add(store);
            context.SaveChanges();
        }

        public void Delete(Store store)
        {
            context.Remove(store);
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var store = context.Stores.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(store);
            context.SaveChanges();
        }

        public void Update(Store store)
        {
            var StoreToUpdate = context.Stores.Where(x => x.StoreId == store.StoreId).FirstOrDefault();
            if (StoreToUpdate != null)
            {
                StoreToUpdate.Name = store.Name;
            }
            else
            {
                Console.WriteLine("Custormer does not exist");
            }

            context.Update(StoreToUpdate);
            context.SaveChanges();
        }

        List<Store> IRepository<Store>.GetAllItems()
        {
            var stores = context.Stores;
            return stores.ToList();
        }

        public List<Store> GetAllItems()
        {
            var stores = context.Stores;
            return stores.ToList();
        }

        public Store GetByName(string name)
        {
            var Store = context.Stores.Where(x => x.Name == name).FirstOrDefault();
            return Store;
        }

        public Store GetById(int id)
        {
            return context.Stores.Where(x => x.StoreId == id).FirstOrDefault();
        }

    }
}