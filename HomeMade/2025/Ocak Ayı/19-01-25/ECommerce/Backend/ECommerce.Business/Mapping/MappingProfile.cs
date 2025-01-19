using AutoMapper;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Categories, opt => opt.MapFrom(x => x.ProductCategories.Select(pc => pc.Category)))
                .ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();
            CreateMap<Basket, BasketDTO>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.BasketItems, opt => opt.MapFrom(src => src.BasketItems))
                .ReverseMap();
            CreateMap<Basket, BasketCreateDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();
            CreateMap<BasketItem, BasketItemCreateDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemUpdateDTO>().ReverseMap();
            CreateMap<BasketItemRemoveDTO, BasketItem>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ReverseMap();
            CreateMap<OrderItem, OrderItemCreateDTO>().ReverseMap(); // Bu satırı ekleyin
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(src => src.ApplicationUser))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
            CreateMap<Order, OrderCreateDTO>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
        }
    }
}
