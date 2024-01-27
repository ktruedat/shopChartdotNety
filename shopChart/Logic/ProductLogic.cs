using shopChart.Models;
using shopChart.Repository;

namespace shopChart.Logic;

public class ProductLogic
{
    private readonly IRepository _repository;

    public ProductLogic(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _repository.GetAllProductsAsync();
        return products.Select(ProductModel.FromProduct).ToList();
    }

    public async Task<ProductModel?> GetProductById(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        return product == null ? null : ProductModel.FromProduct(product);
    }

    public async Task AddNewProduct(ProductModel productToAdd)
    {
        var productToSave = productToAdd.ToProduct();
        await _repository.AddProductAsync(productToSave);
    }

    public async Task RemoveProduct(int id)
    {
        await _repository.RemoveProductAsync(id);
    }
}