using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
	public class RegisterModel
	{
		[JsonPropertyName("firstName")]
		[Display(Name ="Ad")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public string FirstName { get; set; }

		[JsonPropertyName("lastName")]
		[Display(Name = "Soyad")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public string LastName { get; set; }

		[JsonPropertyName("address")]
		[Display(Name = "Adres")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public string Address { get; set; }

		[JsonPropertyName("city")]
		[Display(Name = "Şehir")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public string City { get; set; }

		[JsonPropertyName("gender")]
		[Display(Name = "Cinsiyet")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public int Gender { get; set; }

		[JsonPropertyName("dateOfBirth")]
		[Display(Name = "Doğum Tarihi")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public DateTime DateOfBirth { get; set; } = DateTime.Now;

		[JsonPropertyName("email")]
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		[EmailAddress(ErrorMessage = "Geçersiz Email Adresi")]
		public string Email { get; set; }

		[JsonPropertyName("password")]
		[Display(Name = "Şifre")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		public string Password { get; set; }

		[JsonPropertyName("confirmPassword")]
		[Display(Name = "Şifre Tekrar")]
		[Required(ErrorMessage = "Bu Alan Zorunludur")]
		[Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor")]
		public string ConfirmPassword { get; set; }
	}
}
