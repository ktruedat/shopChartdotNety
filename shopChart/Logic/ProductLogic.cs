using Microsoft.AspNetCore.Mvc.Rendering;
using shopChart.Models;
using shopChart.Repository;

namespace shopChart.Logic;

public class ProductLogic : IProductLogic
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepositorySubset _categoryRepositorySubset;

    public ProductLogic(IProductRepository productRepository, ICategoryRepositorySubset categoryRepositorySubset)
    {
        _productRepository = productRepository;
        _categoryRepositorySubset = categoryRepositorySubset;
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

    public async Task<ProductModel> InitializeProductModel()
    {
        return new ProductModel
        {
            AvailableCategories = await GetAvailableCategoriesFromDb()
        };
    }

    public async Task GetAvailableCategories(ProductModel productModel)
    {
        productModel.AvailableCategories = await GetAvailableCategoriesFromDb();
    }

    private async Task<List<SelectListItem>> GetAvailableCategoriesFromDb()
    {
        var categories = await _categoryRepositorySubset.GetAllCategoriesAsync();
        var listToReturn = new List<SelectListItem> { new("None", "") };
        var availableCategoryiesList =
            categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
        listToReturn.AddRange(availableCategoryiesList);
        return listToReturn;
    }


}