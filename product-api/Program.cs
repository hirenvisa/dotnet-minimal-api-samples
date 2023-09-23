using product_api.Infrastructure;
using product_api.Model;
using product_api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinitions(typeof(Product));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseEndpointDefinitions();



app.Run();
