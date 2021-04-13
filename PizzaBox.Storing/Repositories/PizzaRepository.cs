using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class PizzaRepository : IRepository<PizzaBox.Domain.Models.Pizza>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.Pizza, Domain.Models.Pizza> mapper = new PizzaMapper();

        public PizzaRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Pizza pizza)
        {
            context.Add(mapper.Map(pizza));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Pizza pizza)
        {
            context.Remove(mapper.Map(pizza));
            context.SaveChanges();
        }

        List<Domain.Models.Pizza> IRepository<Domain.Models.Pizza>.GetAllItems()
        {
            var pizzas = context.Pizzas;
            return pizzas.Select(mapper.Map).ToList();
        }

        public Domain.Models.Pizza GetRecentlyAdded()
        {
            int maxIndex = context.Pizzas.Max(x => x.PizzaId);
            return mapper.Map(context.Pizzas.Where(x => x.PizzaId == maxIndex).FirstOrDefault());
        }

        public List<Domain.Models.Pizza> GetAllItems()
        {
            var pizzas = context.Pizzas;
            return pizzas.Where(x => x.Name != "CustomPizza").OrderBy(o => o.SizeId).Select(mapper.Map).ToList();
        }

        public void Update(Domain.Models.Pizza pizza)
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

        public Domain.Models.Pizza GetByID(int id)
        {
            var pizza = context.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault();
            return mapper.Map(pizza);
        }

        Domain.Models.Pizza IRepository<Domain.Models.Pizza>.GetById(int id)
        {
            var pizza = context.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault();
            return mapper.Map(pizza);
        }
    }
}