using System;
using ECommerce.MVC.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class CategoriesOnMenuViewComponent : ViewComponent // yeniden kullan�labilir bile�enler olu�turmam�za olanak tan� ve belirli g�r�n�m� render eder
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

// view Component = k���k ve kullan�l�r bir aray�z� par�ac��� olu�turmam�z� sa�lar ayn� partial gibi fakat bu kategorilerimiz de�i�ice�i i�in ele al�n�m� kolay olucak ve tekrar tekrar kullanabilece�iz

// component ise aray�zde belirli bir i�levi yerine getiren ba��ms�z ve yeniden kullan�labilir yaz�l�m birimidir.  Farkl� programlama dillerinde ve teknolojilerde bu kavram kullan�l�r ama farkl� yerlerde UI par�as�n� temsil eder (genel kullan�mda denilebilir yayg�n ad)