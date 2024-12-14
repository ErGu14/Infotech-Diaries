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
    
    public class ParticipantService
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantService(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public List<ParticipantViewModel> GetAllByInvitationId(int invitationId)
        {
            List<Participant> participants = _participantRepository.GetAll(invitationId);
            List<ParticipantViewModel> participantViewModels =
                participants
                .Select(p=>new ParticipantViewModel
                {
                    Id = p.Id,
                    FullName=p.FullName,
                    Email=p.Email,
                    Age=p.Age,
                    NumberOfPeople=p.NumberOfPeople,
                    PhoneNumber=p.PhoneNumber,
                    Invitations = p.InvitationParticipants.Select(ip=>new InvitationViewModel
                    {
                        Id=ip.Invitation.Id,
                        EventName=ip.Invitation.EventName,
                        EventDate=ip.Invitation.EventDate
                    }).ToList()
                }).ToList();
            return participantViewModels;
        }
        public List<ParticipantViewModel> GetAll()
        {
            var participants = _participantRepository.GetAll();
            var participantsViewModels =
                participants
                .Select(p => new ParticipantViewModel
                {
                    Id = p.Id,
                    Age = p.Age,
                    NumberOfPeople = p.NumberOfPeople,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email,
                    FullName = p.FullName
                }).ToList();
            return participantsViewModels;
        }
        public void Create(ParticipantViewModel participantViewModel, int invitationId)
        {
            var participant = new Participant
            {
                FullName = participantViewModel.FullName,
                Age = participantViewModel.Age,
                Email = participantViewModel.Email,
                NumberOfPeople = (byte)participantViewModel.NumberOfPeople,
                PhoneNumber = participantViewModel.PhoneNumber
            };
            _participantRepository.Create(participant);
            InvitationParticipant invitationParticipant = new()
            {
                InvitationId = invitationId,
                ParticipantId = participant.Id
            };
            participant.InvitationParticipants=new List<InvitationParticipant>();
            participant.InvitationParticipants.Add(invitationParticipant);
            _participantRepository.Update(participant);
        }
    }
}
