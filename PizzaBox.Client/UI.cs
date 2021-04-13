using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Client
{
    public class UI
    {
        Customer customer;
        Store store;
        Order order;
        Pizza custompizza;

        public void RunUI()
        {
            Console.WriteLine("Welcome to PizzaBox!");
            SelectUserMenu();
        }

        public void SelectUserMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose your user");
            Console.WriteLine($"{++index} - New Customer");
            Console.WriteLine($"{++index} - Returning Customer");
            Console.WriteLine($"{++index} - Admin");


            int input = InputInt("Select Option");

            switch (input)
            {
                case 1:
                    NewCustomerMenu();
                    break;
                case 2:
                    OldCustomerMenu();
                    break;
                default:
                    break;
            }
        }

        public void NewCustomerMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to PizzaBox!");
            customer = CustomerController.addCustomer();
            OrderMenu();
        }

        public void OldCustomerMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome back to PizzaBox!");
            customer = CustomerController.GetCustomerByName();
            OrderMenu();
        }


        public void OrderMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"{++index} - Make a new order");
            Console.WriteLine($"{++index} - View past orders");
            Console.WriteLine($"{++index} - Exit PizzaBox");
            int input = InputInt("Select Option");

            switch (input)
            {
                case 1:
                    SelectStoreMenu();
                    break;
                case 2:
                    SelectPastOrdersMenu();
                    break;
                default:
                    break;
            }

        }
        public void SelectPastOrdersMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select an order to review");
            List<Order> orders = OrderController.GetOrderByCustomerId(customer.CustomerId);
            foreach (var order in orders)
            {
                Console.WriteLine($"{++index} - {customer.Name} made an Order with {StoreController.GetStoreById(order.StoreId).Name} on {order.Date}");
            }
            int input = InputInt("Select Option");
            int orderid = orders[--input].OrderId;
            ReviewPastOrder(orderid);
        }

        public void ReviewPastOrder(int orderid)
        {
            int index = 0;
            Console.WriteLine("");
            ViewOrderPrice(orderid);
            Console.WriteLine("");
            Console.WriteLine($"{++index} - View another past order");
            Console.WriteLine($"{++index} - Return to order menu");

            int input = InputInt("Select Option");
            switch (input)
            {
                case 1:
                    SelectPastOrdersMenu();
                    break;
                case 2:
                    OrderMenu();
                    break;
                default:
                    break;
            }
        }

        public void SelectStoreMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose a store from the list");
            List<Store> stores = StoreController.GetStores();
            foreach (var item in stores)
            {
                Console.WriteLine($"{++index} - {item.Name}");
            }
            int input = InputInt("Select Option");

            store = stores[--input];
            order = OrderController.addOrder(customer.CustomerId, store.StoreId, DateTime.Now);
            AddPizzaMenu();
        }

        public void AddPizzaMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("What would you like to do to your order");
            Console.WriteLine($"{++index} - Would you like to add a pizza to order?");
            Console.WriteLine($"{++index} - Would you like to remove a pizza from order?");
            Console.WriteLine($"{++index} - Would you like to Order checkout?");
            int input = InputInt("Select Option");
            switch (input)
            {
                case 1:
                    SelectPizzaMenu();
                    break;
                case 2:
                    SelectPizzaRemoveMenu(order.OrderId);
                    break;
                case 3:
                    CheckOutMenu();
                    break;
                default: break;
            }
        }

        public void SelectPizzaRemoveMenu(int orderId)
        {
            int index = 0;
            List<OrderPizza> orderpizzas = OrderPizzaController.GetOrderPizzasByOrderID(orderId);
            foreach (var item in orderpizzas)
            {

                Pizza pizza = PizzaController.GetPizzaById(item.PizzaId);
                Console.WriteLine($"{++index} - Qty: {item.Quantity} * {pizza.Name}");
                Size size = SizeController.GetSizeById(pizza.SizeId);
                Console.WriteLine($"{size.Name} - {size.Price}");
                Crust crust = CrustController.GetCrustById(pizza.CrustId);
                Console.WriteLine($"{crust.Name} - {crust.Price}");

                List<PizzaTopping> toppings = PizzaToppingController.GetPizzaToppingsByPizzaID(pizza.PizzaId);
                foreach (var topping in toppings)
                {
                    Topping top = ToppingController.GetToppingById(topping.ToppingId);
                    Console.WriteLine($"{top.Name} - {top.Price}");
                }
                Console.WriteLine("");
            }
            int delete = InputInt("Select a pizza to remove");
            OrderPizzaController.DeleteOrderPizzaById(orderpizzas[--delete].OrderPizzaId);
            AddPizzaMenu();
        }

        public void SelectPizzaMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose a pizza from the list");
            List<Pizza> pizzas = PizzaController.GetPizzas();
            foreach (var item in pizzas)
            {
                if (item.Name != "CustomPizza")
                {
                    Console.WriteLine($"{++index} - {SizeController.GetSizeById(item.SizeId).Name} - {item.Name} ");
                }

            }
            Console.WriteLine($"{++index} - CustomPizza");
            int input = InputInt("Select Option");

            if (input == index)
            {
                Console.WriteLine("You have selected custom pizza");
                SelectSize();
            }
            else
            {
                int Quantity = InputInt("Input Quantity");
                OrderPizzaController.addOrderPizza(order.OrderId, pizzas[--input].PizzaId, Quantity);
                AddPizzaMenu();
            }
        }

        public void SelectSize()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select your pizza size");
            List<Size> sizes = SizeController.GetSizes();
            foreach (var size in sizes)
            {
                Console.WriteLine($"{++index} - {size.Name} - {size.Price} ");
            }
            int input = InputInt("Select Option");
            var sizeId = sizes[--input].SizeId;

            SelectCrust(sizeId);
        }

        public void SelectCrust(int sizeId)
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select your pizza crust");
            List<Crust> crusts = CrustController.GetCrusts();
            foreach (var crust in crusts)
            {
                Console.WriteLine($"{++index} - {crust.Name} - {crust.Price} ");
            }
            int input = InputInt("Select Option");
            var crustId = input;
            custompizza = PizzaController.addCustomPizza(sizeId, crustId);

            AddToppings();
        }

        public void AddToppings()
        {
            HashSet<Topping> toppingset = new HashSet<Topping>();
            bool finished = false;
            int index = 0;
            Console.WriteLine("");
            List<Topping> toppings = ToppingController.GetToppings();
            foreach (var topping in toppings)
            {
                Console.WriteLine($"{++index} - {topping.Name} - {topping.Price} ");
            }
            Console.WriteLine($"{++index} - Finished Selecting Toppings");

            do
            {
                Console.WriteLine("Select your toppings (at least two, no more than five)");

                int input = InputInt("Select Topping");


                if (input == index && toppingset.Count > 2)
                {
                    finished = true;
                }
                else if (toppingset.Count == 5)
                {
                    finished = true;
                }
                else if (input > 0 && input < index)
                {
                    if (toppingset.Add(toppings[--input]))
                    {
                        Console.WriteLine($"Topping was added.");
                    }
                    else
                    {
                        Console.WriteLine($"Topping was already added. Pick another topping.");
                    }
                }
            } while (!finished);

            foreach (var item in toppingset)
            {
                PizzaToppingController.addPizzaTopping(item.ToppingId, custompizza.PizzaId);
            }

            int Quantity = InputInt("Input Quantity");
            OrderPizzaController.addOrderPizza(order.OrderId, custompizza.PizzaId, Quantity);
            AddPizzaMenu();
        }


        public void CheckOutMenu()
        {
            Console.WriteLine("Your order is finished!");
            Console.WriteLine($"{customer.Name} has ordered from {store.Name} at {order.Date}");
            ViewOrderPrice(order.OrderId);
            OrderMenu();
        }

        public void ViewOrderPrice(int orderId)
        {
            List<OrderPizza> orderpizzas = OrderPizzaController.GetOrderPizzasByOrderID(orderId);
            decimal totalPrice = 0;
            foreach (var item in orderpizzas)
            {
                decimal pizzaPrice = 0;
                Pizza pizza = PizzaController.GetPizzaById(item.PizzaId);
                Console.WriteLine($"Qty: {item.Quantity} * {pizza.Name}");
                Size size = SizeController.GetSizeById(pizza.SizeId);
                pizzaPrice += size.Price;
                Console.WriteLine($"{size.Name} - {size.Price}");
                Crust crust = CrustController.GetCrustById(pizza.CrustId);
                pizzaPrice += crust.Price;
                Console.WriteLine($"{crust.Name} - {crust.Price}");

                List<PizzaTopping> toppings = PizzaToppingController.GetPizzaToppingsByPizzaID(pizza.PizzaId);
                foreach (var topping in toppings)
                {
                    Topping top = ToppingController.GetToppingById(topping.ToppingId);
                    Console.WriteLine($"{top.Name} - {top.Price}");
                    pizzaPrice += top.Price;
                }
                totalPrice += pizzaPrice * item.Quantity;
                Console.WriteLine("");
            }
            Console.WriteLine($"Total Price: {totalPrice}");

        }


        private static int InputInt(string promt)
        {
            //validates input is an int
            Console.WriteLine(promt);
            bool success = false;
            do
            {
                success = Int32.TryParse(Console.ReadLine(), out int value);
                if (success)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("That is not an number! Please enter a number");
                }
            } while (!success);

            return -1;
        }

    }
}

