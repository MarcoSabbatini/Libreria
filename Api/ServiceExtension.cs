using Microsoft.OpenApi.Models;

namespace Libreria.Api
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            return services;
        }
        /*public static IServiceCollection AddServicesSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Libreria API",
                    Version = "v1",
                    Description = "An API to manage a Libreria with their resources. ",
                    Contact = new OpenApiContact
                    {
                        Name = "Support Team",
                        Email = "marco01.sabbatini@studenti.unicam.it"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Auth",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. " +
                    "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                    "\r\n\r\nExample: \"Bearer 12345abcdef\""
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme 
                    {

                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                    Array.Empty<string>()
                    }
                });
                s.CustomSchemaIds(type => type.FullName);
            });
            return services;
        }*/

        /*       public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
               {
                   var jwtAuthenticationOption = new JwtAuthenticationOption();
                   configuration.GetSection("JwtAuthentication").Bind(jwtAuthenticationOption);

                   services.AddAuthentication(options => 
                   {
                       options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
                   .AddJwtBearer(options => 
                   {
                       var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuthenticationOption.Key));
                       options.TokenValidationParameters = new TokenValidationParameters()
                       {
                           ValidateIssuer = true,
                           ValidateLifetime = true,
                           ValidateAudience = false,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = jwtAuthenticationOption.Issuer,
                           IssuerSigningKey = securityKey
                       };
                   });
                   services.Configure<JwtAuthenticationOption>(configuration.GetSection("JwtAuthentication"));
                   return services;
               }*/
    }
}
