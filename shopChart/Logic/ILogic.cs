using shopChart.Data;
using shopChart.Models;

namespace shopChart.Logic;

public interface IProductLogic
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel?> GetProductById(int productId);
    Task AddNewProduct(ProductModel productToAdd);
    Task RemoveProduct(int id);
    Task UpdateProduct(ProductModel productToUpdate);
    Task<ProductModel> InitializeProductModel();
}

public interface ICategoryLogic
{
    Task<List<CategoryModel>> GetAllCategories();
    Task<CategoryModel?> GetCategoryById(int categoryId);
    Task AddNewCategory(CategoryModel categoryToAdd);
    Task RemoveCategory(int id);
    Task UpdateCategory(CategoryModel categoryToUpdate);
}