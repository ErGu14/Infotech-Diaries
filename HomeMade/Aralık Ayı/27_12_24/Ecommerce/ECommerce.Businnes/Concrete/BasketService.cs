using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos;
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
    public class BasketService : IBasketService
    {
        // gerekli DI işlemlerini halledelim

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Basket> _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IGenericRepository<Basket> genericRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<BasketItemDTO>> AddProductFromBasketAsync(BasketItemCreateDTO basketItemCreateDTO)
        {
            // ilgili sepete ürün ekleme

            // ilk önce ilgili sepetimiz getiriyoruz
            var basket = await _basketRepository.GetAsync(x => x.Id == basketItemCreateDTO.BasketId,query => query.Include(x => x.BasketItems).ThenInclude(x => x.Product));
            //eğer ilgili sepet yoksa hata döndürücez
            if (basket == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Sepet Bulunamadı",404);
            }
            // sepeti getirdim şimdi ise ilgili ürünü getiricem
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(basketItemCreateDTO.ProductId);
            //eğer sistemde ürün yoksa hata döndür diyorum
            if (product == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Ürün Bulunamadı", 404);
            }
            // eğer sepetimde ilgili ürün eşleşiyorsa getir dedim amacım burda geçerli ürün var ise quantitysine o kadar ekleme yapıcak eğer yoksa 1 tane ürün satırı eklicek
            var existBasketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == product.Id);
            // eğer ürünüm sepette MEVCUT ise;
            if(existBasketItem != null) {
                existBasketItem.Quantity = basketItemCreateDTO.Quantity; // QUANTİTY bilgisine dışardan gelen ürünün quantitysini ekle
                _basketRepository.Update(basket);
                await _unitOfWork.SaveChangesAsync();
                var basketItemDTO = _mapper.Map<BasketItemDTO>(basket);
                return ResponseDTO<BasketItemDTO>.Success(basketItemDTO, 200);


            }

            // eğer elimde Seçili Id li ürün yok ise;

            var basketItem = _mapper.Map<BasketItem>(basketItemCreateDTO); // DTOyu Entitye Çevir
            basket.BasketItems.Add(basketItem); // yukardan aldığım entity bilgisini sepetteki sepet ürünlerine ekle diyorum
            _basketRepository.Update(basket); // sepet durumunu güncelle diyorum
            await _unitOfWork.SaveChangesAsync(); // kaydet
            var basketItemDTOs = _mapper.Map<BasketItemDTO>(basket); // kaydedilen sepeti dto ya çeviriyorum   yani entity to DTO converter
            return ResponseDTO<BasketItemDTO>.Success(basketItemDTOs, 200); // data ve sonucu döndürüyorum





        }

        public async Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
            // sepetteki ürünün adet miktarını değiştirme

            // ilgili SEPETTEKİ ÜRÜNÜ bul
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemChangeQuantityDTO.BasketItemId);

            // eğer sepette ilgili ürün bulunamazsa
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün Sepette Bulunamadı", 404);
            }
            basketItem.Quantity = basketItemChangeQuantityDTO.Quantity;
            _unitOfWork.GetRepository<BasketItem>().Update(basketItem); // basket itemleri repomu getir ve içerisine bu bilgiyi at
            await _unitOfWork.SaveChangesAsync(); // kaydet
            return ResponseDTO<NoContent>.Success(200); // başarılı döndür
        }

        public async Task<ResponseDTO<NoContent>> ClearBasketAsync(string appUserId)
        {
            // sepetteki ürünleri silme   (sipraiş durumunda veya kullanıcı ürünleri sepetten silmek istediğinde)

            //ilgili kullanıcının sepet bilgilerini alma
            var basket = await _basketRepository.GetAsync(x => x.ApplicationUserId == appUserId,query => query.Include(x => x.BasketItems).ThenInclude(x=> x.Product));
            if (basket == null)
            {
                return ResponseDTO<NoContent>.Fail("Sepet Bulunamadı", 404);

            }
            basket.BasketItems.Clear(); // eğer hata alınmaz ve gerekli sepet getirilirse sepetteki ürünleri temizle
            _basketRepository.Update(basket); // sepeti sildim evet şimdi son durumunu güncelle diyorum
            await _unitOfWork.SaveChangesAsync(); // işlemleri kaydet diyorum
            return ResponseDTO<NoContent>.Success(200); // olumlu sonuç döndürüyorum

        }

        public async Task<ResponseDTO<BasketDTO>> CreateBasketDTO(BasketCreateDTO basketCreateDTO)
        {
            // kullanıcı giriş yaptıktan veya kayıt olduktan sonra ona sepet oluşturucam

            var basket = _mapper.Map<Basket>(basketCreateDTO); // ilgili dtomu entity e çevir
            await _basketRepository.AddAsync(basket); // databaseme ekle
            await _unitOfWork.SaveChangesAsync(); // işlemleri kaydet

            var basketDTO = _mapper.Map<BasketDTO>(basket); // entity to dto
            return ResponseDTO<BasketDTO>.Success(basketDTO, 201); // olumlu sonucu döndür

        }

        public async Task<ResponseDTO<BasketDTO>> GetBasketAsync(string appUserId)
        {
            // ilgili kullanıcının sepet bilgisini getir

            var basket = await _basketRepository.GetAsync(x => x.ApplicationUserId == appUserId,query => query.Include(x=>x.BasketItems).ThenInclude(x => x.Product));

            // sepet gelmez ise hata kontrolü
            if (basket == null)
            {
                return ResponseDTO<BasketDTO>.Fail("Sepet Bulunamadı", 404);
            }
            // entity to dto
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            //return answer
            return ResponseDTO<BasketDTO>.Success(basketDTO, 200);
        }

        public async Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketAsync()
        {
            // tüm sepetleri getiriyorum
            var baskets = await _basketRepository.GetAllAsync();

            //hata kontrolü (null gelirse veya boş dizi gelirse)
            if (baskets == null || !baskets.Any())
            {
                return ResponseDTO<IEnumerable<BasketDTO>>.Fail("Veri Tabanında Sepet Bulunamadı", 404);
            }
            // entity to DTO
            var basketsDTO = _mapper.Map<IEnumerable<BasketDTO>>(baskets);
            // return answer
            return ResponseDTO<IEnumerable<BasketDTO>>.Success(basketsDTO, 200);

        }

        public async Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId)
        {
            // silceğim ürünün id sini getiriyorum
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemId);

            // eğer yoksa böyle bir id  hata döndür
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("İlgili Ürün Sepette Bulunamadı", 404);
            }

            // gerekli id varsa ilgili basketItemi sil
            _unitOfWork.GetRepository<BasketItem>().Delete(basketItem);

            //kaydet
            await _unitOfWork.SaveChangesAsync();

            // sonuç döndür
            return ResponseDTO<NoContent>.Success(200);
        }
    }
}
