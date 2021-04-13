using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class OrderPizzaRepository : IRepository<PizzaBox.Storing.Entities.OrderPizza>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.OrderPizza, PizzaBoxLib.Models.OrderPizza> mapper = new OrderPizzaMapper();

        public OrderPizzaRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(OrderPizza OrderPizza)
        {
            context.Add(OrderPizza);
            context.SaveChanges();
        }

        public void Delete(OrderPizza OrderPizza)
        {
            context.Remove(OrderPizza);
            context.SaveChanges();
        }

        public void DeleteByOrderPizzaId(int id)
        {
            var OrderPizza = context.OrderPizzas.Where(x => x.OrderPizzaId == id).FirstOrDefault();
            context.Remove(OrderPizza);
            context.SaveChanges();
        }

        public void Update(OrderPizza OrderPizza)
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

        List<OrderPizza> IRepository<OrderPizza>.GetAllItems()
        {
            var OrderPizzas = context.OrderPizzas;
            return OrderPizzas.ToList();
        }

        public List<OrderPizza> GetAllItems()
        {
            var OrderPizzas = context.OrderPizzas;
            return OrderPizzas.ToList();
        }

        public List<OrderPizza> GetAllItemsByOrderId(int id)
        {
            return context.OrderPizzas.Where(x => x.OrderId == id).ToList();
        }

        public OrderPizza GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}