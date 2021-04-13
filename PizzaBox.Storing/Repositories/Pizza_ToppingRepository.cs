using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class PizzaToppingRepository : IRepository<PizzaBox.Storing.Entities.PizzaTopping>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.PizzaTopping, PizzaBoxLib.Models.PizzaTopping> mapper = new PizzaToppingMapper();

        public PizzaToppingRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(PizzaTopping PizzaTopping)
        {
            context.Add(PizzaTopping);
            context.SaveChanges();
        }

        public void Delete(PizzaTopping PizzaTopping)
        {
            context.Remove(PizzaTopping);
            context.SaveChanges();
        }

        public void Update(PizzaTopping PizzaTopping)
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

        List<PizzaTopping> IRepository<PizzaTopping>.GetAllItems()
        {
            var PizzaToppings = context.PizzaToppings;
            return PizzaToppings.ToList();
        }

        public List<PizzaTopping> GetAllItems()
        {
            var PizzaToppings = context.PizzaToppings;
            return PizzaToppings.ToList();
        }

        public List<PizzaTopping> GetAllItemsByPizzaId(int id)
        {
            return context.PizzaToppings.Where(x => x.PizzaId == id).ToList();
        }

        public PizzaTopping GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}