using Microsoft.EntityFrameworkCore;
using shopChart.Data;

namespace shopChart.Repository;

public class Repository : IRepository
{
    private readonly ProductContext _context;

    public Repository(ProductContext context)
    {
        this._context = context;
    }

    public async Task<List<Product>> GetAllProductAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(m => m.Id == productId);
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        try
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_context.Products.Any(p => p.Id == product.Id))
            {
                // product exists and update exception is real
                throw;
            }

        }
    }
}