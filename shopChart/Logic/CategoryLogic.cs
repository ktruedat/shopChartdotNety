using shopChart.Models;
using shopChart.Repository;

namespace shopChart.Logic;

public class CategoryLogic : ICategoryLogic
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryLogic(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return categories.Select(CategoryModel.FromCategory).ToList();
    }

    public async Task<CategoryModel?> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        return category == null ? null : CategoryModel.FromCategory(category);
    }

    public async Task AddNewCategory(CategoryModel categoryToAdd)
    {
        var categoryToSave = categoryToAdd.ToCategory();
        await _categoryRepository.AddCategoryAsync(categoryToSave);
    }

    public async Task RemoveCategory(int id)
    {
        await _categoryRepository.RemoveCategoryAsync(id);
    }

    public async Task UpdateCategory(CategoryModel categoryToUpdate)
    {
        var categoryToSave = categoryToUpdate.ToCategory();
        await _categoryRepository.UpdateCategoryAsync(categoryToSave);
    }
}