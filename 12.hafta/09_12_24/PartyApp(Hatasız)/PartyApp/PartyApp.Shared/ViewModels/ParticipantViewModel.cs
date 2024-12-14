using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Shared.ViewModels
{
    public class ParticipantViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad Soyad boş bırakılamaz")]
        public string? FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email boş bırakılamaz")]
        public string? Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon boş bırakılamaz")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Yaş")]
        [Required(ErrorMessage = "Yaş boş bırakılamaz")]
        public byte? Age { get; set; }

        [Display(Name = "Kaç Kişi Katılacaksınız?")]
        [Required(ErrorMessage = "Kişi Sayısı boş bırakılamaz")]
        public byte? NumberOfPeople { get; set; }
        public List<InvitationViewModel>? Invitations { get; set; }
    }
}
