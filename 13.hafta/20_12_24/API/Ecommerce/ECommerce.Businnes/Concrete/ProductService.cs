using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository; // generic yapısını oluşturuyorum ve kısa bir şekilde kullanabilcem örnek ahmet dediğim zaman bu generic yapıyı kullanıcak bu bilgi dışardan gelmiceği için ctor oluşturmama gerek yok

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = _unitOfWork.GetRepository<Product>(); 
        }

        public async Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO)
        {
            var product = _mapper.Map<Product>(productCreateDTO);
            await _productRepository.AddAsync(product);
            var result = await _unitOfWork.SaveChangesAsync();
            if(result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("sunucu hatası", 500);
            }
            //product veri tabanına kaydedildiği için bir id değerine sahip. Şimdi ProductCategories işlemlerini yapabiliriz.
            product.ProductCategories = productCreateDTO.CategoryIds.Select(cId => new ProductCategory {
            
                ProductId = product.Id,
                CategoryId = cId

            }).ToList(); //kategori id leri içinde dönüyorum   şimdi burdaki olay şöyle product ile kategorileri eşlicem ve her cId için o seçili olan product id ye aktar diyoruz ve ortak tablomuza ekleme yapıyoruz ama kaydetmiyoruz update diyip kaydedicez

            _productRepository.Update(product); //değişiklikleri update ile aktar diyoruz
            result = await _unitOfWork.SaveChangesAsync();

            if (result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("sunucu hatası", 500);
            }
            var productDto = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDto,201);


        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün Bulunamadı",404);
            }
            _productRepository.Delete(product);
            var save = await _unitOfWork.SaveChangesAsync();
            if (save <= 0)
            {
                return ResponseDTO<NoContent>.Fail("Sorun oluştu", 500);
            }
            return ResponseDTO<NoContent>.Success(200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var product = await _productRepository.GetAllAsync();
            if(product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Getirelemedi Sunucuda Sorun var",500);
            }
            if(!product.Any()) //herhangi bir şey yoksa anlamında
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiçbir Ürün Bulunmamaktadır", 404);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(product); //entity olarak ayarladığımız şeyi burda dtoya çeviriyoruz ama listeli bir dtoya çeviriyoruz

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs,200); // kategoride ne yaptıysak nerdeyse her şey aynı zorlanmana gerek yok eğer zorlanıyorsan merak etme yapa yapa alışıcaksın.
        }

        public Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ProductDTO>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<int>> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<int>> GetCountAsync(bool? isActive)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<int>> GetCountByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateeDTO)
        {
            throw new NotImplementedException();
        }
    }
}






/*
 
 -- Businnes katmanının diğer adı service olarak da görebilirsiniz
 
-- abstract içindeki interfacelere EntityNameService ismi sıkça verilirken, Concrete içindeki clas'lara EntityNameService,EntityNameManager gibi simmler verildiği görebilirsiniz
 */