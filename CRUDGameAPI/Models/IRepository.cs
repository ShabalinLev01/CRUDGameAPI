using System.Collections.Generic;
using System.Linq;

namespace CRUDGameAPI.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get(string genre);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}