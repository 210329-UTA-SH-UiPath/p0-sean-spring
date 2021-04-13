using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class OrderPizzaRepository : IRepository<PizzaBox.Domain.Models.OrderPizza>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.OrderPizza, PizzaBox.Domain.Models.OrderPizza> mapper = new OrderPizzaMapper();

        public OrderPizzaRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.OrderPizza OrderPizza)
        {
            context.Add(mapper.Map(OrderPizza));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.OrderPizza OrderPizza)
        {
            context.Remove(mapper.Map(OrderPizza));
            context.SaveChanges();
        }

        public Domain.Models.OrderPizza GetRecentlyAdded()
        {
            int maxIndex = context.OrderPizzas.Max(x => x.OrderPizzaId);
            return mapper.Map(context.OrderPizzas.Where(x => x.OrderPizzaId == maxIndex).FirstOrDefault());
        }

        public void DeleteByOrderPizzaId(int id)
        {
            var OrderPizza = context.OrderPizzas.Where(x => x.OrderPizzaId == id).FirstOrDefault();
            context.Remove(OrderPizza);
            context.SaveChanges();
        }

        public void Update(Domain.Models.OrderPizza OrderPizza)
        {
            var OrderPizzaToUpdate = context.OrderPizzas.Where(x => x.OrderPizzaId == OrderPizza.OrderPizzaId).FirstOrDefault();
            if (OrderPizzaToUpdate != null)
            {

            }
            else
            {
                Console.WriteLine("Customer does not exist");
            }

            context.Update(OrderPizzaToUpdate);
            context.SaveChanges();
        }

        List<Domain.Models.OrderPizza> IRepository<Domain.Models.OrderPizza>.GetAllItems()
        {
            var OrderPizzas = context.OrderPizzas;
            return OrderPizzas.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.OrderPizza> GetAllItems()
        {
            var OrderPizzas = context.OrderPizzas;
            return OrderPizzas.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.OrderPizza> GetAllItemsByOrderId(int id)
        {
            return context.OrderPizzas.Where(x => x.OrderId == id).Select(mapper.Map).ToList();
        }

        public OrderPizza GetById(int id)
        {
            var OrderPizza = context.OrderPizzas.Where(x => x.OrderPizzaId == id).FirstOrDefault();
            if (OrderPizza == null)
            {
                return null;
            }
            return mapper.Map(OrderPizza);
        }
    }
}