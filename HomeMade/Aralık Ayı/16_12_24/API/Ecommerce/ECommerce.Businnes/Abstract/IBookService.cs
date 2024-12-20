using ECommerce.Shared.Dtos;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IBookService
    {
        Task<ResponseDTO<BookDTO>> GetAsync(int id);
        Task<ResponseDTO<IEnumerable<BookDTO>>> GetAllAsync();

        Task<ResponseDTO<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(BookUpdateDTO bookUpdateDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(int id);

        Task<ResponseDTO<int>> CountAsync();



    }
}
