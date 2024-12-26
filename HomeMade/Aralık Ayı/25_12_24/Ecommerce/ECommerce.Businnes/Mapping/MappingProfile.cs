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
            #region Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            #endregion


            #region Product


            CreateMap<Product, ProductDTO>().ForMember(dto => dto.Categories, option => option.MapFrom(pc => pc.ProductCategories.Select(c => c.Category))).ReverseMap();//formember yani şu propun veya şu kolonun ==> dtonun içerisinde bulunan categories nav prop. unu seç sonra options ile hangi mapde yani nereye eşitliceksen bir navigate ediceksen onu seçiyorsun yani ara tabloyu vve select diyerek ara tablodaki hangi kolonu seçiceksin onu belirtiyorsun.   daha anlaşılır şekilde şunu demiş oluyorum dtodaki categoriesi seç bunu map from diyerek junction table olan ProductCategories'e gönder sonra içerisindeki Categoryi SEÇEREK dtodaki category bilgilerini aradaki J.table ın içine at ne kadar kategori bilgisi varsa zaten dbsetlerimizi oluşttururken her birine hashset dedik yani 1 kere oluşucak daha oluşmicak bu sayede küsürlerce 1 1 gibi identitylerimiz olmicak
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();


            #endregion



        }
    }
}
