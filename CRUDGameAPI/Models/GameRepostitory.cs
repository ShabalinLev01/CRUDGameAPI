using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRUDGameAPI.Models
{
    /// <summary>
    /// Class for working with db
    /// </summary>
    public class GameRepostitory : IRepository<GameForm>
    {
        private readonly ApplicationContext _db;

        /// <summary>
        /// Constructor for GameRepository
        /// </summary>
        /// <param name="db"></param>
        public GameRepostitory(ApplicationContext db)
            {
                _db = db;
            }
            
            /// <summary>
            /// Method for getting a list of games from a database
            /// </summary>
            /// <param name="genre">Genre name to sample</param>
            /// <returns>Returns a list of games selected by genre</returns>
            public IQueryable<GameForm> Get(string genre)
            {
                var gameList = _db.Games.Where(x=>x.Genre == genre);
                return gameList;
            }

            /// <summary>
            /// Method for adding a game to the database
            /// </summary>
            /// <param name="item">Game instance</param>
            public void Create(GameForm item)
            {
                _db.Games.Add(item);
            }
 
            /// <summary>
            /// Method for changing game parameters by an identifier
            /// </summary>
            /// <param name="item">Game instance</param>
            public void Update(GameForm item)
            {
                bool gameContains = _db.Games.Any(x => x.Id == item.Id);
                if (gameContains)
                    _db.Entry(item).State = EntityState.Modified;
                
            }
 
            /// <summary>
            /// Method for removing a game from the database
            /// </summary>
            /// <param name="id">Game number in the database to delete</param>
            public void Delete(int id)
            {
                GameForm user = _db.Games.Find(id);
                if (user != null)
                    _db.Games.Remove(user);
            }
 
            /// <summary>
            /// Method for save changes in database
            /// </summary>
            public void Save()
            {
                _db.SaveChanges();
            }
    }
}