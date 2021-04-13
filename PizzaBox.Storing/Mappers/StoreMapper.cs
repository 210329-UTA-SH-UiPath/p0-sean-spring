using PizzaBox.Domain;


namespace PizzaBox.Storing.Mappers
{
    public class StoreMapper : IMapper<Entities.Store, PizzaBox.Domain.Models.Store>
    {
        public Entities.Store Map(PizzaBox.Domain.Models.Store obj)
        {
            return new Entities.Store
            {
                StoreId = obj.StoreId,
                Name = obj.Name
                //Orders = (System.Collections.Generic.ICollection<Entities.Order>)obj.Orders
            };
        }

        public PizzaBox.Domain.Models.Store Map(Entities.Store obj)
        {
            return new PizzaBox.Domain.Models.Store
            {
                StoreId = obj.StoreId,
                Name = obj.Name
                //Orders = (System.Collections.Generic.HashSet<PizzaBoxLib.Models.Order>)obj.Orders
            };
        }
    }

}