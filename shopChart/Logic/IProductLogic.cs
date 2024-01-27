using shopChart.Models;

namespace shopChart.Logic;

public interface IProductLogic
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel?> GetProductById();
    Task AddNewProduct(ProductModel productToAdd);
    Task RemoveProduct(int id);
    Task UpdateProduct(ProductModel productToRemove);
}