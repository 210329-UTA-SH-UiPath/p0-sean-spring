using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class CustomerRepository : IRepository<PizzaBox.Storing.Entities.Customer>
    {

        private readonly PizzaBox.Storing.Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Customer, PizzaBoxLib.Models.Customer> mapper = new CustomerMapper();

        public CustomerRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            context.Add(customer);
            context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            context.Remove(customer);
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var Customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(Customer);
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var CustomerToUpdate = context.Customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
            if (CustomerToUpdate != null)
            {
                CustomerToUpdate.Name = customer.Name;
                CustomerToUpdate.Address = customer.Address;
            }
            else
            {
                Console.WriteLine("Custormer does not exist");
            }

            context.Update(CustomerToUpdate);
            context.SaveChanges();
        }

        List<Customer> IRepository<Customer>.GetAllItems()
        {
            var customers = context.Customers;
            return customers.ToList();
        }

        public List<Customer> GetAllItems()
        {
            var customers = context.Customers;
            return customers.ToList();
        }

        public Customer GetByName(string name)
        {
            var Customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
            return Customer;
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}