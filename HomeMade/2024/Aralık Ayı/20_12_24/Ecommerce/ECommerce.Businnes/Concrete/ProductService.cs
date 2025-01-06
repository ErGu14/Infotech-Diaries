using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _repsitory;
        


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repsitory = _unitOfWork.GetRepository<Product>(); // _repository yi her çağırdığımda bu kod dönücek
        }

        public async Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO)
        {
            // dışardan gelen dto yu ilk önce entitye eşliyoruz 
            var product = _mapper.Map<Product>(productCreateDTO);
            await _repsitory.AddAsync(product);
           var result = await _unitOfWork.SaveChangesAsync();
            if(result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("Sunucuda Bir Hata Meydana Geldi", 500);
            }
            // şimdi bu junction tablemizi güncellicez güncellememiz için ilk önce bize gelen ürün bilgisinin Id si lazım şuana kadar yeni bir ürün kaydettiğimiz için hazırdan elimizde Id var ve bu olan Id ile içerisinde bulunan categoriesleri ara tablomuza ekleyebiliriz HER BİR KATEGORİ ID Sİ İÇİN
           product.ProductCategories = productCreateDTO.CategoryIds.Select(cId => new ProductCategory { // tektek tüm dışardan gelen createId leri seç ve benim dtomun içindeki Idlere tek tek işle
            ProductId = product.Id, // junction tabledeki product Id kolonuna dışardan gelen ID mizi yazıyoruz
            CategoryId = cId // kategori Id ye ise dışardan gelen bizim seçtiğimiz kategori Id lerini atıyoruz en sonda bunu listeliyoruz
            
           }).ToList();  // buradaki c Id dışardaki gelen Id mizden söz ediyoruz ve yeni bir ürün ekliceğimizden içerisine select metoduyla her yeni gelen kategori bilgisi için ara tabloya ürünle beraber kategori Id si eklicem en sonda to list diyerek listelicem

            _repsitory.Update(product); // frameworkümüz productı oluşturduğumuzda onu kaydetsek bile izlemeye başar bu yüzden bu bilgiler direkt producta gideceğinden dolayı update metodunun içine product yazmamla hiçbir sorun yoktur   update yapma sebebimiz ara tablomuzda zaten productlarımız oluştu karşısındaki kategoriId lerini güncelliyoruz yani null olan şeyleri nulldan çıkarıyoruz
            result = await _unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                return ResponseDTO<ProductDTO>.Fail("Sunucuda Bir Hata Meydana Geldi", 500);
            }
            var productDTO = _mapper.Map<ProductDTO>(product); // ilk olarak entity olarak çalıştırdığım şeyi  şimdi kullanıcıya dönmem lazım yani kayıt oluşunca dicem ki al kardeş kaydettiğin bilgi budur o yüzden entity lerimize ulaşmak yerine onun göreceği şekilde ayarlamk için dtolarımız var onlara dönüştürerek güvenliği arttırmış oluruz
            return ResponseDTO<ProductDTO>.Success( productDTO,200);



        }

        public async Task<ResponseDTO<NoContent>> DeleteAsync(int id)
        {
            var product = await _repsitory.GetByIdAsync(id);
            if(product == null)
            {
                return ResponseDTO<NoContent>.Fail("Böyle Bir Ürün Bulunmamaktadır",404);
            }
            _repsitory.Delete(product);
            var result = await _unitOfWork.SaveChangesAsync();
            if(result <= 0)
            {
                return ResponseDTO<NoContent>.Fail("Silme İşlemi Tamamlanamadı", 500);
            }
            return ResponseDTO<NoContent>.Success(200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var product = await _repsitory.GetAllAsync();
            if(product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Sunucu Hatası",500);
            }
            if (!product.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Bulunamadı", 404);
            }
            // gelen entityleri dışarıya gösterebilmek için dtoya çevirmeliyiz
            var dto = _mapper.Map<IEnumerable<ProductDTO>>(product); // çok ürün olacağından listenerek gelcek
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(dto,200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive)
        {
           var product = await _repsitory.GetAllAsync(x => x.IsActive == isActive);
            if (product == null)
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Sunucu Hatası", 500);
            }
            if (!product.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail("Ürünler Bulunamadı", 404);
            }
            var dto = _mapper.Map<IEnumerable<ProductDTO>>(product); 
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(dto, 200);
        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync()
        {
            var products = await _repsitory.GetAllAsync(p => p.ProductCategories.Select(pc => pc.Category).ToList());




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

        public Task<ResponseDTO<NoContent>> UpdateAsync(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
