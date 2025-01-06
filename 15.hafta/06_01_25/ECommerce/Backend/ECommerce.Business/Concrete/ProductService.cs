using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IImageService _imageService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Category> categoryRepository, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = _unitOfWork.GetRepository<Product>();
            _categoryRepository = categoryRepository;
            _imageService = imageService;
        }

        public async Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);
            if (productCreateDTO.Image != null)
            {
                var imageUrl = await _imageService.UploadImageAsync(productCreateDTO.Image);
                product.ImageUrl = imageUrl;
            }
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("Bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            // Artık Product veri tabanına kaydedildiği için bir Id değerine sahip. Şimdi ProductCategory işlemlerini yapabiliriz.
            product.ProductCategories =
                productCreateDTO.CategoryIds.Select(cId => new ProductCategory
                {
                    ProductId= product.Id,
                    CategoryId=cId
                }).ToList();
            _productRepository.Update(product);
            result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("Bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            ProductDTO productDTO = (await GetWithCategoriesAsync(product.Id)).Data;
            return ResponseDTO<ProductDTO>.Success(productDTO, StatusCodes.Status201Created);
        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün bulunamadığı için işlem tamamlanamadı!", StatusCodes.Status404NotFound);
            }
            _productRepository.Delete(product);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                return ResponseDTO<NoContent>.Fail("Bir sorun oluştu", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if(products == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            //if (products?.Count() == 0)
            if(!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı!",StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive)
        {
            var products = await _productRepository.GetAllAsync(x=>x.IsActive==isActive);
            if (products == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            //if (products?.Count() == 0)
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive, int? take = null)
        {
            var products = await _productRepository.GetAllAsync(
                predicate: x => x.IsActive == isActive,
                orderBy: query => query.OrderByDescending(x => x.CreatedDate),
                take: take
            );
            if (products == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync()
        {
            var products = await _productRepository.GetAllAsync(
                x => x.IsActive == true,
                null, null,
                query => query.Include(p=>p.ProductCategories).ThenInclude(pc=>pc.Category)
                );
            if (products == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            //if (products?.Count() == 0)
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<ProductDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail("İlgili ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetAllAsync(
                x => x.IsActive == true && x.ProductCategories.Any(pc => pc.CategoryId == categoryId)
                );
            if (products == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            //if (products?.Count() == 0)
            if (!products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiç ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<int>> GetCountAsync()
        {
            var count = await _productRepository.CountAsync();
            return ResponseDTO<int>.Success(count,StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<int>> GetCountAsync(bool? isActive)
        {
            var count = await _productRepository.CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<int>> GetCountByCategory(int categoryId)
        {
            var categoryIsExists = await _categoryRepository.ExistsAsync(x=>x.Id== categoryId);
            if (!categoryIsExists)
            {
                return ResponseDTO<int>.Fail("Böyle bir kategori bulunamadı!", StatusCodes.Status404NotFound);
            }
            var count = await _productRepository.CountAsync(
                x => x.IsActive == true && x.ProductCategories.Any(pc=>pc.CategoryId==categoryId)
            );
            return ResponseDTO<int>.Success(count, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id)
        {
            var product = await _productRepository.GetAsync(
                x => x.Id == id,
                query => query.Include(p=>p.ProductCategories).ThenInclude(pc=>pc.Category)); 
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail("İlgili ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateDTO)
        {
            var product = await _productRepository.GetAsync(p => p.Id == productUpdateDTO.Id, query => query.Include(x => x.ProductCategories));
            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail("İlgili ürün bulunamadığı için, güncelleme yapılamadı!", StatusCodes.Status404NotFound);
            }
            if (!product.IsActive)
            {
                return ResponseDTO<NoContent>.Fail("İlgili ürün aktif olmadığı için, güncelleme yapılamadı!", StatusCodes.Status400BadRequest);
            }

            if (productUpdateDTO.Image != null)
            {
                var imageUrl = await _imageService.UploadImageAsync(productUpdateDTO.Image);
                product.ImageUrl = imageUrl;
            }

            product.ProductCategories.Clear();
            _productRepository.Update(_mapper.Map<Product>(product));
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(productUpdateDTO, product);

            product.ProductCategories =
                productUpdateDTO
                .CategoryIds.Select(cId => new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = cId
                }).ToList();
            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return ResponseDTO<bool>.Fail("İlgili ürün bulunamadığı için, işlem yapılamadı!", StatusCodes.Status404NotFound);
            }
            product.IsActive=!product.IsActive;
            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<bool>.Success(product.IsActive,StatusCodes.Status200OK);
        }
    }
}




