﻿using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using Microsoft.Extensions.Http;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public Task<CategoryModel> AddCategoryAsync(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryModel>> GetActiveCategoriesAsync()
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync("categories/getall/true");
                //response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                ResponseModel<IEnumerable<CategoryModel>> result;
                try
                {
                    result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<CategoryModel>>>(jsonString, _jsonSerializerOptions);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Json Deserialize Error : {ex.Message}");
                    return new List<CategoryModel>(); //Ienum... yapmama sebebim soyut bir şeyden yeni nesne oluşturamam 
                }
                if (result != null && result.Errors == null || result?.Errors?.Count == 0)
                {
                    return result.Data;
                }
                else
                {
                    Console.WriteLine($"Request Error: {string.Join(",",result.Errors)}");
                    return new List<CategoryModel>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http Request ex: {ex.Message}");
                return new List<CategoryModel>();
            }

        }

        public Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetCategoryAsynx(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCategoryCountAsynx()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryModel>> GetPassiveCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }
    }
}