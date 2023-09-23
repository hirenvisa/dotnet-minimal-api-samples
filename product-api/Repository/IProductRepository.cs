using product_api.Model;

namespace product_api.Repository;

public interface IProductRepository
{
    List<Product> getProducts();
    Product? GetProductById(Guid id);
}
