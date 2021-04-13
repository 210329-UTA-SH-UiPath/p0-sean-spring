using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class OrderController
    {
        static OrderRepository repository = Dependencies.CreateOrderRepository();

        public static List<PizzaBox.Storing.Entities.Order> GetOrders()
        {
            var Orders = repository.GetAllItems();
            return Orders;
        }

        public static List<PizzaBox.Storing.Entities.Order> GetOrderByCustomerId(int id)
        {

            return repository.GetAllOrdersByCustomerId(id);
        }

        public static PizzaBox.Storing.Entities.Order addOrder(int _CustomerId, int _StoreId, DateTime _date)
        {

            PizzaBox.Storing.Entities.Order order = new PizzaBox.Storing.Entities.Order
            {
                CustomerId = _CustomerId,
                StoreId = _StoreId,
                Date = _date
            };
            repository.Add(order);
            return order;
        }

        public static void UpdateOrderById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
        }


    }
}