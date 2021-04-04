
using PizzaBox.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing.Repositories
{
    public class FileRepository
    {
        public bool WriteToFile<T>(string path, List<T> items)
        {
            //access to path
            //open the file 
            //access to the object
            //object definition (structure) how to save the object
            // serialize (convert to markup) to XML
            // write to file
            // close
            //

            try
            {

                StreamWriter writer = new StreamWriter(path);
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(writer, items);

                return true;
            }
            // catch (FileNotFoundException e)
            // {
            //     throw new Exception("You have the wrong File", e);
            // }
            catch
            {
                return false;
            }


        }

        public List<T> ReadFromFile<T>(string path) where T : class
        {

            try
            {
                var reader = new StreamReader(path);
                var xml = new XmlSerializer(typeof(List<T>));
                return xml.Deserialize(reader) as List<T>;

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}


