using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<Category> _categoryRepository;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Category> categoryRepository = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = _unitOfWork.GetRepository<Product>();
            _categoryRepository = _unitOfWork.GetRepository<Category>();
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
            var productDto = (await GetWithCategoriesAsync(product.Id)).Data;
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

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive)
        {
            var product = await _productRepository.GetAllAsync(x => x.IsActive == isActive);
            if (product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Getirelemedi Sunucuda Sorun var", 500);
            }
            if (!product.Any()) //herhangi bir şey yoksa anlamında
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiçbir Ürün Bulunmamaktadır", 404);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(product); //entity olarak ayarladığımız şeyi burda dtoya çeviriyoruz ama listeli bir dtoya çeviriyoruz

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, 200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync()
        {
            var product = await _productRepository.GetAllAsync(x => x.IsActive ==true,null,query => query.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category)); // produc gelirken junc tableyi dahil et ve ordan kategori bilgilerini de at dedik
            if (product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Getirelemedi Sunucuda Sorun var", 500);
            }
            if (!product.Any()) //herhangi bir şey yoksa anlamında
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiçbir Ürün Bulunmamaktadır", 404);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(product); //entity olarak ayarladığımız şeyi burda dtoya çeviriyoruz ama listeli bir dtoya çeviriyoruz

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, 200);
        }

        public async Task<ResponseDTO<ProductDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün Bulunamadı", 404);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO,200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync(int categoryId)
        {
            var product = await _productRepository.GetAllAsync(x => x.IsActive == true && x.ProductCategories.Any(pc => pc.CategoryId == categoryId),null); // produc gelirken junc tableyi dahil et ve ordan kategori bilgilerini de at dedik
            if (product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Getirelemedi Sunucuda Sorun var", 500);
            }
            if (!product.Any()) //herhangi bir şey yoksa anlamında
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Hiçbir Ürün Bulunmamaktadır", 404);
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(product); //entity olarak ayarladığımız şeyi burda dtoya çeviriyoruz ama listeli bir dtoya çeviriyoruz

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, 200);
        }

        public async Task<ResponseDTO<int>> GetCountAsync()
        {
            var count = await _productRepository.CountAsync();
            return ResponseDTO<int>.Success(count,200);
        }

        public async Task<ResponseDTO<int>> GetCountAsync(bool? isActive)
        {
            var count = await _productRepository.CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, 200);
        }

        public async Task<ResponseDTO<int>> GetCountByCategoryAsync(int categoryId)
        {
            var categoryIsExitst = await _categoryRepository.ExixstAsync(x => x.Id == categoryId);
            if (!categoryIsExitst) {
                return ResponseDTO<int>.Fail("Böyle Bir Kategori Bulunmadı", 404);
            }
            var count = await _productRepository.CountAsync(x => x.IsActive == true && x.ProductCategories.Any(pc => pc.CategoryId == categoryId )); //true olanları getir ve dışardan gelen id ile veri tabanındakine eşitliyorum çünkü ben 3. kategori dediğim zaman bana veri tabanındaki 3 id li kategori ürünlerini sayıp getirsin.
            return ResponseDTO<int>.Success(count, 200);
        }

        public async Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id)
        {
            var product = await _productRepository.GetAsync(x => x.Id == id,
                query => query.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category)
                ) ;
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail("Ürün Bulunamadı", 404);
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO, 200);
        }

        public async Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateeDTO)
        {
            var product = await _productRepository.GetAsync(p => p.Id == productUpdateeDTO.Id,query => query.Include(x => x.ProductCategories) );
            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün Bulunamadı",404);
            }
            if(product.IsActive == false)
            {
                return ResponseDTO<NoContent>.Fail("Ürün aktif değildir", 400);

            }
            product.ProductCategories.Clear(); // kayıtlı işlemleri sil yani var olanları sil sana sonra diceklerimi ekle
            
             _productRepository.Update(_mapper.Map<Product>(product)); // productı producta çeviriyoruz yani dışardakini entitye eşitlicez
            await _unitOfWork.SaveChangesAsync();
            _mapper.Map(productUpdateeDTO, product); // verileri aktarıcaz
            product.ProductCategories = productUpdateeDTO.CategoryIds.Select(cId => new ProductCategory {
            
                ProductId = product.Id,
                CategoryId = cId
            }).ToList();
            _productRepository.Update(product);

            var result = await _unitOfWork.SaveChangesAsync();
            if(result <= 0)
            {
                return ResponseDTO<NoContent>.Fail("Kaydedilemedi",500);
            }
            return ResponseDTO<NoContent>.Success(204);
        }

        public async Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return ResponseDTO<bool>.Fail("Ürün Bulunamadı", 404);
            }
            product.IsActive = !product.IsActive;
            _productRepository.Update( product);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<bool>.Success(product.IsActive, 200);
        }
    }
}






/*
 
 -- Businnes katmanının diğer adı service olarak da görebilirsiniz
 
-- abstract içindeki interfacelere EntityNameService ismi sıkça verilirken, Concrete içindeki clas'lara EntityNameService,EntityNameManager gibi simmler verildiği görebilirsiniz
 */