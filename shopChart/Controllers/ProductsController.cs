using Microsoft.AspNetCore.Mvc;
using shopChart.Logic;
using shopChart.Models;

namespace shopChart.Controllers;

public class ProductsController : Controller
{
    private readonly IProductLogic _logic;

    // public List<ProductModel> Products { get; set; }
    
    public ProductsController(IProductLogic logic)
    {
        _logic = logic;
        // Products = GetProducts();
    }
    
    public async Task<IActionResult> Index()
    {
        var products = await _logic.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await  _logic.GetProductById(id);
        return product == null ? NotFound() : View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,IsActive")] ProductModel product)
    {
        if (ModelState.IsValid)
        {
            await _logic.AddNewProduct(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Name,Description,Price,IsActive")]
        ProductModel product)
    {
        if (id != product.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _logic.UpdateProduct(product);
            return RedirectToAction(nameof(System.Index));
        }

        return View(product);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null) return NotFound();

        return View(productModel);

    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _logic.RemoveProduct(id);
        return RedirectToAction(nameof(Index));
    }

    private List<ProductModel>? GetProducts()
    {
        return new List<ProductModel>();
    }
}