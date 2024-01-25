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

    private List<ProductModel>? GetProducts()
    {
        return new List<ProductModel>();
    }
}