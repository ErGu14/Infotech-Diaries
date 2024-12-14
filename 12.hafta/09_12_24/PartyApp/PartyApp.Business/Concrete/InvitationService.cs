using PartyApp.Data.Concrete.Repositories;
using PartyApp.Entity.Concrete;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Concrete
{// burası invititaions ile alakalı getir yarat düzenle gibi işlerirmizi yapıyoruz  dışarıya görünecek kısımları burda toparlııyoruz 
    
    
    public class InvitationService
    {
        private readonly InvitationRepository _invitationRepository;

        public InvitationService(InvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        public List<InvitationViewModel> GetAll()
        {//burdaki datayı viewmodel listesine dönüştüreceğiz ilerde bu iş için ayrı bir kütüphane kullanarak kolaylaştıracağız ama şimdilik anlayabilmek için uzunca yazıyoruz
            var invitations = _invitationRepository.GetAll();
            List<InvitationViewModel> result = invitations.Select(x => new InvitationViewModel
            {
                Id = x.Id,
                EventName = x.EventName,
                EventDate = x.EventDate
            }).ToList();
            return result;  //datadai invitationsları getir ve kullanıcıya görüncek tarafları entegre ediyoruz yani datalarımız görünceğine sadece UI kısmının görüceği şekilde ayar ve kontrol yapıyoruz
            
        } 
        public InvitationViewModel GetById(int id)
        {
            var invitations = _invitationRepository.GetById(id);  // new demek gibi repositorydeki metodu çağırııyoruz
            InvitationViewModel result = new();
            result.Id = invitations.Id;
            result.EventName = invitations.EventName;
            result.EventDate = invitations.EventDate;
            return result;
        }
        public void Create(InvitationViewModel model)
        {
            Invitation invitation = new()
            {
                Id = model.Id,
                EventName = model.EventName,
                EventDate = model.EventDate,
            };
            _invitationRepository.Create(invitation);

        }
        public void Update(InvitationViewModel model)
        {
            var invitation = _invitationRepository.GetById(model.Id);
            invitation.EventName = model.EventName;
            invitation.EventDate = model.EventDate;
            _invitationRepository.Update(invitation);

        }
        public void Delete(int id)
        {
            var invitation = _invitationRepository.GetById(id);
            _invitationRepository.Delete(invitation);
        }
    }
}
