using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class ToppingController
    {
        static ToppingRepository repository = Dependencies.CreateToppingRepository();

        public static List<PizzaBox.Storing.Entities.Topping> GetToppings()
        {
            var Toppings = repository.GetAllItems();
            return Toppings;
        }

        public static PizzaBox.Storing.Entities.Topping GetToppingByName()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();
            return repository.GetByName(_Name);
        }

        public static PizzaBox.Storing.Entities.Topping GetToppingById(int id)
        {
            return repository.GetById(id);
        }


        public static PizzaBox.Storing.Entities.Topping addTopping(int _CustomerId, int _StoreId, DateTime _date)
        {

            PizzaBox.Storing.Entities.Topping Topping = new PizzaBox.Storing.Entities.Topping
            {
            };


            Console.WriteLine(Topping.ToppingId);
            repository.Add(Topping);
            return Topping;
        }

        public static void UpdateToppingById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();



        }
    }
}