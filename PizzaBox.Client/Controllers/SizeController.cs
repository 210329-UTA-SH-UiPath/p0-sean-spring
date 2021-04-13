using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controller
{

    public static class SizeController
    {
        static SizeRepository repository = Dependencies.CreateSizeRepository();

        public static List<PizzaBox.Domain.Models.Size> GetSizes()
        {
            var Sizes = repository.GetAllItems();
            return Sizes;
        }

        public static PizzaBox.Domain.Models.Size GetSizeById(int id)
        {
            return repository.GetById(id);
        }
    }
}