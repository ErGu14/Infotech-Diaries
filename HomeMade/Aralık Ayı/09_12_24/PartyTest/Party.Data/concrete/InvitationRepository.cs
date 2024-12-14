using Party.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Data.Concrete
{

    public class InvitationRepository
    {
        private readonly AppDbContext _context;

        public InvitationRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Invitation> GetAll()
        {
           var i = _context.Invitations.ToList();
           return i;
        }

        public Invitation GetById(int id) {
        
            var i = _context.Invitations.Where(i => i.Id == id).First();
            return i;
        }
        public void Create(Invitation invitation) { 
            var i = _context.Invitations.Add(invitation); // eklemek
            _context.SaveChanges();
        }
        public void Update(Invitation invitation) {
            var i = _context.Invitations.Update(invitation);
            _context.SaveChanges();
        }
        public void Delete(Invitation invitation) { 
            var i = _context.Invitations.Remove(invitation);
            _context.SaveChanges();
        }
    }
}



