namespace WebApplication1.Models
{
    public class UserLang
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
