using Microsoft.AspNetCore.Mvc;
using shopChart.Logic;
using shopChart.Models;

namespace shopChart.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryLogic _logic;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(ICategoryLogic logic, ILogger<CategoriesController> logger)
    {
        _logic = logic;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _logic.GetAllCategories();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Create([Bind("Id,Name")] CategoryModel category)
    {
        if (ModelState.IsValid)
        {
            await _logic.AddNewCategory(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }


}

