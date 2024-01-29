using shopChart.Models;
using shopChart.Repository;

namespace shopChart.Logic;

public class ProductLogic : IProductLogic
{
    private readonly IProductRepository _productRepository;

    public ProductLogic(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return products.Select(ProductModel.FromProduct).ToList();
    }

    public async Task<ProductModel?> GetProductById(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return product == null ? null : ProductModel.FromProduct(product);
    }

    public async Task AddNewProduct(ProductModel productToAdd)
    {
        var productToSave = productToAdd.ToProduct();
        await _productRepository.AddProductAsync(productToSave);
    }

    public async Task RemoveProduct(int id)
    {
        await _productRepository.RemoveProductAsync(id);
    }

    public async Task UpdateProduct(ProductModel productToUpdate)
    {
        var productToSave = productToUpdate.ToProduct();
        await _productRepository.UpdateProductAsync(productToSave);
    }
}