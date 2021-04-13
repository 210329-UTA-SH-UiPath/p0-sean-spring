using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class CrustRepository : IRepository<PizzaBox.Domain.Models.Crust>
    {

        private readonly Entities.pizzaappContext context;

        private readonly CrustMapper mapper = new CrustMapper();

        public CrustRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Crust Crust)
        {
            context.Add(mapper.Map(Crust));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Crust Crust)
        {
            context.Remove(mapper.Map(Crust));
            context.SaveChanges();
        }
        public void Update(Domain.Models.Crust Crust)
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

        List<Domain.Models.Crust> IRepository<Domain.Models.Crust>.GetAllItems()
        {
            var Crusts = context.Crusts;
            return Crusts.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Crust> GetAllItems()
        {
            var Crusts = context.Crusts;
            return Crusts.Select(mapper.Map).ToList();
        }

        public Domain.Models.Crust GetByName(string name)
        {
            var Crust = context.Crusts.Where(x => x.Name == name).FirstOrDefault();
            if (Crust == null)
            {
                return null;
            }
            return mapper.Map(Crust);
        }

        public Domain.Models.Crust GetById(int id)
        {
            var Crust = context.Crusts.Where(x => x.CrustId == id).FirstOrDefault();
            if (Crust == null)
            {
                return null;
            }
            return mapper.Map(Crust);
        }

    }
}