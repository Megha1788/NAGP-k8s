using Microsoft.AspNetCore.Http;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services
builder.Services.AddControllers();
 
var app = builder.Build();
 
// Home Page UI
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
 
    await context.Response.WriteAsync("""
<html>
 
<head>
<title>NAGP Products API</title>
 
<style>
 
body{
font-family:Arial;
padding:40px;
background:#f5f5f5;
}
 
.container{
background:white;
padding:30px;
border-radius:10px;
width:600px;
box-shadow:0 0 10px rgba(0,0,0,.1);
}
 
a{
display:inline-block;
padding:12px 20px;
background:#4CAF50;
color:white;
text-decoration:none;
border-radius:5px;
}
 
a:hover{
background:#3d9140;
}
 
</style>
 
</head>
 
<body>
 
<div class="container">
 
<h1>NAGP Assignment</h1>
 
<p>Multi-tier Kubernetes Application</p>
 
<p>Open products:</p>
 
<a href="/products">
View Products
</a>
 
<br><br>
 
<a href="/ui">
Open Products UI
</a>
 
</div>
 
</body>
 
</html>
""");
});
 
// Controller routes
app.MapControllers();
 
app.Run();