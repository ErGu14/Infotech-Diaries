using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20_Interfaces.Eshop
{
    internal class Product : IBase, IDataServices
    {
        public int Id { get; set; }
        public string Name { get {

                return Name.ToUpper();
            
            } set {
                if (value.Length >= 5 && value.Length <= 10)
                {
                    Name = value;

                }
                else {
                    new ArgumentException("Ürün adı 5-10 Karakter arasında olmalı");
                }
            
            } }
        public DateTime CreatedDate { get ; set; }= DateTime.Now;
        public DateTime ModifiedDate { get ; set ; } = DateTime.Now;

        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Properties { get; set; }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
