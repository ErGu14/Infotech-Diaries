using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IProductService
    {
        Task<ResponseDTO<ProductDTO>> GetAsync(int id);
        Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id); 
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(); //response sebebi kullanıcıya cevap döndürmek amaçlı
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive); 
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync();  // aktif olanlar 

        // şu kadegorideki ürünleri getir
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync(); // aktif olanlar

        Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateeDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(int id);
        Task<ResponseDTO<int>> GetCountAsync();
        Task<ResponseDTO<int>> GetCountAsync(bool? isActive);
        Task<ResponseDTO<int>> GetCountByCategoryAsync(int categoryId); //aktif olanlar 
        

    }
}
