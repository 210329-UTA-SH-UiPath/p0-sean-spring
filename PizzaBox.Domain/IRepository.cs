using System.Collections.Generic;

namespace PizzaBox.Domain
{

    public interface IRepository<T>
    {
        List<T> GetAllItems();

        T GetById(int id);

        void Add(T obj);

        void Delete(T obj);

        void Update(T obj);

    }
}