using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Helpers
{
    public class CustomControllerBase :ControllerBase // şimdi burda apide yazacağımız controllerlerimizi düzenlicez ne gibi  ben hata kodunu tek tek 200 ise şöyle yap 400 ise şöyle yap gibi gibi uzun uzun if if if yapmamak için tek yerden bunu kontrol edicem
    {
        public static IActionResult CreateResponse<T>(ResponseDTO<T> response) // statusCode bilgilerini bu şekilde kontrol edicez
        {
           return new ObjectResult(response) //dışardan gelen status kodu bunun içine at ve bunu döndür
            {
                StatusCode = response.StatusCode // dışardan gelen status bilgisini object resultun içine at ve döndür
            };
        }
    }
}
