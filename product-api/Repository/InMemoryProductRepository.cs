using product_api.Model;

namespace product_api.Repository;

public class InMemoryProductRepository : IProductRepository
{
    private static List<Product> _products = new List<Product>();

    public InMemoryProductRepository()
    {
        _products = new List<Product>()
        {
            new Product(Guid.NewGuid(), "Product 1", 3),
            new Product(Guid.NewGuid(), "Product 2", 3),
            new Product(Guid.NewGuid(), "Product 3", 5),
        };
    }

    public List<Product> getProducts()
    {
        return _products;
    }

    public Product? GetProductById(Guid id)
    {
        return _products.FirstOrDefault(q => q.Id == id);
    }
 }
