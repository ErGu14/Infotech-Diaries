using System;
using ECommerce.MVC.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class CategoriesOnMenuViewComponent : ViewComponent // yeniden kullanýlabilir bileþenler oluþturmamýza olanak taný ve belirli görünümü render eder
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

// view Component = küçük ve kullanýlýr bir arayüzü parçacýðý oluþturmamýzý saðlar ayný partial gibi fakat bu kategorilerimiz deðiþiceði için ele alýnýmý kolay olucak ve tekrar tekrar kullanabileceðiz

// component ise arayüzde belirli bir iþlevi yerine getiren baðýmsýz ve yeniden kullanýlabilir yazýlým birimidir.  Farklý programlama dillerinde ve teknolojilerde bu kavram kullanýlýr ama farklý yerlerde UI parçasýný temsil eder (genel kullanýmda denilebilir yaygýn ad)