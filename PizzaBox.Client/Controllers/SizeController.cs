using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class SizeController
    {
        static SizeRepository repository = Dependencies.CreateSizeRepository();

        public static List<PizzaBox.Storing.Entities.Size> GetSizes()
        {
            var Sizes = repository.GetAllItems();
            return Sizes;
        }

        public static PizzaBox.Storing.Entities.Size GetSizeByName()
        {
            Console.WriteLine("Please enter full Name");
            string _Name = Console.ReadLine();
            return repository.GetByName(_Name);
        }

        public static PizzaBox.Storing.Entities.Size GetSizeById(int id)
        {
            return repository.GetById(id);
        }


        public static PizzaBox.Storing.Entities.Size addSize(int _CustomerId, int _StoreId, DateTime _date)
        {

            PizzaBox.Storing.Entities.Size Size = new PizzaBox.Storing.Entities.Size
            {
            };


            Console.WriteLine(Size.SizeId);
            repository.Add(Size);
            return Size;
        }

        public static void UpdateSizeById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
        }
    }
}