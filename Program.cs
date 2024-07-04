using FluentValidation;
using FluentValidation.AspNetCore;
using Libreria.Api;
using Libreria.Extensions;
using Libreria.Models.Context;
using Libreria.Models.Repositories;
using Libreria.Service.Abstraction;
using Libreria.Service.Models.Responses;
using Libreria.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    /*.ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = (context) =>
        {
            return new BadRequestResultFactory(context);
        };
    }); */;
builder.Services.AddRepositoryService(builder.Configuration);/*.AddSecurityServices(builder.Configuration)
    .AddServicesSwagger()*/
builder.Services.AddWebServices();
builder.Services.AddApplicationServices();
builder.Services.AddFluentValidationAutoValidation();//allows validation rules defined in separate validator classes to be 
                                                     //automatically applied to incoming requests.
builder.Services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies()
    .SingleOrDefault(assembly => assembly.GetName().Name == "Libreria")
    );
builder.Services.AddDbContext<MyDbContext>(conf =>
        conf.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"), options => options.EnableRetryOnFailure())
    );
// Register services with dependency injection
//addscoped(): A new instance of the service is created once per client request.
//The same instance is used throughout the entire request processing pipeline.
//This is useful for services that need to maintain state within a single request,
//but don't need to share state across different requests. 
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<UserRepository>();
//describing the endpoints in the application
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    /*- This tells the validator to check the 'iss' (issuer) claim in the token.
                      - The issuer is the entity that created and signed the token.
                      - Setting this to true enhances security by ensuring the token comes from a trusted source.*/
                    ValidateIssuer = true,
                    /*- This instructs the validator to check the 'aud' (audience) claim in the token.
                      - The audience represents the intended recipient of the token.*/
                    ValidateAudience = true,
                    /*enables checking token's expiration time*/
                    ValidateLifetime = true,
                    /*maintains integrity of the signature of the token*/
                    ValidateIssuerSigningKey = true,
                    /*sets expected value of the issuer, so the validator will compare this value with the issuer in the token*/
                    ValidIssuer = builder.Configuration["JwtAuth:Issuer"],
                    /*set to the same value as the issuer, because no one else except the issuer can use it*/
                    ValidAudience = builder.Configuration["JwtAuth:Issuer"],
                    /*key used to verify token's signature, this key i ssotred int eh appsetting.json, 
                     * symmetric beacuse the same key is used to create and verify the token*/
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAuth:Key"]))
                };

            });

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Libreria", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        //token in the http header
        In = ParameterLocation.Header,
        Name = "Authorization",
        //indicates that this is a http authentication scheme
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    //all endpoints has jwtauthentication by default
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            //references bearer scheme previuosly created 
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            //default
            new string[]{}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

/*app.UseSwagger().UseSwaggerUI().UseHttpsRedirection()
    .UseAuthentication().UseAuthorization()*/;
app.MapControllers();


app.Run();
