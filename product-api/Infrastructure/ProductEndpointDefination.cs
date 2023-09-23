using Microsoft.AspNetCore.Builder;
using product_api.Model;
using product_api.Repository;
using static product_api.Infrastructure.ProductEndpointDefinition;

namespace product_api.Infrastructure;

public class ProductEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.Map("/products/", GetProducts);

        app.Map("/product/{id}", GetProductById);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
    }


    internal List<Product> GetProducts(IProductRepository productRepository)
    {
        return productRepository.getProducts();
    }

    internal IResult GetProductById(IProductRepository productRepository, Guid id)
    {
        var product = productRepository.GetProductById(id);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    }
}

public interface IEndpointDefinition
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(IServiceCollection services);
}