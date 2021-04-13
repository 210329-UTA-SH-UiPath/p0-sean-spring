// using System.Collections.Generic;
// using System.Xml.Serialization;
// using PizzaBox.Domain.Models;
// using System;

// namespace PizzaBox.Domain.Abstracts
// {
//     /// <summary>
//     ///  Represents the pizza abstract class
//     /// </summary>

//     public abstract class APizza
//     {
//         private double _price;

//         private List<Topping> _toppings;

//         public string Name { get; set; }
//         public Crust Crust { get; set; }

//         public Size Size { get; set; }

//         public List<Topping> toppings
//         {
//             get
//             {
//                 return _toppings;
//             }
//             set
//             {
//                 if (value.Count < 2)
//                 {
//                     Console.WriteLine("Pizza has too little toppings. Please put more than two.");
//                     _toppings = null;
//                 }
//                 else if (value.Count > 5)
//                 {
//                     Console.WriteLine("Pizza has too many topping. Please put less than five.");
//                     _toppings = null;
//                 }
//                 else
//                 {
//                     _toppings = value;
//                 }
//             }
//         }

//         protected APizza()
//         {
//             Factory();
//         }

//         private void Factory()
//         {


//             AddCrust();
//             AddSize();
//             AddToppings();
//         }

//         public virtual void AddCrust()
//         {
//             Crust = new Crust();
//         }

//         public virtual void AddSize()
//         {
//             Size = new Size();
//         }

//         public abstract void AddToppings();


//         public virtual void AddName()
//         {
//             Name = null;
//         }


//     }
// }