using shopChart.Data;

namespace shopChart.Repository;

public interface IRepository
{
 Task<List<Product>> GetAllProductsAsync();
 Task<Product?> GetProductByIdAsync(int productId);
 Task<Product> AddProductAsync(Product product);
 Task UpdateProductAsync(Product product);
 Task RemoveProductAsync(int productIdToRemove);
}