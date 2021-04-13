using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;


namespace PizzaBox.Storing.Repositories
{

    public class CrustRepository : IRepository<PizzaBox.Storing.Entities.Crust>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Crust, PizzaBoxLib.Models.Crust> mapper = new CrustMapper();

        public CrustRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Crust Crust)
        {
            context.Add(Crust);
            context.SaveChanges();
        }

        public void Delete(Crust Crust)
        {
            context.Remove(Crust);
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var Crust = context.Crusts.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(Crust);
            context.SaveChanges();
        }

        public void Update(Crust Crust)
        {
            var CrustToUpdate = context.Crusts.Where(x => x.CrustId == Crust.CrustId).FirstOrDefault();
            if (CrustToUpdate != null)
            {
                CrustToUpdate.Name = Crust.Name;
            }
            else
            {
                Console.WriteLine("Custormer does not exist");
            }

            context.Update(CrustToUpdate);
            context.SaveChanges();
        }

        List<Crust> IRepository<Crust>.GetAllItems()
        {
            var Crusts = context.Crusts;
            return Crusts.ToList();
        }

        public List<Crust> GetAllItems()
        {
            var Crusts = context.Crusts;
            return Crusts.ToList();
        }

        public Crust GetByName(string name)
        {
            var Crust = context.Crusts.Where(x => x.Name == name).FirstOrDefault();
            return Crust;
        }

        public Crust GetById(int id)
        {
            var Crust = context.Crusts.Where(x => x.CrustId == id).FirstOrDefault();
            return Crust;
        }

    }
}