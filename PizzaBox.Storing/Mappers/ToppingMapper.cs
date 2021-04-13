namespace PizzaBox.Storing.Mappers
{

    public class ToppingMapper : IMapper<PizzaBox.Storing.Entities.Topping, PizzaBox.Domain.Models.Topping>
    {
        public Entities.Topping Map(Domain.Models.Topping obj)
        {
            return new Entities.Topping
            {
                ToppingId = obj.ToppingId,
                Name = obj.Name,
                Price = obj.Price
            };
        }

        public Domain.Models.Topping Map(Entities.Topping obj)
        {
            return new Domain.Models.Topping
            {
                ToppingId = obj.ToppingId,
                Name = obj.Name,
                Price = obj.Price
            };
        }
    }
}