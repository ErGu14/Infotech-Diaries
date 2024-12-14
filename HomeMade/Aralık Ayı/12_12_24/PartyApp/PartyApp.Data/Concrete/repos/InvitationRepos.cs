using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.repos
{
    public class InvitationRepos
    {
        private readonly AppDbContext _appDbContext;

        public InvitationRepos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Invitation> GetAll() {
            var i = _appDbContext.Invitations.ToList();
            return i;
                  
        }
        public Invitation GetById(int id) {
            var i = _appDbContext.Invitations.Where(x => x.Id == id).First();
            return i;
        }

        public void Create(Invitation invitation) {
         _appDbContext.Invitations.Add(invitation);
            _appDbContext.SaveChanges();
        }
        public void Update(Invitation invitation) {
            _appDbContext.Invitations.Update(invitation);
            _appDbContext.SaveChanges();
        }
        public void Delete(Invitation i) {
            _appDbContext.Invitations.Remove(i);
            _appDbContext.SaveChanges();
        }
    }
}
