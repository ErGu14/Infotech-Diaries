using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<CategoryDTO>> GetAsync(int id);//Ok
        Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync();//Ok
        Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isActive);//Ok
        Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO);//Ok
        Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO);//Ok
        Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId);//Ok
        Task<ResponseDTO<int>> CountAsync();//Ok
        Task<ResponseDTO<int>> CountAsync(bool? isActive);//Ok
        Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id);
    }
}
