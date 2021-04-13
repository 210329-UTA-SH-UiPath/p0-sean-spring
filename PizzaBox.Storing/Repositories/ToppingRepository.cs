using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class ToppingRepository : IRepository<PizzaBox.Storing.Entities.Topping>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Topping, PizzaBoxLib.Models.Topping> mapper = new ToppingMapper();

        public ToppingRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Topping Topping)
        {
            context.Add(Topping);
            context.SaveChanges();
        }

        public void Delete(Topping Topping)
        {
            context.Remove(Topping);
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var Topping = context.Toppings.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(Topping);
            context.SaveChanges();
        }

        public void Update(Topping Topping)
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

        List<Topping> IRepository<Topping>.GetAllItems()
        {
            var Toppings = context.Toppings;
            return Toppings.ToList();
        }

        public List<Topping> GetAllItems()
        {
            var Toppings = context.Toppings;
            return Toppings.ToList();
        }

        public Topping GetByName(string name)
        {
            var Topping = context.Toppings.Where(x => x.Name == name).FirstOrDefault();
            return Topping;
        }

        public Topping GetById(int id)
        {
            var Topping = context.Toppings.Where(x => x.ToppingId == id).FirstOrDefault();
            return Topping;
        }

    }
}