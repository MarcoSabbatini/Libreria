namespace Libreria.Extensions
using Libreria.Models.Context;
using Microsoft.Extensions.Configuration;

{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services, IConfiguration configuration) { 
    
        services.AddDbContext<MyDbContext>(config =>
        {
            config.UseSq
        })
        }
    }
}
