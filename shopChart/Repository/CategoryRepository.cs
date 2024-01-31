using Microsoft.EntityFrameworkCore;
using shopChart.Data;

namespace shopChart.Repository;

public class CategoryRepository : ICategoryRepository, ICategoryRepositorySubset
{
    private readonly ProductContext _context;

    public CategoryRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        try
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_context.Categories.Any(c => c.Id == category.Id))
            {
                throw;
            }
        }
    }

    public async Task RemoveCategoryAsync(int categoryIdToRemove)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryIdToRemove);

        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}