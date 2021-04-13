using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{

    public class SizeRepository : IRepository<PizzaBox.Storing.Entities.Size>
    {

        private readonly Entities.pizzaappContext context;

        //private readonly IMapper<Entities.Size, PizzaBoxLib.Models.Size> mapper = new SizeMapper();

        public SizeRepository(Entities.pizzaappContext context)
        {
            this.context = context;
        }

        public void Add(Size Size)
        {
            context.Add(Size);
            context.SaveChanges();
        }

        public void Delete(Size Size)
        {
            context.Remove(Size);
            context.SaveChanges();
        }

        public void DeleteByName(string name)
        {
            var Size = context.Sizes.Where(x => x.Name == name).FirstOrDefault();
            context.Remove(Size);
            context.SaveChanges();
        }

        public void Update(Size Size)
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

        List<Size> IRepository<Size>.GetAllItems()
        {
            var Sizes = context.Sizes;
            return Sizes.ToList();
        }

        public List<Size> GetAllItems()
        {
            var Sizes = context.Sizes;
            return Sizes.ToList();
        }

        public Size GetByName(string name)
        {
            var Size = context.Sizes.Where(x => x.Name == name).FirstOrDefault();
            return Size;
        }

        public Size GetById(int id)
        {
            var Size = context.Sizes.Where(x => x.SizeId == id).FirstOrDefault();
            return Size;
        }

    }
}