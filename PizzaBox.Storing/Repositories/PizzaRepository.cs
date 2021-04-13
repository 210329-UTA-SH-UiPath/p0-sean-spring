using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class PizzaRepository : IRepository<PizzaBox.Storing.Entities.Pizza>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.pizza, PizzaBoxLib.Models.pizza> mapper = new pizzaMapper();

        public PizzaRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Pizza pizza)
        {
            context.Add(pizza);
            context.SaveChanges();
        }

        public void Delete(Pizza pizza)
        {
            context.Remove(pizza);
            context.SaveChanges();
        }

        List<Pizza> IRepository<Pizza>.GetAllItems()
        {
            var pizzas = context.Pizzas;
            return pizzas.ToList();
        }

        public List<Pizza> GetAllItems()
        {
            var pizzas = context.Pizzas;
            return pizzas.OrderBy(o => o.SizeId).ToList();
        }

        public void Update(Pizza pizza)
        {
            var PizzaToUpdate = context.Pizzas.Where(x => x.PizzaId == pizza.PizzaId).FirstOrDefault();
            if (PizzaToUpdate != null)
            {
                PizzaToUpdate.Name = pizza.Name;
                PizzaToUpdate.CrustId = pizza.CrustId;
                PizzaToUpdate.SizeId = pizza.SizeId;
            }
            else
            {
                Console.WriteLine("Pizza does not exist");
            }

            context.Update(PizzaToUpdate);
            context.SaveChanges();
        }

        public Pizza GetByID(int id)
        {
            return context.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault();
        }

        public Pizza GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteByName(string name)
        {
            throw new NotImplementedException();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }


        // public pizza GetByName(string name)
        // {
        //     var pizza = context.pizzas.Where(x => x.Name == name).FirstOrDefault();
        //     return pizza;
        // }

    }
}