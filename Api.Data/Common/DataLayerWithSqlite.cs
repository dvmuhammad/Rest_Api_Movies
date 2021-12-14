using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Common
{
    public static class DataLayerWithSqlite
    {
        public static IServiceCollection AddDataLayerWithSqlite(this IServiceCollection services,
            IConfiguration configuration)
        {
            var environmentConnectionString = Environment.GetEnvironmentVariable("connectionString");

            services.AddDbContext<MoviesContext>(options =>
                options.UseSqlite(environmentConnectionString ??
                                  configuration.GetConnectionString("connectionString")));
            services.AddTransient<DbContext, MoviesContext>();
            return services;
        }
    }
}