using System;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    internal class Program
    {

        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var Order = new Order();
            Console.WriteLine("Welcome to Pizzabox");
            DisplayStoreMenu();

            Order.Customer = new Customer();
            Order.Store = SelectStore();
            Order.Pizza = SelectPizza();
            Console.WriteLine(Order.ToString());
            //_pizzaSingleton.Save();
            //_storeSingleton.Save();
        }

        private static void DisplayStoreMenu()
        {
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static AStore SelectStore()
        {
            var input = InputInt("Select your Store.");
            while (input < 0 || input > _storeSingleton.Stores.Count)
            {
                input = InputInt("Please select a number from the store menu!");
            }

            DisplayPizzaMenu();

            return _storeSingleton.Stores[input - 1];
        }

        private static void DisplayPizzaMenu()
        {
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static APizza SelectPizza()
        {
            var input = InputInt("Select your pizza");
            while (input < 0 || input > _pizzaSingleton.Pizzas.Count)
            {
                input = InputInt("Please select a number from the pizza menu!");
            };

            return _pizzaSingleton.Pizzas[input - 1];
        }
        private static int InputInt(string promt)
        {
            //validates input is an int
            Console.WriteLine(promt);
            bool success = false;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out int value);
                if (success)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("That is not an number! Please enter a number");
                }
            } while (!success);

            return -1;
        }
    }

}
