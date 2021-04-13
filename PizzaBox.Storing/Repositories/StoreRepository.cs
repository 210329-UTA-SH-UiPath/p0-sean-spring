using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class StoreRepository : IRepository<PizzaBox.Domain.Models.Store>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.Store, PizzaBox.Domain.Models.Store> mapper = new StoreMapper();

        public StoreRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Store store)
        {
            context.Add(mapper.Map(store));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Store store)
        {
            context.Remove(mapper.Map(store));
            context.SaveChanges();
        }

        public void Update(Domain.Models.Store store)
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

        List<Domain.Models.Store> IRepository<Domain.Models.Store>.GetAllItems()
        {
            var stores = context.Stores;
            return stores.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Store> GetAllItems()
        {
            var stores = context.Stores;
            return stores.Select(mapper.Map).ToList();
        }

        public Domain.Models.Store GetById(int id)
        {
            var store = context.Stores.Where(x => x.StoreId == id).FirstOrDefault();
            return mapper.Map(store);
        }

    }
}