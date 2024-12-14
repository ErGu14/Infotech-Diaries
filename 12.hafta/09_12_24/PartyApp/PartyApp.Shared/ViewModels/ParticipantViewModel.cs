using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Shared.ViewModels
{
    public class ParticipantViewModel
    {
        public int Id { get; set; }
        [DisplayName("Ad Soyad")]
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        public string FullName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        public string Email { get; set; }

        [Display(Name ="Telefon Numarası")]
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Yaş")]
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        public byte? Age { get; set; }

        [Display(Name ="Kaç Kişi Katılacaksınız?")]
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        public byte NumberOfPeople { get; set; }
        public List<InvitationViewModel>? Invitations { get; set; }
    }
}
