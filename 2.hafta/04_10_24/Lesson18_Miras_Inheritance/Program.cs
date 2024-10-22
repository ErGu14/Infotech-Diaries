using Lesson18_Miras_Inheritance.Eshop;
using Lesson18_Miras_Inheritance.Siniflar;
using System.ComponentModel.DataAnnotations;

namespace Lesson18_Miras_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arac Örneği
            /* Otomobil otomobil1 = new Otomobil();
             otomobil1.Tur = "Otomobil";
             otomobil1.Marka = "BMW";
             otomobil1.Model = "316i";
             otomobil1.DisplayInfo();
             otomobil1.KornaCal();
             Console.WriteLine();

             Vapur vapur1 = new Vapur();
             vapur1.Tur = "Gemi";
             vapur1.GemiAd = "Barbaros Hayrettin Paşa";
             vapur1.GemiNo = 1903;
             vapur1.DisplayInfo();
             vapur1.KornaCal();
             Console.WriteLine();*/
            #endregion

            List<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                    Id = 1,
                    name = "Apple",
                    Country = "USA",
                    Description = "Kendine Has Bir Marka",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,

                },
                new Brand()
                {
                    Id = 2,
                    name = "Samsung",
                    Country = "USA",
                    Description = "Kafasına Göre Takılıyor",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                },
                new Brand()
                {
                    Id = 3,
                    name = "Monster",
                    Country = "Turkey",
                    Description = "Canavar Falan Oyun Açmazsa Para iade(Yalan)",
                    IsActive = false,
                    CreatedDate = DateTime.Now,

                }


            };
            /*foreach (var brand in brands) {
                string isActive = brand.IsActive ? "AKtif" : "Pasif";
                Console.WriteLine($"{brand.Id}-{brand.name}-{isActive}");
            }*/
            Product product1 = new Product { 
                Id = 1,
                name="Macbook Aiar M2 16gb",
                Properties= "M2 İşlemci, 16 gb ram, 512 gb SSD",
                Price = 80000,
                TaxRate = 0.2m,
                BrandId =1,
            
            };
            Product product2 = new Product
            {
                Id = 2,
                name = "Iphone 13",
                Properties = "128 gb",
                Price = 50000,
                TaxRate = 0.2m,
                BrandId = 1,
            };
            Product product3 = new Product
            {
                Id = 3,
                name = "Lenova XYZ1",
                Properties = "Intel Core I7",
                Price = 70000,
                TaxRate = 0.2m,
                BrandId = 2,

            };
            Product product4 = new Product
            {
                Id = 4,
                name = "Monster Captiva",
                Properties = "AMD RYZEN 5",
                Price = 60000,
                TaxRate = 0.2m,
                BrandId = 3,

            };
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            string brandName="";
            foreach (Product product in products) {
                
                foreach (Brand brand in brands) { //Brand Id'ye göre BrandName Bulma
                    if (product.Id == brand.Id) {
                        brandName = brand.name;
                        break;
                    }
                }
                Console.WriteLine($"ID: {product.Id}\nÜrün : {product.name}-{brandName}");
            }
                
            
        }
    }
}
