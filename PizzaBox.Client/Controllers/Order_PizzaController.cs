using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class OrderPizzaController
    {
        static OrderPizzaRepository repository = Dependencies.CreateOrderPizzaRepository();

        public static List<PizzaBox.Storing.Entities.OrderPizza> GetOrderPizzas()
        {
            var OrderPizzas = repository.GetAllItems();
            return OrderPizzas;
        }

        public static List<PizzaBox.Storing.Entities.OrderPizza> GetOrderPizzasByOrderID(int id)
        {

            return repository.GetAllItemsByOrderId(id);
        }



        public static PizzaBox.Storing.Entities.OrderPizza addOrderPizza(int _orderID, int _pizzaID, int _quantity)
        {

            PizzaBox.Storing.Entities.OrderPizza OrderPizza = new PizzaBox.Storing.Entities.OrderPizza
            {
                OrderId = _orderID,
                PizzaId = _pizzaID,
                Quantity = _quantity
            };

            repository.Add(OrderPizza);
            return OrderPizza;
        }

        public static void UpdateOrderPizzaById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
        }

        public static void DeleteOrderPizzaById(int id)
        {
            repository.DeleteByOrderPizzaId(id);
        }
    }
}