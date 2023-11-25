using Dapper;
using DapperCrudOperations.Models;
using DapperCrudOperations.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudOperations.EndPoints;

public static class ProductEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("Product");

        group.MapGet("", (SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.CreateConnection();
                const string sql = "SELECT * FROM Product";
                var products = connection.Query<Product>(sql);
                return products;
            }
        );

        group.MapGet("{id}", (int id, SqlConnectionFactory sqlConnectionFactory) =>
        {
            using var connection = sqlConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Product WHERE Id = @Id";
            var product = connection.QuerySingleOrDefault<Product>(sql, new {Id = id});
            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        group.MapPost("", (Product product, SqlConnectionFactory sqlConnectionFactory) =>
        {
            using var connection = sqlConnectionFactory.CreateConnection();
            const string sql = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            var rowsAffected = connection.Execute(sql, product);
            return rowsAffected == 1 ? Results.Created($"/product/{product.Id}", product) : Results.BadRequest();
        });

        group.MapPut
        ("{id}", (int id, Product product, SqlConnectionFactory sqlConnectionFactory) =>
        {
            var connection = sqlConnectionFactory.CreateConnection();
            product.Id = id;
            const string sql = "UPDATE Product SET Name = @Name, Price = @Price WHERE Id = @ProductId";
            connection.Execute(sql,product);
            return Results.NoContent();
        });


        group.MapDelete("{id}", (int id,SqlConnectionFactory sqlConnectionFactory) =>
        {
            var connection = sqlConnectionFactory.CreateConnection();
            const string sql = "DELETE FROM Product WHERE Id = @ProductId";
            connection.Execute(sql, new { ProductId = id });
            return Results.NoContent();
        });

        group.MapGet("FindByName/{name}", (string name, SqlConnectionFactory sqlConnectionFactory) =>
        {
            var connection = sqlConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Product WHERE Name LIKE '%' + @Name + '%'";
            var products = connection.Query<Product>(sql,new { Name = name }); 
            return products;
        });

        group.MapGet("GetAllOrderByPrice", (SqlConnectionFactory sqlConnectionFactory) =>
        {
            var connection = sqlConnectionFactory.CreateConnection();
            const string sql = "SELECT * FROM Product ORDER BY Price DESC";
            var products = connection.Query<Product>(sql);
            return products;
        });

        group.MapPost("CreateMultiProduct",
            ([FromBody]IEnumerable<Product> products, SqlConnectionFactory sqlConnectionFactory) =>
            {
                var connection = sqlConnectionFactory.CreateConnection();
                const string sql = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
                foreach (var product in products)
                {
                    connection.Execute(sql, new { product.Name, product.Price });
                }
                return Results.Ok();
            });


    }
}