namespace PizzaBox.Storing.Mappers
{

    public class SizeMapper : IMapper<PizzaBox.Storing.Entities.Size, PizzaBox.Domain.Models.Size>
    {
        public Entities.Size Map(Domain.Models.Size obj)
        {
            return new Entities.Size
            {
                SizeId = obj.SizeId,
                Name = obj.Name,
                Price = obj.Price
            };
        }

        public Domain.Models.Size Map(Entities.Size obj)
        {
            return new Domain.Models.Size
            {
                SizeId = obj.SizeId,
                Name = obj.Name,
                Price = obj.Price
            };
        }
    }
}