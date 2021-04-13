namespace PizzaBox.Storing
{

    public interface IMapper<T, R>
    {
        T Map(R obj);

        R Map(T obj);

    }
}