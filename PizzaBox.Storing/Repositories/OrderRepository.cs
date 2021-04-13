using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class OrderRepository : IRepository<PizzaBox.Domain.Models.Order>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.Order, PizzaBox.Domain.Models.Order> mapper = new OrderMapper();

        public OrderRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Order order)
        {
            context.Add(mapper.Map(order));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Order order)
        {
            context.Remove(mapper.Map(order));
            context.SaveChanges();
        }

        public Domain.Models.Order GetRecentlyAdded()
        {
            int maxIndex = context.Orders.Max(x => x.OrderId);
            return mapper.Map(context.Orders.Where(x => x.OrderId == maxIndex).FirstOrDefault());
        }


        // public void Update(Order order)
        // {
        //     var orderToUpdate = context.Orders.Where(x => x.OrderId == order.OrderId).FirstOrDefault();
        //     if (orderToUpdate != null)
        //     {
        //         orderToUpdate.Name = Order.Name;
        //     }
        //     else
        //     {
        //         Console.WriteLine("Custormer does not exist");
        //     }

        //     context.Update(orderToUpdate);
        //     context.SaveChanges();
        // }

        List<Domain.Models.Order> IRepository<Domain.Models.Order>.GetAllItems()
        {
            var orders = context.Orders;
            return orders.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Order> GetAllItems()
        {
            var orders = context.Orders;
            return orders.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Order> GetAllOrdersByCustomerId(int id)
        {

            return context.Orders.Where(x => x.CustomerId == id).Select(mapper.Map).ToList();
        }

        public void Update(Domain.Models.Order obj)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Order GetById(int id)
        {
            return mapper.Map(context.Orders.Where(x => x.OrderId == id).FirstOrDefault());
        }
    }
}