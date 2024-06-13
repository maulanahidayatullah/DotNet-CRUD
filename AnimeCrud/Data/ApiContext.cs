using Microsoft.EntityFrameworkCore;
using AnimeCrud.Models;


namespace AnimeCrud.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public ApiContext(DbContextOptions <ApiContext> options) : base(options) { 
        
        }
    }
}
