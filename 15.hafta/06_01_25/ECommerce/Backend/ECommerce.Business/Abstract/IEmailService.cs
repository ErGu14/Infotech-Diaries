using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}