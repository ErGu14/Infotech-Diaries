using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Basket> _basketrepos;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IGenericRepository<Basket> basketrepos, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _basketrepos = basketrepos;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO)
        {
            var basket = await _basketrepos.GetAsync(x => x.Id == basketItemCreateDTO.BasketId,query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));//sepetin içindeki itemleri kontrol etmemiz lazım  eğer varsa düzenlicem yoksa eklicem 
            if (basket == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Sepet Bulunamadı",404);
            }
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(basketItemCreateDTO.ProductId); // sepetteki ürünleri çekiyorum (ürünlerin varlığını kontrol edicem)
            if (product == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Ürün Bulunamadı", 404);
            }
            var existingBasketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (existingBasketItem != null)
            {
                existingBasketItem.Quantity = basketItemCreateDTO.Quantity;
                _basketrepos.Update(basket);
                await _unitOfWork.SaveChangesAsync();
                var updatedBasketItemDto = _mapper.Map<BasketItemDTO>(existingBasketItem);
                return ResponseDTO<BasketItemDTO>.Success(updatedBasketItemDto, 200);
            }
            var basketItem = _mapper.Map<BasketItem>(basketItemCreateDTO);
            basket.BasketItems.Add(basketItem);
            _basketrepos.Update(basket);
            await _unitOfWork.SaveChangesAsync();
            var basketItemDTO = _mapper.Map<BasketItemDTO>(basket);
            return ResponseDTO<BasketItemDTO>.Success(basketItemDTO,201);
        }

        public async Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemChangeQuantityDTO.BasketItemId); //ilgili sepetteki ürünü bul
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün Sepette Bulunamadı", 404);
            }
            basketItem.Quantity = basketItemChangeQuantityDTO.Quantity;
            _unitOfWork.GetRepository<BasketItem>().Update(basketItem);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(204);
        }

        public async Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId)
        {
            // ürün sipariş edildikten sonra ve kullanıcı ürünleri iptal etmesi durumunda sepetteki ürünleri silme

            var basket = await _basketrepos.GetAsync(x => x.ApplicationUserId == applicationUserId,query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product)); // id si 3 olan kullanıcının sepetteki eşyaları ve sepetteki eşyaların ürün bilgisi
            if(basket == null)
            {
                return ResponseDTO<NoContent>.Fail("Sepet Bulunamadı", 404);
                
            }
            basket.BasketItems.Clear();
            _basketrepos.Update(basket);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(404);
        }

        public async Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO)
        {
            var basket = _mapper.Map<Basket>(basketCreateDTO);
            await _basketrepos.AddAsync(basket);
            await _unitOfWork.SaveChangesAsync();

            var basketDTO = _mapper.Map<BasketDTO>(basket);
            return ResponseDTO<BasketDTO>.Success(basketDTO,201);
        }

        public async Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId) // sepete tıklayınca sepet ve sepet ürünlerini getircez
        {
            var basket = await _basketrepos.GetAsync(x => x.ApplicationUserId == applicationUserId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product)); ;
            if (basket == null)
            {
                return ResponseDTO<BasketDTO>.Fail("Sepet Bulunamadı", 404);
            }
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            return ResponseDTO<BasketDTO>.Success(basketDTO,200);

        }

        public async Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketsAsync()
        {
            var baskets = await _basketrepos.GetAllAsync();
            if (baskets == null || !baskets.Any())
            {
                return ResponseDTO<IEnumerable<BasketDTO>>.Fail("Veri Tabanında Sepet Bulunamadı", 404);
            }
            var basketsDTO = _mapper.Map<IEnumerable<BasketDTO>>(baskets);
            return ResponseDTO<IEnumerable<BasketDTO>>.Success(basketsDTO,200);
        }

        public async Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId)
        {
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemId);
           
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("İlgili Ürün Sepette Bulunamadı", 404);
            }
            _unitOfWork.GetRepository<BasketItem>().Delete(basketItem);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(200);
        }
    }
}
