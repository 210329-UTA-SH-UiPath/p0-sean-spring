using System;
using System.Collections.Generic;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;

namespace PizzaBox.Client.Controller
{

    public static class CrustController
    {
        static CrustRepository repository = Dependencies.CreateCrustRepository();

        public static List<PizzaBox.Storing.Entities.Crust> GetCrusts()
        {
            var Crusts = repository.GetAllItems();
            return Crusts;
        }

        public static PizzaBox.Storing.Entities.Crust GetCrustById(int id)
        {
            return repository.GetById(id);
        }


        public static PizzaBox.Storing.Entities.Crust addCrust(int _CustomerId, int _StoreId, DateTime _date)
        {

            PizzaBox.Storing.Entities.Crust Crust = new PizzaBox.Storing.Entities.Crust
            {
            };


            Console.WriteLine(Crust.CrustId);
            repository.Add(Crust);
            return Crust;
        }

        public static void UpdateCrustById()
        {
            Console.WriteLine("Please enter name to update");
            string _firstName = Console.ReadLine();
        }


    }
}