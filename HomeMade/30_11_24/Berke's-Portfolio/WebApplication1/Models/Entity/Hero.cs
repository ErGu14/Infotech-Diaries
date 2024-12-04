
namespace WebApplication1.Models.Entity
{
    public class Hero:BaseEntity, IDatesEntity
    {
        public string? HeroHeader { get; set; }
        public string? HeroDescs { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
    }
}
