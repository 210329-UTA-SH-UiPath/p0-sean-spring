using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        private static void Main(string[] args)
        {

            Run();
        }

        private static void Run()
        {

            Console.WriteLine("Welcome to Pizzabox");
            var stores = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };


            foreach (var item in stores)
            {
                Console.WriteLine(item);
            }
        }
    }
}
