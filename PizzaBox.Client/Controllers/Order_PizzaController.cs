using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class OrderPizzaController
    {
        static OrderPizzaRepository repository = Dependencies.CreateOrderPizzaRepository();

        public static List<PizzaBox.Domain.Models.OrderPizza> GetOrderPizzasByOrderID(int id)
        {

            return repository.GetAllItemsByOrderId(id);
        }

        public static PizzaBox.Domain.Models.OrderPizza addOrderPizza(int _orderID, int _pizzaID, int _quantity)
        {

            PizzaBox.Domain.Models.OrderPizza OrderPizza = new PizzaBox.Domain.Models.OrderPizza
            {
                OrderId = _orderID,
                PizzaId = _pizzaID,
                Quantity = _quantity
            };

            repository.Add(OrderPizza);
            return repository.GetRecentlyAdded();
        }

        public static void DeleteOrderPizzaById(int id)
        {
            repository.DeleteByOrderPizzaId(id);
        }
    }
}