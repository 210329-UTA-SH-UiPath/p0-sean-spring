using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{

    public class SizeRepository : IRepository<PizzaBox.Domain.Models.Size>
    {

        private readonly Entities.pizzaappContext context;

        private readonly IMapper<Entities.Size, PizzaBox.Domain.Models.Size> mapper = new SizeMapper();

        public SizeRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Size Size)
        {
            context.Add(mapper.Map(Size));
            context.SaveChanges();
        }

        public void Delete(Domain.Models.Size Size)
        {
            context.Remove(mapper.Map(Size));
            context.SaveChanges();
        }

        public void Update(Domain.Models.Size Size)
        {
            var SizeToUpdate = context.Sizes.Where(x => x.SizeId == Size.SizeId).FirstOrDefault();
            if (SizeToUpdate != null)
            {
                SizeToUpdate.Name = Size.Name;
            }
            else
            {
                Console.WriteLine("Custormer does not exist");
            }

            context.Update(SizeToUpdate);
            context.SaveChanges();
        }

        List<Domain.Models.Size> IRepository<Domain.Models.Size>.GetAllItems()
        {
            var Sizes = context.Sizes;
            return Sizes.Select(mapper.Map).ToList();
        }

        public List<Domain.Models.Size> GetAllItems()
        {
            var Sizes = context.Sizes;
            return Sizes.Select(mapper.Map).ToList();
        }

        public Domain.Models.Size GetById(int id)
        {
            var Size = context.Sizes.Where(x => x.SizeId == id).FirstOrDefault();
            return mapper.Map(Size);
        }

    }
}