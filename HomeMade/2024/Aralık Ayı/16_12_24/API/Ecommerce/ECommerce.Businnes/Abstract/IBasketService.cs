using ECommerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    //Data Transfer Object - DTO   Amaç servisten bir veriyi dto larla dataya yollamak 

    public interface IBasketService
    {
        //DTO Tanımlamaya gidiyoruz

        Task<BasketDTO> GetBasketAsync(int id);
        Task<IEnumerable<BasketDTO>> GetBasketAsync();

    }
}
