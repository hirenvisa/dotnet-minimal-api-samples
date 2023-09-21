using product_api.Model;

namespace product_api.Repository;

public class ProductRepository
{
    private static List<Product> _products = new List<Product>();
    public List<Product> Get()
    {
        _products = new List<Product>()
        {
            new Product(Guid.NewGuid(), "Product 1", 3),
            new Product(Guid.NewGuid(), "Product 2", 3),
            new Product(Guid.NewGuid(), "Product 3", 5),
        };

        return _products;
    }

    internal Product? GetById(Guid id)
    { 
        return _products.FirstOrDefault(q => q.Id == id);    
    }
}
