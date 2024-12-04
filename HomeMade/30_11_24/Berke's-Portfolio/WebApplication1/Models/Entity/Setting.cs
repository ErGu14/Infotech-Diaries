
namespace WebApplication1.Models.Entity
{
    public class Setting : BaseEntity, IDatesEntity
    {
        
        public IFormFile? Background { get; set; }
        public string? SiteName { get; set; }
        public IFormFile? PageIcon { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
