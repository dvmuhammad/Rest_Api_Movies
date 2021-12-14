using Api.Models.Models;
using Api.Repositories.Base;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Repositories
{
    public class MoviesRepository: RepositoryBase<Movie>
    {
        public MoviesRepository(DbContext context) : base(context)
        {
        }
    }
}