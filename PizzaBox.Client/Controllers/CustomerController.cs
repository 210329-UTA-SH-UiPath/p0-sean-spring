using System;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class CustomerController
    {
        static CustomerRepository repository = Dependencies.CreateCustomerRepository();

        public static List<PizzaBox.Storing.Entities.Customer> GetCustomers()
        {
            var customers = repository.GetAllItems();
            return customers;
        }

        public static PizzaBox.Storing.Entities.Customer GetCustomerByName()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();
            return repository.GetByName(_Name);
        }

        public static PizzaBox.Storing.Entities.Customer addCustomer()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();

            PizzaBox.Storing.Entities.Customer person = new PizzaBox.Storing.Entities.Customer
            {
                Name = _Name,

            };

            repository.Add(person);
            Console.WriteLine($"Customer, {_Name},  is added");
            return repository.GetByName(_Name);
        }

        public static void UpdateCustomerById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
            var customer = repository.GetByName(_firstName);

            Console.WriteLine("Please enter a new Name");
            customer.Name = Console.ReadLine();

            repository.Update(customer);

        }
    }
}