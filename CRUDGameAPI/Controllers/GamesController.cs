using System;
using System.Linq;
using System.Threading.Tasks;
using CRUDGameAPI.Models;
using CRUDGameAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDGameAPI.Controllers
{
    /// <summary>
    /// Controller for API executing basic CRUD
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IModelMapping _modelMapping;
        
        /// <summary>
        /// Constructor for GamesContoller
        /// </summary>
        /// <param name="modelMapping"></param>
        public GamesController(IModelMapping modelMapping)
        {
            _modelMapping = modelMapping;
        }
        
        /// <summary>
        /// Method for finding games by genre
        /// </summary>
        /// <param name="genre">Genre name to sample</param>
        /// <remarks>
        ///  Example request:
        /// 
        ///   /api/games/?genre={value}
        /// 
        /// </remarks>
        /// <returns>Returns a list of games selected by genre</returns>
        [HttpGet]
        public async Task<IQueryable<GameForm>> Get(string genre)
        {
            return _modelMapping.Get(genre);
        }
        
        /// <summary>
        /// Method for adding game in database
        /// </summary>
        /// <param name="gameForm">Contains: Developer, Game, Genre</param>
        /// <remarks>
        ///  Example request:
        ///      
        ///      {
        ///          "Developer": "string",
        ///          "Game": "string",
        ///          "Genre": "string"
        ///      }
        /// 
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameForm gameForm)
        {
            _modelMapping.Create(gameForm);
            return Ok();
        }

        /// <summary>
        /// Method for updating game data
        /// </summary>
        /// <param name="gameForm">Contains: Id, Developer, Game, Genre</param>
        /// <remarks>
        ///  Example request:
        ///      
        ///      {
        ///          "Id": {int value},
        ///          "Developer": "string",
        ///          "Game": "string",
        ///          "Genre": "string"
        ///      }
        /// 
        /// </remarks>
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] GameForm gameForm)
        {
            _modelMapping.Update(gameForm);
            return Ok();
        }

        /// <summary>
        /// Method for removing a game from the database
        /// </summary>
        /// <param name="id">Game number in the database to delete</param>
        /// <remarks>
        ///  Example request:
        /// 
        ///   /api/games/{value}
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _modelMapping.Delete(id);
            return Ok();
        }
    }
}