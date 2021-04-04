using PizzaBox.Domain.Models;
using System.Xml.Serialization;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Represents the store abstract class
    /// </summary>
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public abstract class AStore
    {
        //property

        public string Name { get; set; }


        public override string ToString()
        {
            return $"{Name}";
        }


    }
}