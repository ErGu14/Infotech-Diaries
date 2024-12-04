using System.ComponentModel.DataAnnotations;

namespace Project08_EFCore_CodeFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunludur!")]
        [MinLength(5, ErrorMessage = "En Az 5 karakter Olmak Zorunludur!")]
        [MaxLength(10, ErrorMessage = "En fazla 10 karakter Olmak Zorunludur!")]
        public required string FirstName { get; set; } 
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçersiz Email")]
        public required string Email { get; set; }
        [Range(18,150,ErrorMessage ="Yasal Yaş Sınırının Dışındasınız!")]
        [Required(ErrorMessage ="Bu Alan Zorunludur")]
        public byte Age { get; set; }
        [Required(ErrorMessage ="Bu Alan Zorunldur!")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Bu Alan Zorunldur!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public required string RePassword { get; set; }

        public DateTime ApplyDate { get; set; }


    }
}
