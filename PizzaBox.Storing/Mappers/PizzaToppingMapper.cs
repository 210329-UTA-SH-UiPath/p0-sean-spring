namespace PizzaBox.Storing.Mappers
{

    public class PizzaToppingMapper : IMapper<PizzaBox.Storing.Entities.PizzaTopping, PizzaBox.Domain.Models.PizzaTopping>
    {
        public Entities.PizzaTopping Map(Domain.Models.PizzaTopping obj)
        {
            return new Entities.PizzaTopping
            {
                PizzaToppingId = obj.PizzaToppingId,
                PizzaId = obj.PizzaId,
                ToppingId = obj.ToppingId
            };
        }

        public Domain.Models.PizzaTopping Map(Entities.PizzaTopping obj)
        {
            return new Domain.Models.PizzaTopping
            {
                PizzaToppingId = obj.PizzaToppingId,
                PizzaId = obj.PizzaId,
                ToppingId = obj.ToppingId
            };
        }
    }
}