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

    private List<ProductModel>? GetProducts()
    {
        return new List<ProductModel>();
    }
}