using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _map;

        public BookService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }



        public async Task<ResponseDTO<BookDTO>> AddAsync(BookCreateDTO bookCreateDTO)
        {
            Book book =  _map.Map<Book>(bookCreateDTO);
            await _unitOfWork.GetRepository<Book>().AddAsync(book); // getir
            var result = await _unitOfWork.SaveChangesAsync();    // int döndürceği için bir verinin içine atacağız
            if (result <= 0) {

                return ResponseDTO<BookDTO>.Fail("Sunucuda Hata Oluştu", 500);
            }
            
            var dto = _map.Map<BookDTO>(book);
            return ResponseDTO<BookDTO>.Success(dto,201);
        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
           var result = await _unitOfWork.GetRepository<Book>().CountAsync();
            return ResponseDTO<int>.Success(result, 200);
        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int id)
        {
            var book = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book == null) {
                return ResponseDTO<NoContent>.Fail("Kitap Bulunamadı", 404);
            }

            _unitOfWork.GetRepository<Book>().Delete(book);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0) { 

                return ResponseDTO<NoContent>.Fail("Sunucuda bir hata oluştu", 500);

            }
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<BookDTO>>> GetAllAsync()
        {
            var result = await _unitOfWork.GetRepository<Book>().GetAllAsync();
            
            if(result.Count() <= 0)
            {
                return ResponseDTO<IEnumerable<BookDTO>>.Fail("Sunucuda Bir Hata Oluştu", 500);
            }
            if (result == null) {
                return ResponseDTO<IEnumerable<BookDTO>>.Fail("Kitaplar Bulunamadı",404);
            }
            var dto = _map.Map<IEnumerable<BookDTO>>(result); // book olanları çekiyorum yukardan ve burada dto ya çeviriyorum
            return ResponseDTO<IEnumerable<BookDTO>>.Success(dto, 201);
        }

        public async Task<ResponseDTO<BookDTO>> GetAsync(int id)
        {
            var books = await _unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (books == null) {
                return ResponseDTO<BookDTO>.Fail("Böyle Bir Kitap Yok", 404);
            }
            var dto = _map.Map<BookDTO>(books);
            return ResponseDTO<BookDTO>.Success(dto,200);
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(BookUpdateDTO bookUpdateDTO)
        {
           
            Book book = await _unitOfWork.GetRepository<Book>().GetByIdAsync(bookUpdateDTO.Id);
            if (book == null) {
                return ResponseDTO<NoContent>.Fail("Kitap Bulunamadı", 404);
            }
           
            _map.Map(bookUpdateDTO, book);
            
            
            _unitOfWork.GetRepository<Book>().Update(book);
            var result =  await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                return ResponseDTO<NoContent>.Fail("Sunucu Hatası", 500);
            }
            

            
            return ResponseDTO<NoContent>.Success(200);

        }

        
    }
}
