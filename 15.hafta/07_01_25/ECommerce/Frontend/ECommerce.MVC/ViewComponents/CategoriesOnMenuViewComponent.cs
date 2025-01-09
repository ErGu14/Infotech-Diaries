using System;
using ECommerce.MVC.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class CategoriesOnMenuViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoriesOnMenuViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetActiveCategoriesAsync();
        return View(categories);
    }
}
