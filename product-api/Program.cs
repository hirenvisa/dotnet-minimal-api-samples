using product_api.Model;
using product_api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductRepository, InMemoryProductRepository>();

var app = builder.Build();
app.UseHttpsRedirection();

app.Map("/products/", (IProductRepository productRepository) =>
{
    return productRepository.getProducts();
});

app.Map("/product/{id}", (IProductRepository productRepository, Guid id) =>
{ 
    var product = productRepository.GetProductById(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.Run();
