using PizzaBox.Domain;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{

    public static class Dependencies
    {

        public static CustomerRepository CreateCustomerRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new CustomerRepository(dbContext);
        }

        public static StoreRepository CreateStoreRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new StoreRepository(dbContext);
        }


        public static OrderRepository CreateOrderRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new OrderRepository(dbContext);
        }

        public static PizzaRepository CreatePizzaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new PizzaRepository(dbContext);
        }

        public static OrderPizzaRepository CreateOrderPizzaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new OrderPizzaRepository(dbContext);
        }

        public static SizeRepository CreateSizeRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new SizeRepository(dbContext);
        }

        public static CrustRepository CreateCrustRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new CrustRepository(dbContext);
        }

        public static ToppingRepository CreateToppingRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new ToppingRepository(dbContext);
        }

        public static PizzaToppingRepository CreatePizzaToppingRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Storing.Entities.pizzaappContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzabox-app.database.windows.net,1433;Initial Catalog=pizza-app;Persist Security Info=False;User ID=dev;Password=435s606S!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Storing.Entities.pizzaappContext(optionsBuilder.Options);
            return new PizzaToppingRepository(dbContext);
        }
    }
}