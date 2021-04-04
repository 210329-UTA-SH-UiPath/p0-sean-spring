using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{


    public class StoreSingleton
    {
        private static StoreSingleton _instance;
        private static readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"PizzaBox.Storing/Repositories/store.xml";
        public List<AStore> Stores { get; set; }

        public static StoreSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StoreSingleton();
                }

                return _instance;
            }
        }
        private StoreSingleton()
        {
            Stores = _fileRepository.ReadFromFile<AStore>(_path);
        }

        public bool Save()
        {
            return _fileRepository.WriteToFile<AStore>(_path, Stores);
        }


    }
}