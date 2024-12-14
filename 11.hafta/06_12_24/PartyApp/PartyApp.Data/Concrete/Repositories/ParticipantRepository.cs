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
            //Databaseden tüm Participantsları çekip döndüreceğiz 
            var Participants = _appDbContext.Participants.ToList();

            return Participants;
        }

        public Participant GeyById(int id)
        {
            var Participant = _appDbContext.Participants.Where(x => x.Id == id).FirstOrDefault();
            return Participant;
        }
        public void Create(Participant Participant)
        {
            _appDbContext.Participants.Add(Participant);
            _appDbContext.SaveChanges();

        }
        public void Update(Participant Participant)
        {
            _appDbContext.Participants.Update(Participant);
            _appDbContext.SaveChanges();
        }
        public void Delete(Participant Participant)
        {
            _appDbContext.Participants.Remove(Participant);
            _appDbContext.SaveChanges();
        }
    }
}
