using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class OrderRepository : IRepository<PizzaBox.Storing.Entities.Order>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Order, PizzaBoxLib.Models.Order> mapper = new OrderMapper();

        public OrderRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Add(order);
            context.SaveChanges();
        }

        public void Delete(Order order)
        {
            context.Remove(order);
            context.SaveChanges();
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

        List<Order> IRepository<Order>.GetAllItems()
        {
            var orders = context.Orders;
            return orders.ToList();
        }

        public List<Order> GetAllItems()
        {
            var orders = context.Orders;
            return orders.ToList();
        }

        public List<Order> GetAllOrdersByCustomerId(int id)
        {

            return context.Orders.Where(x => x.CustomerId == id).ToList();
        }

        public void Update(Order obj)
        {
            throw new NotImplementedException();
        }

        public Order GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            return context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }



        // public Order GetByName(string name)
        // {
        //     var order = context.Orders.Where(x => x.Name == name).FirstOrDefault();
        //     return order;
        // }

    }
}