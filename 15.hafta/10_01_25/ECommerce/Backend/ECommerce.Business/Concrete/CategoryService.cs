using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            Category category = _mapper.Map<Category>(categoryCreateDTO);
            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)//Eğer kayıt gerçekleşmemişse
            {
                return ResponseDTO<CategoryDTO>.Fail("Bir hata oluştu!", 500);
            }
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, 201);
        }

        public async Task<ResponseDTO<int>> CountAsync()
        {
            var count = await _unitOfWork.GetRepository<Category>().CountAsync();
            return ResponseDTO<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<int>> CountAsync(bool? isActive)
        {
            var count = await _unitOfWork.GetRepository<Category>().CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryId);
            if (category == null)
            {
                return ResponseDTO<NoContent>.Fail("Kategori bulunamadığı için işlem yapılamadı", StatusCodes.Status404NotFound);
            }
            _unitOfWork.GetRepository<Category>().Delete(category);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            if (categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Sunucuda bir sorun oluştu, daha sonra tekrar deneyiniz", 500);
            }
            if (categories.Count() == 0)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Hiç kategori bulunamadı!", StatusCodes.Status404NotFound);
            }

            var categoryDTOs = categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                ProductCount = _unitOfWork.GetRepository<ProductCategory>().CountAsync(pc => pc.CategoryId == category.Id).Result
            }).ToList();

            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllAsync(bool? isActive)
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsActive == isActive);
            if (categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Sunucuda bir sorun oluştu, daha sonra tekrar deneyiniz", 500);
            }
            if (categories.Count() == 0)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail("Hiç kategori bulunamadı!", StatusCodes.Status404NotFound);
            }

            var categoryDTOs = categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
                ImageUrl = category.ImageUrl,
                ProductCount = _unitOfWork.GetRepository<ProductCategory>().CountAsync(pc => pc.CategoryId == category.Id).Result
            }).ToList();

            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<CategoryDTO>> GetAsync(int id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            if (category == null)
            {
                return ResponseDTO<CategoryDTO>.Fail("İlgili kategori bulunamadı", StatusCodes.Status404NotFound);
            }
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existsCategory = await _unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUpdateDTO.Id);
            if (existsCategory == null)
            {
                return ResponseDTO<NoContent>.Fail("Kategori bulunamadığı için işlem yapılamadı", StatusCodes.Status404NotFound);
            }
            _mapper.Map(categoryUpdateDTO, existsCategory);
            existsCategory.ModifiedDate = DateTime.UtcNow;
            _unitOfWork.GetRepository<Category>().Update(existsCategory);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            if (category == null)
            {
                return ResponseDTO<bool>.Fail("Kategori bulunamadığı için işlem yapılamadı", StatusCodes.Status404NotFound);
            }
            category.IsActive = !category.IsActive;
            _unitOfWork.GetRepository<Category>().Update(category);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<bool>.Success(category.IsActive, StatusCodes.Status200OK);
        }
    }
}
