using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class PizzaToppingRepository : IRepository<PizzaBox.Domain.Models.PizzaTopping>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.PizzaTopping, PizzaBox.Domain.Models.PizzaTopping> mapper = new PizzaToppingMapper();

        public PizzaToppingRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.PizzaTopping PizzaTopping)
        {
            context.Add(mapper.Map(PizzaTopping));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.PizzaTopping PizzaTopping)
        {
            context.Remove(mapper.Map(PizzaTopping));
            context.SaveChanges();
        }

        public Domain.Models.PizzaTopping GetRecentlyAdded()
        {
            int maxIndex = context.PizzaToppings.Max(x => x.PizzaToppingId);
            return mapper.Map(context.PizzaToppings.Where(x => x.PizzaToppingId == maxIndex).FirstOrDefault());
        }

        public void Update(Domain.Models.PizzaTopping PizzaTopping)
        {
            var PizzaToppingToUpdate = context.PizzaToppings.Where(x => x.PizzaToppingId == PizzaTopping.PizzaToppingId).FirstOrDefault();
            if (PizzaToppingToUpdate != null)
            {

            }
            else
            {
                Console.WriteLine("Customer does not exist");
            }

            context.Update(PizzaToppingToUpdate);
            context.SaveChanges();
        }

        List<Domain.Models.PizzaTopping> IRepository<Domain.Models.PizzaTopping>.GetAllItems()
        {
            var PizzaToppings = context.PizzaToppings;
            return PizzaToppings.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.PizzaTopping> GetAllItems()
        {
            var PizzaToppings = context.PizzaToppings;
            return PizzaToppings.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.PizzaTopping> GetAllItemsByPizzaId(int id)
        {
            return context.PizzaToppings.Where(x => x.PizzaId == id).Select(mapper.Map).ToList();
        }

        public Domain.Models.PizzaTopping GetById(int id)
        {
            var PizzaTopping = context.PizzaToppings.Where(x => x.PizzaToppingId == id).FirstOrDefault();
            if (PizzaTopping == null)
            {
                return null;
            }
            return mapper.Map(PizzaTopping);
        }
    }
}