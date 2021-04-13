using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class OrderController
    {
        static OrderRepository repository = Dependencies.CreateOrderRepository();

        public static List<PizzaBox.Domain.Models.Order> GetOrders()
        {
            var Orders = repository.GetAllItems();
            return Orders;
        }

        public static List<PizzaBox.Domain.Models.Order> GetOrderByCustomerId(int id)
        {

            return repository.GetAllOrdersByCustomerId(id);
        }

        public static PizzaBox.Domain.Models.Order addOrder(int _CustomerId, int _StoreId, DateTime _date)
        {

            PizzaBox.Domain.Models.Order order = new PizzaBox.Domain.Models.Order
            {
                CustomerId = _CustomerId,
                StoreId = _StoreId,
                Date = _date
            };
            repository.Add(order);
            return repository.GetRecentlyAdded();

        }
    }
}