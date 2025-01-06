
namespace WebApplication1.Models.Entity
{
    public class SocialMedia : BaseEntity, IDatesEntity
    {
        public string? SocialMediaIcon { get; set; }
        public string? SocialMediaDesc { get; set; }
        public string? SocialMediaUrl { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
