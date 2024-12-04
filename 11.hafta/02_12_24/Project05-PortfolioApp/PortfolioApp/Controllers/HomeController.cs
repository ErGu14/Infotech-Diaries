using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Models;
using PortfolioApp.Models.Entities;

namespace PortfolioApp.Controllers;

public class HomeController : Controller
{
    //private readonly AppDbContext _context;
   
    
     
    public IActionResult Index()
    {
      
        return View();
    }



}




/*
     //LINQ : Language INtegrated Query
    // Söz Dizimi (Syntax):
    // 1- Query Syntax
    //2- Method Syntax


    /* 1- query syntax
        var sonuc = from item  in collection
                    where item.Price >100
                    orderby item.Name
                    select item
     

        2-Mehhod syntax
        var result = collection
                        .where(item =>item.price >100)
                        .orderby(item => item.name)
                        .select(item =>item)
     





   var categories = new List<Category>() {
            new Category { Id = 1,Name="Kategori1",Description="1",IsDeleted=true},
             new Category { Id = 2,Name="Kategori1",Description="2",IsDeleted=true},
              new Category { Id = 3,Name="Kategori1",Description="3",IsDeleted=true},
               new Category { Id = 4,Name="Kategori1",Description="4",IsDeleted=false},
                new Category { Id = 5,Name="Kategori1",Description="5",IsDeleted=true},
                 new Category { Id = 6,Name="Kategori1",Description="6",IsDeleted=true},
                  new Category { Id = 7,Name="Kategori1",Description="7",IsDeleted=true},
                   new Category { Id = 8,Name="Kategori1",Description="8",IsDeleted=false},
                    new Category { Id = 9,Name="Kategori1",Description="9",IsDeleted=true},
                     new Category { Id = 10,Name="Kategori1",Description="10",IsDeleted=false}
        };

        // 1- query syntax

        //var unDeletedCategories = from category in categories
        //                          where category.IsDeleted ==false
        //                          select category;

        // 2- method syntax 
        var unDeleted = categories.Where(c => c.IsDeleted == false).ToList();

 
 
 
 
 
 
 */
