using Api.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Services.Extensions
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<MoviesService, MoviesService>();
        }
    }
}