using System.Linq;
using CRUDGameAPI.Models;

namespace CRUDGameAPI.Services
{
    /// <summary>
    /// A class that binds a controller to a class for working with a database.
    /// Required for Single Responsibility Principle.
    /// </summary>
    public class ModelMapping : IModelMapping
    {
        private readonly IRepository<GameForm> _gameRepository;
        
        /// <summary>
        /// Constructor for ModelMapping
        /// </summary>
        /// <param name="gameRepository"></param>
        public ModelMapping(IRepository<GameForm> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        /// <summary>
        /// Method for finding games by genre
        /// </summary>
        /// <param name="genre">Genre name to sample</param>
        /// <returns>Returns a list of games selected by genre</returns>
        public IQueryable<GameForm> Get(string genre)
        {
            return _gameRepository.Get(genre);
        }

        /// <summary>
        /// Method for adding game in database.
        /// Eliminates errors in connection with sending.
        /// </summary>
        /// <param name="gameForm">Game instance</param>
        public void Create(GameForm gameForm)
        {
            if (gameForm.Id == 0)
            {
                _gameRepository.Create(gameForm);
                _gameRepository.Save();
            }
        }        
        
        /// <summary>
        /// Method for updating game data.
        /// Eliminates errors in connection with sending.
        /// </summary>
        /// <param name="gameForm">Game instance</param>
        public void Update(GameForm gameForm)
        {
            if (gameForm.Id != 0)
            {
                _gameRepository.Update(gameForm);
                _gameRepository.Save();
            }
        }        
        
        /// <summary>
        /// Method for removing a game from the database
        /// </summary>
        /// <param name="id">Game number in the database to delete</param>
        public void Delete(int id)
        {
            _gameRepository.Delete(id);
            _gameRepository.Save();
        }
    }
}