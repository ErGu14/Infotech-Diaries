using Azure;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<CategoryDTO>> GetAsync(int id);
        Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync();
        Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO); // oluşturysa bir veri dönüdrmemize gerek yok sadece oluştuysa başarılı desin dedik

        Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId);
        Task<ResponseDTO<int>> CountAsync();



    }
}
