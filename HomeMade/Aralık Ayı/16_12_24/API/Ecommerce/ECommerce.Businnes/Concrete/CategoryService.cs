using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Businnes.Mapping;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _map;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper map)
        {
            _unitOfWork = unitOfWork;
            _map = map;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _map.Map<Category>(categoryCreateDTO);
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            var result = await _unitOfWork.SaveChangesAsync(); // int değer döndürcek    async mantık olacağından dolayı hep await kullancam
            if (result <= 0)
            {
                return ResponseDTO<CategoryDTO>.Fail("Bir Hata Oluştu", 500);
            }
            var dto = _map.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(dto, 201);





        }

        public Task<ResponseDTO<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            if (categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Sunucuda Hata Oluştu",500);
            }
            if(categories.Count() == 0)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Kategori Bulunamadı",404);
            }
            var dto = _map.Map<IEnumerable<CategoryDTO>>(categories);
            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(dto,200);

        }

        public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
        {
           var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            if (category == null) {
                return ResponseDTO<CategoryDTO>.Fail("Kategori Bulunamadı",404);
            }
            var dto = _map.Map<CategoryDTO>(category);
            
            return ResponseDTO<CategoryDTO>.Success(dto,200);

        }

        public Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
