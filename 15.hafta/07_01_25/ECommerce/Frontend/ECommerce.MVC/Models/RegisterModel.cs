using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
    public class RegisterModel
    {
        [JsonPropertyName("firstName")]
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string LastName { get; set; }

        [JsonPropertyName("address")]
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        public string Address { get; set; }


        [JsonPropertyName("city")]
        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Şehir alanı zorunludur.")]
        public string City { get; set; }
        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı zorunludur.")]
        [JsonPropertyName("gender")]
        public int Gender { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı zorunludur.")]
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [JsonPropertyName("email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }

        [JsonPropertyName("confirmPassword")]
        [Display(Name = "Şifre Onay")]
        [Required(ErrorMessage = "Şifre Onay alanı zorunludur.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
