using Libreria.Api;
using Libreria.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoryService(builder.Configuration).AddSecurityServices(builder.Configuration)
    .AddServicesSwagger().AddWebServices().AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
*/
app.UseSwagger().UseSwaggerUI().UseHttpsRedirection()
    .UseAuthentication().UseAuthorization();
app.MapControllers();


app.Run();
