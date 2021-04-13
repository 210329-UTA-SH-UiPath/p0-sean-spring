using PizzaBox.Domain;


namespace PizzaBox.Storing.Mappers
{
    public class CustomerMapper : IMapper<Entities.Customer, PizzaBox.Domain.Models.Customer>
    {
        public Entities.Customer Map(PizzaBox.Domain.Models.Customer obj)
        {
            return new Entities.Customer
            {
                CustomerId = obj.CustomerId,
                Name = obj.Name,
                Address = obj.Address,
                //Orders = (System.Collections.Generic.ICollection<Entities.Order>)obj.Orders
            };
        }

        public PizzaBox.Domain.Models.Customer Map(Entities.Customer obj)
        {
            return new PizzaBox.Domain.Models.Customer
            {
                CustomerId = obj.CustomerId,
                Name = obj.Name,
                Address = obj.Address,
                //Orders = (System.Collections.Generic.HashSet<PizzaBoxLib.Models.Order>)obj.Orders
            };
        }
    }

}