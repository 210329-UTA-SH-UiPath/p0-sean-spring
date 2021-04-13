namespace PizzaBox.Storing.Mappers
{

    public class CrustMapper : IMapper<PizzaBox.Storing.Entities.Crust, PizzaBox.Domain.Models.Crust>
    {
        public Entities.Crust Map(Domain.Models.Crust obj)
        {
            return new Entities.Crust
            {
                CrustId = obj.CrustId,
                Name = obj.Name,
                Price = obj.Price
            };
        }

        public Domain.Models.Crust Map(Entities.Crust obj)
        {
            return new Domain.Models.Crust
            {
                CrustId = obj.CrustId,
                Name = obj.Name,
                Price = obj.Price
            };
        }
    }
}