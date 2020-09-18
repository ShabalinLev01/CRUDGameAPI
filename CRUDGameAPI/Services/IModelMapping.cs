using System.Linq;
using CRUDGameAPI.Models;

namespace CRUDGameAPI.Services
{
    public interface IModelMapping
    {
        IQueryable<GameForm> Get(string genre);
        void Create(GameForm gameForm);
        void Update(GameForm gameForm);
        void Delete(int id);
    }
}