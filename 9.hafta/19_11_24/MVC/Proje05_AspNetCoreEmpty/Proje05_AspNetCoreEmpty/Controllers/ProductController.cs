using Microsoft.AspNetCore.Mvc;
using Proje05_AspNetCoreEmpty.Models;

namespace Proje05_AspNetCoreEmpty.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<product> _products;
        public ProductController()
        {
            _products = [
                    new(){Id=1,Name="klima1",Description="klimalar1",ImageUrl="image1.jpg"},
                    new(){Id=2,Name="klima2",Description="klimalar2",ImageUrl="image2.jpg"},
                    new(){Id=3,Name="klima3",Description="klimalar3",ImageUrl="image3.jpg"},
                    new(){Id=4,Name="klima4",Description="klimalar4",ImageUrl="image4.jpg"},
                    new(){Id=5,Name="klima5",Description="klimalar5",ImageUrl="image5.jpg"},
                     new(){Id=6,Name="klima6",Description="klimalar6",ImageUrl="image5.jpg"},
                     new(){Id=7,Name="klima7",Description="klimalar1",ImageUrl="image1.jpg"},
                    new(){Id=8,Name="klima8",Description="klimalar2",ImageUrl="image2.jpg"},
                    new(){Id=9,Name="klima9",Description="klimalar3",ImageUrl="image3.jpg"},
                    new(){Id=10,Name="klima10",Description="klimalar4",ImageUrl="image4.jpg"},
                    new(){Id=11,Name="klima11",Description="klimalar5",ImageUrl="image5.jpg"},
                     new(){Id=12,Name="klima12",Description="klimalar6",ImageUrl="image5.jpg"}

                ];                                                    
        }                                                             
        public IActionResult Index()
        {
            ViewBag.Products = _products;

            return View();
        }
        public ActionResult Details(int id) {
            product product = new();            
            foreach(product p in _products)
            {
                if(p.Id == id)
                {
                    product = p;
                    break;
                }
            }
            ViewBag.product = product;
            return View(); 
        }
    }
}
