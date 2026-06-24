using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using service_api.Models;
using System.Text;
 
namespace service_api.Controllers;
 
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly string _connectionString;
 
    public ProductsController()
    {
        _connectionString =
            $"Host={Environment.GetEnvironmentVariable("DB_HOST")};" +
            $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
            $"Username={Environment.GetEnvironmentVariable("DB_USER")};" +
            $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
            $"Pooling=true;Minimum Pool Size=5;Maximum Pool Size=20;";
    }
 
    [HttpGet("/products")]
    public async Task<IActionResult> GetProducts()
    {
        using var connection =
            new NpgsqlConnection(_connectionString);
 
        var products =
            await connection.QueryAsync<Product>(
                "SELECT * FROM products");
 
        return Ok(products);
    }
 
    [HttpGet("/ui")]
    public async Task<IActionResult> GetProductsUI()
    {
        using var connection =
            new NpgsqlConnection(_connectionString);
 
        var products =
            await connection.QueryAsync<Product>(
                "SELECT * FROM products");
 
        var html = new StringBuilder();
 
        html.Append("""
<html>
<head>
<title>Products Dashboard</title>
 
<style>
 
body{
font-family:Arial;
padding:40px;
background:#f5f5f5;
}
 
h1{
color:#333;
}
 
table{
width:70%;
border-collapse:collapse;
background:white;
}
 
th{
background:#4CAF50;
color:white;
padding:12px;
}
 
td{
padding:12px;
border:1px solid #ddd;
}
 
tr:hover{
background:#f0f0f0;
}
 
</style>
 
</head>
 
<body>
 
<h1>Products</h1>
 
<table>
 
<tr>
<th>ID</th>
<th>Name</th>
<th>Price</th>
</tr>
""");
 
        foreach (var p in products)
        {
            html.Append($"""
<tr>
<td>{p.Id}</td>
<td>{p.Name}</td>
<td>{p.Price}</td>
</tr>
""");
        }
 
        html.Append("""
</table>
 
</body>
 
</html>
""");
 
        return Content(
            html.ToString(),
            "text/html");
    }
}