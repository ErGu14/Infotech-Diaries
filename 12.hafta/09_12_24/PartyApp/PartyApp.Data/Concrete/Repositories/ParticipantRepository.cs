using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.Repositories
{
    public class ParticipantRepository
    {
        private readonly AppDbContext _appDbContext;

        public ParticipantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Participant> GetAll()
        {
            var participants = _appDbContext.Participants.ToList();
            return participants;
        }

        public List<Participant> GetAll(int invitationId)
        {
            // Davetiyeye bağlı katılımcıları getirmek
            var participants = _appDbContext
                .Participants
                .Include(x => x.InvitationParticipants)
                .ThenInclude(ip => ip.Invitation)
                .Where(p => p.InvitationParticipants.Any(ip => ip.InvitationId == invitationId)) // davetiye ID'sine göre filtreleme
                .ToList();

            return participants;
        }

        public Participant GetById(int id)
        {
            var participant = _appDbContext.Participants.Where(x => x.Id == id).FirstOrDefault();
            return participant;
        }

        public void Create(Participant participant)
        {
            _appDbContext.Participants.Add(participant);
            _appDbContext.SaveChanges();
        }

        public void Update(Participant participant)
        {
            _appDbContext.Participants.Update(participant);
            _appDbContext.SaveChanges();
        }

        public void Delete(Participant participant)
        {
            _appDbContext.Participants.Remove(participant);
            _appDbContext.SaveChanges();
        }
    }
}
