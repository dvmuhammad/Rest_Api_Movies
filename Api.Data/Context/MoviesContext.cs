using Api.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MoviesContext: DbContext 
    {
        public MoviesContext(DbContextOptions<MoviesContext> opt): base(opt)
        {
            
        }
        
        public DbSet<Movie> Movies { get; set; }
    }
}