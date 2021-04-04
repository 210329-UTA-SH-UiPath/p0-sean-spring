using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{

    public class PizzaSingleton
    {
        private static PizzaSingleton _instance;
        public List<APizza> Pizzas { get; set; }
        private static readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"PizzaBox.Storing/Repositories/Pizza.xml";

        public static PizzaSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PizzaSingleton();
                }

                return _instance;
            }
        }

        private PizzaSingleton()
        {
            Pizzas = _fileRepository.ReadFromFile<APizza>(_path);
        }

        public bool Save()
        {

            return _fileRepository.WriteToFile<APizza>(_path, Pizzas);
        }

    }
}