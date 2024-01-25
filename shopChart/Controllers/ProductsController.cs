using Microsoft.AspNetCore.Mvc;
using shopChart.Models;

namespace shopChart.Controllers;

public class ProductsController : Controller
{
    public List<ProductModel> Products { get; set; }
    
    public ProductsController()
    {
        Products = GetProducts();
    }
    
    public IActionResult Index()
    {
        return View(Products);
    }

    public IActionResult Details(int id)
    {
        var product = Products.Find(p => p.Id == id);
        return product == null ? NotFound() : View(product);
    }

    private List<ProductModel>? GetProducts()
    {
        return new List<ProductModel>();
    }
}