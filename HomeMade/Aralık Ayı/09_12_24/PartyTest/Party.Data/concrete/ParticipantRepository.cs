using Party.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Data.concrete
{
    public class ParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Participant> GetAll()
        {
            var p = _context.Participants.ToList();
            return p;
        }
        public Participant GetById(int id) {
            var p = _context.Participants.Where(x => x.Id == id).FirstOrDefault();
            return p;

        }
        public void Create(Participant participant) {
            var p = _context.Participants.Add(participant);
            _context.SaveChanges();
        }
        public void Update(Participant participant) {
            var p = _context.Participants.Update(participant);
            _context.SaveChanges();
        }
        public void Delete(Participant participant)
        {
            var p = _context.Participants.Remove(participant);
            _context.SaveChanges();
        }
    }
}
