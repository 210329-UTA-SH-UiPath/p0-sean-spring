using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class CustomerRepository : IRepository<PizzaBox.Domain.Models.Customer>
    {

        private readonly PizzaBox.Storing.Entities.pizzaappContext context;

        private readonly IMapper<Entities.Customer, PizzaBox.Domain.Models.Customer> mapper = new CustomerMapper();

        public CustomerRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(PizzaBox.Domain.Models.Customer customer)
        {
            context.Add(mapper.Map(customer));
            context.SaveChanges();
        }

        public void Delete(PizzaBox.Domain.Models.Customer customer)
        {
            context.Remove(mapper.Map(customer));
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var Customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(Customer);
            context.SaveChanges();
        }

        public void Update(PizzaBox.Domain.Models.Customer customer)
        {
            var CustomerToUpdate = context.Customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();
            if (CustomerToUpdate != null)
            {
                CustomerToUpdate.Name = customer.Name;
                CustomerToUpdate.Address = customer.Address;
            }
            else
            {
                Console.WriteLine("Customer does not exist");
            }

            context.Update(CustomerToUpdate);
            context.SaveChanges();
        }

        List<PizzaBox.Domain.Models.Customer> IRepository<PizzaBox.Domain.Models.Customer>.GetAllItems()
        {
            var customers = context.Customers;
            return customers.Select(mapper.Map).ToList();
        }

        public List<PizzaBox.Domain.Models.Customer> GetAllItems()
        {
            var customers = context.Customers;
            return customers.Select(mapper.Map).ToList();
        }

        public PizzaBox.Domain.Models.Customer GetByName(string name)
        {
            var Customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
            return mapper.Map(Customer);
        }

        public PizzaBox.Domain.Models.Customer GetById(int id)
        {
            var Customer = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return mapper.Map(Customer);
        }

        public bool DoesUserExist(string name)
        {

            var Customer = context.Customers.Where(x => x.Name == name).FirstOrDefault();
            if (Customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}