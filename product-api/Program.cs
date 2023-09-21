using product_api.Model;
using product_api.Repository;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();
app.UseHttpsRedirection();

app.Map("/products/", () =>
{
    var productRepository = new ProductRepository();
    return productRepository.Get();
});

app.Map("/products/{id}", (Guid id) =>
{
    var productRepository = new ProductRepository();
    var product = productRepository.GetById(id);

    return (product == null) ? null : product;
});

app.Run();
