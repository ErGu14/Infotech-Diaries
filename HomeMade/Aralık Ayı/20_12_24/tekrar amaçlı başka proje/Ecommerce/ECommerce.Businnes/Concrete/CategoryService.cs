using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IGenericRepository<Category> _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper/*, IGenericRepository<Category> repository*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_repository = _unitOfWork.GetRepository<Category>();
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO);
           await _unitOfWork.GetRepository<Category>().AddAsync(category);
           var result = await _unitOfWork.SaveChangesAsync();
            if(result <= 0) // kayıt gerçekleşmediyse veya gerçekleşemediyse bunu return etsin
            {
                return ResponseDTO<CategoryDTO>.Fail("Bir Hata Oluştu!",500);
            }
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO,201); //created


        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
            var count = await _unitOfWork.GetRepository<Category>().CountAsync();
            return ResponseDTO<int>.Success(count, 200);

        }

        public async Task<ResponseDTO<int>> CountAsync(bool? isActive)
        {
            var count = await _unitOfWork.GetRepository<Category>().CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, 200);

        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryId);
            if (category == null)
            {
                return ResponseDTO<NoContent>.Fail("Kategori Bulunamadı",StatusCodes.Status404NotFound);
            }
            _unitOfWork.GetRepository<Category>().Delete(category);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status204NoContent);

        }

        
        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            if(categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Sunucuda Bir Sorun Oluştu, Daha Sonra Tekrar Deneyiniz",500);
            }
            if(categories.Count() == 0)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Kategori Bulunamadı",StatusCodes.Status404NotFound);
            }
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs,StatusCodes.Status200OK);

        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isActive)
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsActive == isActive);
            if (categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Sunucuda Bir Sorun Oluştu, Daha Sonra Tekrar Deneyiniz", 500);
            }
            if (categories.Count() == 0)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Kategori Bulunamadı", StatusCodes.Status404NotFound);
            }
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, StatusCodes.Status200OK);

        }


        public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
        {

            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            if(category == null)
            {
                return ResponseDTO<CategoryDTO>.Fail("Böyle bir kategori bulunamadı",404);
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existsCategory = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUpdateDTO.Id); // Dışardan gelen Id ile entitydeki Id ye göre çekme
            if (existsCategory == null)
            {
                return ResponseDTO<NoContent>.Fail("Kategori Bulunamadı",StatusCodes.Status404NotFound);
            }
            _mapper.Map(categoryUpdateDTO,existsCategory); // dışardna gelen id lişeyi exist in içine at
            //existsCategory.Name = categoryUpdateDto.Name yaptık aslında yukarda
            existsCategory.ModifiedDate = DateTime.Now;
            _unitOfWork.GetRepository<Category>().Update(existsCategory);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status204NoContent);

        }

        public async Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            if( category == null)
            {
                return ResponseDTO<bool>.Fail("Kategori Bulunamadı",404);
            }
            category.IsActive = !category.IsActive; // categorydeki isActiv i ne ise ters çevir yani T ise F , F ise T yap
            _unitOfWork.GetRepository<Category>().Update(category);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<bool>.Success(category.IsActive, 200);

        }
    }
}
