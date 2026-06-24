using Dapper;
using Npgsql;
 
var builder =
    WebApplication.CreateBuilder(args);
 
var app =
    builder.Build();
 
app.MapGet("/products",
async () =>
{
var host =
Environment.GetEnvironmentVariable("DB_HOST");
 
var db =
Environment.GetEnvironmentVariable("DB_NAME");
 
var user =
Environment.GetEnvironmentVariable("DB_USER");
 
var pwd =
Environment.GetEnvironmentVariable("DB_PASSWORD");
 
var cs =
$"Host={host};" +
$"Database={db};" +
$"Username={user};" +
$"Password={pwd};" +
"Pooling=true;" +
"Minimum Pool Size=5;" +
"Maximum Pool Size=20;";
 
using var conn =
new NpgsqlConnection(cs);
 
var result =
await conn.QueryAsync(
"SELECT * FROM products"
);
 
return Results.Ok(result);
 
});
 
app.Run();