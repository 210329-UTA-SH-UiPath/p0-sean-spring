namespace PizzaBox.Storing.Mappers
{

    public class PizzaMapper : IMapper<PizzaBox.Storing.Entities.Pizza, PizzaBox.Domain.Models.Pizza>
    {
        public Entities.Pizza Map(Domain.Models.Pizza obj)
        {
            return new Entities.Pizza
            {
                PizzaId = obj.PizzaId,
                Name = obj.Name,
                SizeId = obj.SizeId,
                CrustId = obj.CrustId
            };
        }

        public Domain.Models.Pizza Map(Entities.Pizza obj)
        {
            return new Domain.Models.Pizza
            {
                PizzaId = obj.PizzaId,
                Name = obj.Name,
                SizeId = obj.SizeId,
                CrustId = obj.CrustId
            };
        }
    }
}