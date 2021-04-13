using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class ToppingRepository : IRepository<PizzaBox.Domain.Models.Topping>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.Topping, PizzaBox.Domain.Models.Topping> mapper = new ToppingMapper();

        public ToppingRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Topping Topping)
        {
            context.Add(mapper.Map(Topping));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Topping Topping)
        {
            context.Remove(mapper.Map(Topping));
            context.SaveChanges();
        }

        public void Update(Domain.Models.Topping Topping)
        {
            var ToppingToUpdate = context.Toppings.Where(x => x.ToppingId == Topping.ToppingId).FirstOrDefault();
            if (ToppingToUpdate != null)
            {
                ToppingToUpdate.Name = Topping.Name;
            }
            else
            {
                Console.WriteLine("Custormer does not exist");
            }

            context.Update(ToppingToUpdate);
            context.SaveChanges();
        }

        List<Domain.Models.Topping> IRepository<Domain.Models.Topping>.GetAllItems()
        {
            var Toppings = context.Toppings;
            return Toppings.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Topping> GetAllItems()
        {
            var Toppings = context.Toppings;
            return Toppings.Select(mapper.Map).ToList();
        }

        public Domain.Models.Topping GetById(int id)
        {
            var Topping = context.Toppings.Where(x => x.ToppingId == id).FirstOrDefault();
            return mapper.Map(Topping);
        }

    }
}