using AutoMapper;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Kategori Mapping
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category,CategoryUpdateDTO>().ReverseMap();



        }
    }
}
