using Libreria.Models.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Libreria.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;


namespace Libreria.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<MyDbContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });
            services.AddScoped<BookRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<UserRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof)
            return services;
        }
    }
}
