
namespace WebApplication1.Models.Entity
{
    public class Profile : BaseEntity, IDatesEntity
    {
        
        public string? ProfileName { get; set; }
        public IFormFile? ProfileImg { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
