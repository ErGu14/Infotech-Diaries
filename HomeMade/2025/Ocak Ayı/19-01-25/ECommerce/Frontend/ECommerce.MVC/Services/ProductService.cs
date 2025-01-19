using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public Task<ProductModel> AddAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetAllActiveAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("products/true");
                var jsonString = await response.Content.ReadAsStringAsync();
                ResponseModel<IEnumerable<ProductModel>> result;
                try
                {
                    result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<ProductModel>>>(jsonString, _jsonSerializerOptions);
                }
                catch (Exception)
                {
                    Console.WriteLine("Bir hata var");
                    return new List<ProductModel>();
                }
                if(result != null && result.Errors==null || result.Errors.Count==0)
                {
                    return result.Data;
                }
                else
                {
                    Console.WriteLine("Bir hata var");
                    return new List<ProductModel>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductModel>();
            }
            

        }

        public Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetAllByCategoryAsync(int categoryId)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"products/bycategory/{categoryId}");
                var jsonString = await response.Content.ReadAsStringAsync();
                ResponseModel<IEnumerable<ProductModel>> result;
                try
                {
                    result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<ProductModel>>>(jsonString, _jsonSerializerOptions);
                }
                catch (Exception)
                {
                    Console.WriteLine("Bir hata var");
                    return new List<ProductModel>();
                }
                if (result != null && result.Errors == null || result.Errors.Count == 0)
                {
                    return result.Data;
                }
                else
                {
                    Console.WriteLine("Bir hata var");
                    return new List<ProductModel>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductModel>();
            }
        }

        public Task<IEnumerable<ProductModel>> GetAllPassiveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetAsync(int id)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"products/get/{id}");
                var jsonString = await response.Content.ReadAsStringAsync();
                ResponseModel<ProductModel> result;
                try
                {
                    result = JsonSerializer.Deserialize<ResponseModel<ProductModel>>(jsonString, _jsonSerializerOptions);
                }
                catch (Exception)
                {
                    Console.WriteLine("Bir hata var");
                    return new ProductModel();
                }
                if (result != null && result.Errors == null || result.Errors.Count == 0)
                {
                    return result.Data;
                }
                else
                {
                    Console.WriteLine("Bir hata var");
                    return new ProductModel();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new ProductModel();
            }
        }

        public Task UpdateAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
