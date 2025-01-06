using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IProductService
    {
        // buradaki amacımız ürünlerimizle alakalı operasyonlarımızın kemik yapısını ayarlamak

        Task<ResponseDTO<ProductDTO>> GetAsync(int id); 
        Task<ResponseDTO<ProductDTO>> GetWithCategoriesAsync(int id); // id ile hangi kategorilere ait ve hangi ürün onu çağırıyorum
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync();
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllAsync(bool? isActive); // null da dönebilir ve bu sayede eğer null gelirse hepsini getir diyerek hatayı ele almış oluyorum
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllWithCategoriesAsync(); // senaryoya göre tekrar aktif mi pasif mi kontrolü yapmadan sadece örnek olsun diye aktif olanları getiricez
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetByCategoryAsync(int categoryId); // aktif olan şu kategorideki *ürünleri* getir

        Task<ResponseDTO<ProductDTO>> AddAsync(ProductCreateDTO productCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateAsync(ProductUpdateDTO productUpdateDTO);
        Task<ResponseDTO<NoContent>> DeleteAsync(int id);

        Task<ResponseDTO<int>> GetCountAsync();
        Task<ResponseDTO<int>> GetCountAsync(bool? isActive);
        Task<ResponseDTO<int>> GetCountByCategoryAsync(int categoryId); // kategorisi şu şu olan ürünleri say demek için    içine kategori Id yazmayı unutma unutursan sonra sorun yaşayabilirsin
        Task<ResponseDTO<bool>> UpdateIsActiveAsync(int id);



    }
}
