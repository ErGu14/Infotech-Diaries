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
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Basket> _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork unitOfWork, IGenericRepository<Basket> basketRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO)
        {
            var basket = await _basketRepository.GetAsync(x => x.Id == basketItemCreateDTO.BasketId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
            if (basket == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(basketItemCreateDTO.ProductId);
            if (product == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail("Ürün bulunamadı!", StatusCodes.Status404NotFound);
            }
            var existingBasketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == product.Id);
            if (existingBasketItem != null)
            {
                existingBasketItem.Quantity = basketItemCreateDTO.Quantity == 1 ? existingBasketItem.Quantity + 1 : basketItemCreateDTO.Quantity;
                _basketRepository.Update(basket);
                await _unitOfWork.SaveChangesAsync();
                var updatedBasketItemDTO = _mapper.Map<BasketItemDTO>(existingBasketItem);
                return ResponseDTO<BasketItemDTO>.Success(updatedBasketItemDTO, StatusCodes.Status200OK);
            }

            var basketItem = _mapper.Map<BasketItem>(basketItemCreateDTO);
            basket.BasketItems.Add(basketItem);
            _basketRepository.Update(basket);
            await _unitOfWork.SaveChangesAsync();
            var basketItemDTO = _mapper.Map<BasketItemDTO>(basketItem);
            return ResponseDTO<BasketItemDTO>.Success(basketItemDTO, StatusCodes.Status201Created);
        }

        public async Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemChangeQuantityDTO.BasketItemId);
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("Ürün sepette bulunamadı", StatusCodes.Status404NotFound);
            }
            basketItem.Quantity = basketItemChangeQuantityDTO.Quantity;
            _unitOfWork.GetRepository<BasketItem>().Update(basketItem);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId)
        {
            var basket = await _basketRepository.GetAsync(x => x.ApplicationUserId == applicationUserId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
            if (basket == null)
            {
                return ResponseDTO<NoContent>.Fail("Sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            basket.BasketItems.Clear();
            _basketRepository.Update(basket);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO)
        {
            var basket = _mapper.Map<Basket>(basketCreateDTO);
            await _basketRepository.AddAsync(basket);
            await _unitOfWork.SaveChangesAsync();

            var basketDTO = _mapper.Map<BasketDTO>(basket);
            return ResponseDTO<BasketDTO>.Success(basketDTO, StatusCodes.Status201Created);
        }

        public async Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId)
        {
            var basket = await _basketRepository.GetAsync(x => x.ApplicationUserId == applicationUserId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
            if (basket == null)
            {
                return ResponseDTO<BasketDTO>.Fail("Sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            return ResponseDTO<BasketDTO>.Success(basketDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketsAsync()
        {
            var baskets = await _basketRepository.GetAllAsync();
            if (baskets == null || !baskets.Any())
            {
                return ResponseDTO<IEnumerable<BasketDTO>>.Fail("Veri tabanında hiç sepet bulunamadı!", StatusCodes.Status404NotFound);
            }
            var basketDTOs = _mapper.Map<IEnumerable<BasketDTO>>(baskets);
            return ResponseDTO<IEnumerable<BasketDTO>>.Success(basketDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId)
        {
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemId);
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail("İlgili ürün, sepette bulunamadı!", StatusCodes.Status404NotFound);
            }
            _unitOfWork.GetRepository<BasketItem>().Delete(basketItem);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
