using Microsoft.EntityFrameworkCore;

namespace CRUDGameAPI.Models
{
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Property to represent a set of GameForm objects in a database.
        /// </summary>
        public DbSet<GameForm> Games { get; set; }
        
        /// <summary>
        /// Constructor for ApplicationContext.
        /// </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { 
        }
    }
}