using PartyApp.Data.Concrete.Repositories;
using PartyApp.Entity.Concrete;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Concrete
{
    public class InvitationService
    {
        private readonly InvitationRepository _invitationRepository;

        public InvitationService(InvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        public List<InvitationViewModel> GetAll()
        {
            var invitations = _invitationRepository.GetAll();
            //Burada gelen datayı, view model listesine dönüştüreceğiz. İlerde bu iş için ayrı bir kütüphane kullanarak kolaylaştıracağız. Ama şimdilik anlayabilme amacıyla uzun yolu tercih ediyoruz.
            List<InvitationViewModel> invitationViewModels = invitations
                .Select(x => new InvitationViewModel
                {
                    Id = x.Id,
                    EventName = x.EventName,
                    EventDate = x.EventDate
                }).ToList();
            return invitationViewModels;
        }

        public InvitationViewModel GetById(int id) { 
            var invitation = _invitationRepository.GetById(id);
            InvitationViewModel result = new();
            result.Id = invitation.Id;
            result.EventName = invitation.EventName;
            result.EventDate = invitation.EventDate;
            return result;
        }

        public void Create(InvitationViewModel invitationViewModel)
        {
            Invitation invitation = new()
            {
                Id = invitationViewModel.Id,
                EventName = invitationViewModel.EventName,
                EventDate = invitationViewModel.EventDate
            };
            _invitationRepository.Create(invitation);
        }

        public void Update(InvitationViewModel invitationViewModel)
        {
            var invitation = _invitationRepository.GetById(invitationViewModel.Id);
            invitation.EventName= invitationViewModel.EventName;
            invitation.EventDate = invitationViewModel.EventDate;
            _invitationRepository.Update(invitation);
        }

        public void Delete(int id)
        {
            var invitation = _invitationRepository.GetById(id);
            _invitationRepository.Delete(invitation);
        }
    }
}




// Yukarıda LINQ sorguları ile yazdığımız kodun normal döngü ile yazılmış hali

//List<InvitationViewModel> result2 = [];
//foreach (var invitation in invitations)
//{
//    result2.Add(new InvitationViewModel
//    {
//        Id = invitation.Id,
//        EventName = invitation.EventName,
//        EventDate = invitation.EventDate
//    });
//}