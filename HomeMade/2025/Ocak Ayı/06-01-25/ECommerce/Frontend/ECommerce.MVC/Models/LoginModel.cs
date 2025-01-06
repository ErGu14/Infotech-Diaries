using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
	public class LoginModel
	{
		[JsonPropertyName("email")]
		[Display(Name = "Email")]
		[Required(ErrorMessage = "Bu Alan Boş Bırakılamaz!")]
		[EmailAddress(ErrorMessage ="Geçersiz Email Adresi")]
		public string Email { get; set; }

		[JsonPropertyName("password")]
		[Display(Name = "Password")]
		[Required(ErrorMessage = "Bu Alan Boş Bırakılamaz!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
