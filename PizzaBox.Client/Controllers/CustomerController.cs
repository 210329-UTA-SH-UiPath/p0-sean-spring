using System;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controller
{

    public static class CustomerController
    {
        static CustomerRepository repository = Dependencies.CreateCustomerRepository();

        public static List<PizzaBox.Domain.Models.Customer> GetCustomers()
        {
            var customers = repository.GetAllItems();
            return customers;
        }

        public static PizzaBox.Domain.Models.Customer GetCustomerByName()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();
            while (!repository.DoesUserExist(_Name))
            {
                Console.WriteLine("Username does not exist. Please try again.");
                _Name = Console.ReadLine();
            }
            return repository.GetByName(_Name);
        }

        public static PizzaBox.Domain.Models.Customer addCustomer()
        {

            Console.WriteLine("Please enter Username");
            string _Name = Console.ReadLine();
            while (repository.DoesUserExist(_Name))
            {
                Console.WriteLine("Username already taken. Please choose another one.");
                _Name = Console.ReadLine();
            }


            PizzaBox.Domain.Models.Customer person = new PizzaBox.Domain.Models.Customer
            {
                Name = _Name,

            };

            repository.Add(person);
            Console.WriteLine($"Customer, {_Name},  is added");
            return repository.GetByName(_Name);
        }
    }
}