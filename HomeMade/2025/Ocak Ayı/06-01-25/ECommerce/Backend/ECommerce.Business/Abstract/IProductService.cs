using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        Task<ResponseDTO<ProductDTO>> GetAsync(int id);
        Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id);
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync();
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive, int? take=null);
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync();//Aktif olanlar
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync(int categoryId);//Aktif olanlar
        Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(int id);
        Task<ResponseDTO<int>> GetCountAsync();
        Task<ResponseDTO<int>> GetCountAsync(bool? isActive);
        Task<ResponseDTO<int>> GetCountByCategory(int categoryId);//Aktif olanlar
        Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id);
    }
}
