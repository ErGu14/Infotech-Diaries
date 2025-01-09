using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
