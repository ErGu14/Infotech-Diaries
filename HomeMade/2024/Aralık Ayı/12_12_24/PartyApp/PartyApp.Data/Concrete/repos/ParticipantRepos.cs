using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.repos
{
    public class ParticipantRepos
    {
        private readonly AppDbContext _db;

        public ParticipantRepos(AppDbContext db)
        {
            _db = db;
        }

        public List<Participant> GetAll() {
            var p =_db.Participants.ToList();
            return p;
        }

        public List<Participant> GetAll(int invitationId) //tıklanan inv.id ye göre katılımcıları getircek
        {
            // çoka çok ilişkilerde ıdleri birbitiyle eşleştirmek için yapılan bir tablo
            var p = _db.Participants
                .Include(x => x.InvitationParticipants)
                .ThenInclude(ip => ip.Invitation)// buraya kadar joinleme işlemi yaptık
                .Where(y => y.InvitationParticipants.Any(ip => ip.InvitationId == invitationId)) // gelen verileri çoka çok tabloda idlerin eşlenmesini sağladık
                .ToList();
            return p;
        }



        public Participant GetById(int id) {
            var p = _db.Participants.Where(x => x.Id == id).First();
            return p;
        }

        public void Create(Participant participant)
        {
            _db.Participants.Add(participant);
            _db.SaveChanges();
        }
        public void Update(Participant participant) { 
            _db.Update(participant);
            _db.SaveChanges();
        }
        public void Delete(Participant participant) {
            _db.Participants.Remove(participant);
            _db.SaveChanges();
        }



    }
}
