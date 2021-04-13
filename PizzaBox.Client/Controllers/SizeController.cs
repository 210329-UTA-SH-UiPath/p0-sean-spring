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

        public static PizzaBox.Storing.Entities.Size GetSizeById(int id)
        {
            return repository.GetById(id);
        }
    }
}