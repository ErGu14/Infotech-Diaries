using AutoMapper;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos;
using ECommerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Mapping
{
    public class MappingProfile : Profile // mapping işlemi yaparken profile classını çağırıyoruz
    {
        public MappingProfile() {  // dışardan çağırcağımızdan dolayıda ctor oluşturuyoruz
        
                CreateMap<Category,CategoryDTO>().ReverseMap(); // category verisini dto olan kategoriye maple ve aynı şekilde bu işlemi tersinede yap yani dto yu normal kategoriye döndür
                CreateMap<Category,CategoryCreateDTO>().ReverseMap();
                CreateMap<Category,CategoryUpdateDTO>().ReverseMap();

                CreateMap<Book, BookDTO>().ReverseMap();
                CreateMap<Book, BookCreateDTO>().ReverseMap();
                CreateMap<Book, BookUpdateDTO>().ReverseMap();
            
        }
    }
}
 // şimdi ben bunu dışarıya çağırdığımda bu işleme ilk olarak NEYE döndüreceğimizi sonra NEYİ döndüreceğimizi yazıcaz