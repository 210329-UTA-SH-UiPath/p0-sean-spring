using System;
using PizzaBox.Domain;
using System.Collections.Generic;
using PizzaBox.Storing;
using PizzaBox.Client.Controller;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    public static class UI
    {
        static Customer _customer;
        static Store _store;
        static Order _order;
        static Pizza _custompizza;

        public static void RunUI()
        {
            Console.WriteLine("Welcome to PizzaBox!");
            SelectUserMenu();
        }

        public static void SelectUserMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose your user");
            Console.WriteLine($"{++index} - New Customer");
            Console.WriteLine($"{++index} - Returning Customer");
            //Console.WriteLine($"{++index} - Admin");


            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

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

        public static void NewCustomerMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to PizzaBox!");
            _customer = CustomerController.addCustomer();
            OrderMenu();
        }

        public static void OldCustomerMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome back to PizzaBox!");
            _customer = CustomerController.GetCustomerByName();

            OrderMenu();
        }


        public static void OrderMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"{++index} - Make a new order");
            Console.WriteLine($"{++index} - View past orders");
            Console.WriteLine($"{++index} - Exit PizzaBox");
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");


            switch (input)
            {
                case 1:
                    SelectStoreMenu();
                    break;
                case 2:
                    SelectPastOrdersMenu();
                    break;
                case 3:
                    break;
            }

        }
        public static void SelectPastOrdersMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select an order to review");
            List<Order> orders = OrderController.GetOrderByCustomerId(_customer.CustomerId);
            foreach (var order in orders)
            {
                Console.WriteLine($"{++index} - {_customer.Name} made an Order with {StoreController.GetStoreById(order.StoreId).Name} on {order.Date}");
            }
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

            int orderid = orders[--input].OrderId;
            ReviewPastOrder(orderid);
        }

        public static void ReviewPastOrder(int orderid)
        {
            int index = 0;
            Console.WriteLine("");
            ViewOrderPrice(orderid);
            Console.WriteLine("");
            Console.WriteLine($"{++index} - View another past order");
            Console.WriteLine($"{++index} - Return to order menu");

            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

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

        public static void SelectStoreMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose a store from the list");
            List<Store> stores = StoreController.GetStores();
            foreach (var item in stores)
            {
                Console.WriteLine($"{++index} - {item.Name}");
            }
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

            _store = stores[--input];
            _order = OrderController.addOrder(_customer.CustomerId, _store.StoreId, DateTime.Now);
            AddPizzaMenu();
        }

        public static void AddPizzaMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("What would you like to do to your order");
            Console.WriteLine($"{++index} - Would you like to add a pizza to order?");
            Console.WriteLine($"{++index} - Would you like to view/remove a pizza from order?");
            Console.WriteLine($"{++index} - Would you like to Order checkout?");
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

            switch (input)
            {
                case 1:
                    SelectPizzaMenu();
                    break;
                case 2:
                    SelectPizzaRemoveMenu(_order.OrderId);
                    break;
                case 3:
                    CheckOutMenu();
                    break;
                default: break;
            }
        }

        public static void SelectPizzaRemoveMenu(int orderId)
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
            Console.WriteLine($"{++index} - Go back");
            int delete = InputIntInRange("Select a pizza to remove", index, 1, "Please select a number from the store menu!");

            if (delete == index)
            {
                AddPizzaMenu();
            }
            else
            {
                OrderPizzaController.DeleteOrderPizzaById(orderpizzas[--delete].OrderPizzaId);
                AddPizzaMenu();
            }


        }

        public static void SelectPizzaMenu()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Choose a pizza from the list");
            List<Pizza> pizzas = PizzaController.GetPizzas();
            foreach (var item in pizzas)
            {
                Console.WriteLine($"{++index} - {SizeController.GetSizeById(item.SizeId).Name} - {item.Name} ");
            }
            Console.WriteLine($"{++index} - CustomPizza");
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");


            if (input == index)
            {
                Console.WriteLine("You have selected custom pizza");
                SelectSize();
            }
            else
            {
                int Quantity = InputIntInRange("Input Quantity", 50, 1, "Please select a quantity from 1 to 50");

                OrderPizzaController.addOrderPizza(_order.OrderId, pizzas[--input].PizzaId, Quantity);
                Console.WriteLine($"Your pizza was added to order.");
                AddPizzaMenu();
            }
        }

        public static void SelectSize()
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select your pizza size");
            List<Size> sizes = SizeController.GetSizes();
            foreach (var size in sizes)
            {
                Console.WriteLine($"{++index} - {size.Name} - {size.Price} ");
            }
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

            var sizeId = sizes[--input].SizeId;

            SelectCrust(sizeId);
        }

        public static void SelectCrust(int sizeId)
        {
            int index = 0;
            Console.WriteLine("");
            Console.WriteLine("Select your pizza crust");
            List<Crust> crusts = CrustController.GetCrusts();
            foreach (var crust in crusts)
            {
                Console.WriteLine($"{++index} - {crust.Name} - {crust.Price} ");
            }
            int input = InputIntInRange("Select Option", index, 1, "Please select a number from the store menu!");

            var crustId = input;
            _custompizza = PizzaController.addCustomPizza(sizeId, crustId);

            AddToppings();
        }

        public static void AddToppings()
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

                int input = InputIntInRange("Select Topping", index, 1, "Please select a number from the store menu!");


                if (input == index && toppingset.Count > 1)
                {
                    finished = true;
                }
                else if (toppingset.Count == 5)
                {
                    Console.WriteLine("Max Toppings added. Pizza added to order.");
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
                PizzaToppingController.addPizzaTopping(item.ToppingId, _custompizza.PizzaId);
            }

            int Quantity = InputIntInRange("Input Quantity", 50, 1, "Please select a quantity from 1 to 50");

            OrderPizzaController.addOrderPizza(_order.OrderId, _custompizza.PizzaId, Quantity);
            Console.WriteLine($"Your pizza was added to order.");
            AddPizzaMenu();
        }


        public static void CheckOutMenu()
        {
            Console.WriteLine("Your order is finished!");
            Console.WriteLine($"{_customer.Name} has ordered from {_store.Name} at {_order.Date}");
            ViewOrderPrice(_order.OrderId);
            OrderMenu();
        }

        public static void ViewOrderPrice(int orderId)
        {
            List<OrderPizza> orderpizzas = OrderPizzaController.GetOrderPizzasByOrderID(orderId);
            decimal totalPrice = 0;
            foreach (var item in orderpizzas)
            {
                decimal pizzaPrice = 0;
                Pizza pizza = PizzaController.GetPizzaById(item.PizzaId);
                Console.WriteLine($"Item: {pizza.Name}");
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
                Console.WriteLine($"Qty: {item.Quantity} Price: {pizzaPrice} Amount: {pizzaPrice * item.Quantity}");
                Console.WriteLine("");
            }
            Console.WriteLine($"Total Order Price: {totalPrice}");

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

        private static int InputIntInRange(string promt, int max, int min, string promt2)
        {
            int input = InputInt(promt);
            while (input < min || input > max)
            {
                input = InputInt(promt2);
            }

            return input;
        }

    }
}

