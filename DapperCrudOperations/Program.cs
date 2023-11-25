using System.Data.SqlClient;
using Dapper;
using DapperCrudOperations.EndPoints;
using DapperCrudOperations.Models;
using DapperCrudOperations.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("E_CommerceDb") ??
                           throw new ApplicationException("Connection string 'E_CommerceDb' not found");
    return new SqlConnectionFactory(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapProductsEndpoints();


app.Run();

