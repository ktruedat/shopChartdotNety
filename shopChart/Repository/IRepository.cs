using shopChart.Data;

namespace shopChart.Repository;

public interface IProductRepository
{
 Task<List<Product>> GetAllProductsAsync();
 Task<Product?> GetProductByIdAsync(int productId);
 Task<Product> AddProductAsync(Product product);
 Task UpdateProductAsync(Product product);
 Task RemoveProductAsync(int productIdToRemove);
}

public interface ICategoryRepository
{
 Task<List<Category>> GetAllCategoriesAsync();
 Task<Category?> GetCategoryByIdAsync(int categoryId);
 Task<Category> AddCategoryAsync(Category category);
 Task UpdateCategoryAsync(Category category);
 Task RemoveCategoryAsync(int categoryIdToRemove);
}