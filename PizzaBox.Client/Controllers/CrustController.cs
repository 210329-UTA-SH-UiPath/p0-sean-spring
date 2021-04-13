using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;

namespace PizzaBox.Client.Controller
{

    public static class CrustController
    {
        static CrustRepository repository = Dependencies.CreateCrustRepository();

        public static List<PizzaBox.Domain.Models.Crust> GetCrusts()
        {
            var Crusts = repository.GetAllItems();
            return Crusts;
        }

        public static PizzaBox.Domain.Models.Crust GetCrustById(int id)
        {
            return repository.GetById(id);
        }
    }
}