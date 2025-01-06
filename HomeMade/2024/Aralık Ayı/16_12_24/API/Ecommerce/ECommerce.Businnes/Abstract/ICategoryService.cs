using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface ICategoryService // Burda T kullanmama gerek yok çünkü zaten T tipim belli
    {
       Task<ResponseDTO<CategoryDTO>> GetAsync(int id);

        Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO);

        Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryCreateDTO);

        Task<ResponseDTO<NoContent>> DeleteAsync(int id); // update create add ve get komutlarında dışardan her zaman bir paramatre gelicek şekilde ayarlicaz bunu unutma!!!!

        Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(); //response türünde liste olarak bir categoryDTO nesnesi yarat ve getallasync ile buna seslen

        Task<ResponseDTO<int>> CountAsync(); // ben servislerde her bir şeyi oluşturucaksam response dto kullanmalıyım çünkü JSON formatına dönüştürüceğim için bilgilerimin dataya erorlere vs kaydedilmesi lazım




    }
}
