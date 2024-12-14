using PartyApp.Data.Concrete.repos;
using PartyApp.Entity.Concrete;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Abstract
{
    public class ParticipantService
    {
        private readonly ParticipantRepos _repos;

        public ParticipantService(ParticipantRepos repos)
        {
            _repos = repos;
        }
        public List<ParticipantViewModel> GetAll()
        {
            var p = _repos.GetAll();
            List<ParticipantViewModel> pvm = p.Select(x => new ParticipantViewModel
            {
                Id = x.Id,
                Age = x.Age,
                Email = x.Email,
                FullName = x.FullName,
                NumberOfPeople = x.NumberOfPeople,
                PhoneNumber = x.PhoneNumber


            }).ToList();
            return pvm;
        }

        public List<ParticipantViewModel> GetAllById(int invid)
        {
            var p = _repos.GetAll(invid);
            var pvm = p.Select(x => new ParticipantViewModel
            {
                Id = x.Id,
                Age = x.Age,
                Email = x.Email,
                FullName = x.FullName,
                NumberOfPeople = x.NumberOfPeople,
                PhoneNumber = x.PhoneNumber,
                Invitations = x.InvitationParticipants.Select(ip => new InvitationViewModel
                {
                    Id = ip.Invitation.Id,
                    EventDate = ip.Invitation.EventDate,
                    EventName = ip.Invitation.EventName
                }).ToList()
                

            }).ToList();
            return pvm;


        }
        public void Create(ParticipantViewModel model, int invid)
        {
            Participant p = new()
            {
                Age = model.Age,
                Email = model.Email,
                FullName = model.FullName,
                NumberOfPeople = model.NumberOfPeople,
                PhoneNumber = model.PhoneNumber

            };
            _repos.Create(p); // ekleme yaptık
            InvitationParticipant ip = new()
            {
                ParticipantId = p.Id,
                InvitationId = invid,
            };
            p.InvitationParticipants = new List<InvitationParticipant>();
            p.InvitationParticipants.Add(ip); //junction table a ekliyoruz
            _repos.Update(p);



        }
    }
}
