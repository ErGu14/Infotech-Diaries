﻿using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.Repositories
    // burası data ile alakalı bir yer vurdaki verilere ulaşılmasın biz view model oluşturarak sharedin içine görünecek tarafları alıyor olacağız

{
    public class InvitationRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvitationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Invitation> GetAll()
        {
            //Databaseden tüm invitationsları çekip döndüreceğiz 
            var invitations = _appDbContext.Invitations.ToList();

            return invitations;
        }

        public Invitation GeyById(int id)
        {
            var invitation = _appDbContext.Invitations.Where(x => x.Id == id).FirstOrDefault();
            return invitation;
        }
        public void Create(Invitation invitation)
        {
            _appDbContext.Invitations.Add(invitation);
            _appDbContext.SaveChanges();

        } 
        public void Update(Invitation invitation)
        {
            _appDbContext.Invitations.Update(invitation);
            _appDbContext.SaveChanges();
        }
        public void Delete(Invitation invitation)
        {
            _appDbContext.Invitations.Remove(invitation);
            _appDbContext.SaveChanges();
        }
    }
}
