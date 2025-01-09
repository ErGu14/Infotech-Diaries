﻿using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
	public class AuthService : BaseService, IAuthService
	{
        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory,httpContextAccessor)
        {
            
        }
        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel)
		{
			var client = GetHttpClient();
			var response = await client.PostAsJsonAsync("/auth/login",loginModel);
			var responseBody = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<ResponseModel<TokenModel>>(responseBody,_jsonSerializerOptions);
			return result;
		}

		public async Task<ResponseModel<string>> RegisterAsync(RegisterModel registerModel)
		{
			var client =  GetHttpClient(); // bir client getirdik
			var response = await client.PostAsJsonAsync("/auth/register",registerModel); //clientteki ana istekten bir post işlemi yap

			var responseBody =await response.Content.ReadAsStringAsync(); //body kısmını oku
			var result = JsonSerializer.Deserialize<ResponseModel<string>>(responseBody,_jsonSerializerOptions);
			return result;
		}
	}
}