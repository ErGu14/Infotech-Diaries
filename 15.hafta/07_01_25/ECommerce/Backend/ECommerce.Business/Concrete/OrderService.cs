using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IBasketService _basketService;

        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> orderRepository, IMapper mapper, IBasketService basketService)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
            _basketService = basketService;
        }

        public async Task<ResponseDTO<OrderDTO>> CreateOrderAsync(OrderCreateDTO orderCreateDTO)
        {
            foreach (var item in orderCreateDTO.OrderItems)
            {
                var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    return ResponseDTO<OrderDTO>.Fail($"{item.ProductId} id'li ürün veri tabanında bulunamadı!", StatusCodes.Status404NotFound);
                }
            }
            var order = _mapper.Map<Order>(orderCreateDTO);
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            foreach (var item in order.OrderItems)
            {
                item.OrderId = order.Id;
            }
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();
            await _basketService.ClearBasketAsync(order.ApplicationUserId);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO, StatusCodes.Status201Created);
        }

        public async Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail("İlgili sipariş kaydı bulunamadı", StatusCodes.Status404NotFound);
            }
            _orderRepository.Delete(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (order == null)
            {
                return ResponseDTO<OrderDTO>.Fail("İlgili sipariş kaydı bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Hiç sipariş bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(OrderStatus orderStatus)
        {
            var orders = await _orderRepository.GetAllAsync(x => x.OrderStatus == orderStatus, null, null, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Belirtilen duruma ait hiç sipariş bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(string applicationUserId)
        {
            var orders = await _orderRepository.GetAllAsync(x => x.ApplicationUserId == applicationUserId, x => x.OrderByDescending(y => y.CreatedDate), null, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Belirtilen duruma ait hiç sipariş bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetAllAsync(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate, null, null, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Belirtilen duruma ait hiç sipariş bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<string>> GetOrderStatusAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return ResponseDTO<string>.Fail("Sipariş bulunamadı!", StatusCodes.Status404NotFound);
            }
            var status = order.OrderStatus.ToString();
            return ResponseDTO<string>.Success(status, StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == orderUpdateDTO.Id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail("Sipariş bulunamadı!", StatusCodes.Status404NotFound);
            }
            order.OrderItems.Clear();
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();

            order.OrderItems = orderUpdateDTO.OrderItems.Select(oi => new OrderItem
            {
                Id = oi.Id,
                ModifiedDate = DateTime.Now,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToList();
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail("Sipariş bulunamadı!", StatusCodes.Status404NotFound);
            }
            order.OrderStatus = orderStatus;
            _orderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
