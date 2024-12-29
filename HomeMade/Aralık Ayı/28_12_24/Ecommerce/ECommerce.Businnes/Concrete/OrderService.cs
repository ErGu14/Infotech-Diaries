using AutoMapper;
using ECommerce.Businnes.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper; 
        private readonly IGenericRepository<Order> _orderRepos;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketService _basketService; // sipariş oluştururken basketi sileceğim o yüzden kullanacağım

        public OrderService(IMapper mapper, IGenericRepository<Order> orderRepos, IUnitOfWork unitOfWork, IBasketService basketService)
        {
            _mapper = mapper;
            _orderRepos = orderRepos;
            _unitOfWork = unitOfWork;
            
            _basketService = basketService;
        }

        // Sipariş verildiği anda ilgili sepeti temizleyip sipariş oluşturma
        public async Task<ResponseDTO<OrderDTO>> CreateOrderAsync(OrderCreateDTO orderCreateDTO)
        {
            //sipariş oluşturma


            // Bu döngü, sipariş öğelerini (OrderItems) kontrol eder. Her bir ürünün veritabanında mevcut olup olmadığını kontrol eder.
            foreach (var item in orderCreateDTO.OrderItems)
            {
                var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(item.ProductId); // dışardan gelen ürün id leri ile entityde olan ürün id leri tek tek bul ve eşitle

                //burda ise eğer bir tane bile ürün gelmezse onun hatasını döndürcez
                if(product == null)
                {
                    return ResponseDTO<OrderDTO>.Fail($"{item.ProductId} Id'li ürün bulunamadı", 404); // itemden yani dışardan gelen createDTO dan
                }
               

            }

            // Yeni bir sipariş nesnesi oluşturur ve veritabanına ekler.  yani boş bir kolon açar öyle de denilebilir
            var order = _mapper.Map<Order>(orderCreateDTO); // DTO to Entity
            await _orderRepos.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Sipariş öğelerinin OrderId değerini günceller ve siparişi tekrar günceller.   yani itemlerin iligili id si ile ilgili siparişi id sini eşitliyorum
            foreach(var item in order.OrderItems)
            {
                item.OrderId = order.Id;
            }
            _orderRepos.Update(order);
            await _unitOfWork.SaveChangesAsync();
            await _basketService.ClearBasketAsync(order.ApplicationUserId); // sipariş oluşunca ilgili kullanıcının sepetini sil
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO,200);
        }

        //sipariş silme
        public async Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id)
        {
            var order = await _orderRepos.GetByIdAsync(id);
            if(order == null)
            {
                return ResponseDTO<NoContent>.Fail("ilgili sipariş bulunamadı",404);

            }
            _orderRepos.Delete(order);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(200);
        }

        //siparişlerin alayını getirme
        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync()
        {
            var orders = await _orderRepos.GetAllAsync();
            if(orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Sipariş Bulunamadı",404);

            }
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(ordersDTO,200);
        }

        // sipariş durumuna göre hepsini getirme
        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(OrderStatus orderStatus)
        {
            var orders = await _orderRepos.GetAllAsync(x => x.OrderStatus == orderStatus,null, query => query.Include(x => x.OrderItems).ThenInclude(x => x.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Sipariş Bulunamadı", 404);

            }
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(ordersDTO, 200);
        }

        // ilgili kullanıcıya göre hepsini getirme
        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(string AppUserId)
        {
            var orders = await _orderRepos.GetAllAsync(x => x.ApplicationUserId  == AppUserId, null, query => query.Include(x => x.OrderItems).ThenInclude(x => x.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Sipariş Bulunamadı", 404);

            }
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(ordersDTO, 200);
        }

        // sipariş tarihlerine göre hepsini getirme
        public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(DateTime startTime, DateTime endTime)
        {
            //Siparişlerin oluşturulma tarihinin (CreatedDate) belirli bir zaman aralığında (startTime ile endTime arasında) olup olmadığını kontrol eder.
            var orders = await _orderRepos.GetAllAsync(x => x.CreatedDate >= startTime && x.CreatedDate <= endTime , null, query => query.Include(x => x.OrderItems).ThenInclude(x => x.Product));
            if (orders == null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Sipariş Bulunamadı", 404);

            }
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(ordersDTO, 200);
        }

        // ilgili Id ye sahip sipariş getirme
        public async Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id)
        {
            var order = await _orderRepos.GetAsync(x => x.Id == id,query => query.Include(x => x.OrderItems).ThenInclude(x=> x.Product));
            if (order == null)
            {
                return ResponseDTO<OrderDTO>.Fail("Sipariş Bulunamadı", 404);

            }
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO, 200);
        }

        // ilgili siparişin, sipariş durumunu getirme
        public async Task<ResponseDTO<string>> GetOrderStatusAsync(int id)
        {
            var order = await _orderRepos.GetByIdAsync(id);
            if (order == null)
            {
                return ResponseDTO<string>.Fail("Sipariş Bulunamadı", 404);
            }
            var status = order.OrderStatus.ToString();
            return ResponseDTO<string>.Success(status, 200);
        }

        // siparişi güncelleme
        public async Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await _orderRepos.GetAsync(x => x.Id == orderUpdateDTO.Id, query => query.Include(o => o.OrderItems).ThenInclude(oi => oi.Product));
            if (order == null)
            {
                return ResponseDTO<NoContent>.Fail("Sipariş Bulunmamaktadır", 404);

            }
            order.OrderItems.Clear(); // temizleme emri
            _orderRepos.Update(order); // silinmiş halini yazdırma
            await _unitOfWork.SaveChangesAsync(); // kaydetme

            // siparişteki tüm ürünleri için   dışardan gelen sipariş ürünlerini seçip (ilgili kolonlarını yani) yeni sipariş ürünleri oluştur veya içine at her neyse ve listele yani execute et  
            order.OrderItems = orderUpdateDTO.OrderItems.Select(x => new OrderItem {
                Id = x.Id, //Mevcut OrderItem'ın Id değeri.

                ModifiedDate = DateTime.Now, //Güncelleme işlemi sırasında ModifiedDate alanı şu anki tarihe ayarlanır.

                Quantity = x.Quantity,//OrderItem'ın miktar (quantity) değeri, orderUpdateDTO.OrderItems listesindeki ilgili değerden alınır.

                UnitPrice = x.UnitPrice //OrderItem'ın birim fiyat (unit price) değeri, orderUpdateDTO.OrderItems listesindeki ilgili değerden alınır.
            }).ToList();

            _orderRepos.Update(order); // ilgili kolonları güncelle
            await _unitOfWork.SaveChangesAsync(); // kaydet
            return ResponseDTO<NoContent>.Success(200); // döndür
            

        }

        //siparişin, sipariş durumunu güncelleme
        public async Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatusı)
        {
            // buradaki amacımız ilgili siparişin, sipariş durumunu güncellemek/değiştirmek

            var order = await _orderRepos.GetByIdAsync(orderId);
            if (order == null) {
                return ResponseDTO<NoContent>.Fail("İlgili Sipariş Bulunamadı", 404);
            }
            order.OrderStatus = orderStatusı;
            _orderRepos.Update(order); // peki order yukarda ben nasıl güncelleme yapıyorum ?  çünkü entity framework ben eğer bir değeri yazarsam ve var içine atarsam değişiklikleri izlemeye başlıyor
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(200);

        }
    }
}
