using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<InvitationParticipant> InvitationParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Invitations HasData
            List<Invitation> invitations = [new Invitation
                    {
                        Id = 1,
                        EventName="Noel Partisi",
                        EventDate = new DateTime(2024,12,25)
                    },
                    new Invitation
                    {
                        Id = 2,
                        EventName = "Doğum Günü Partisi",
                        EventDate = new DateTime(2024, 12, 12)
                    }];
            modelBuilder.Entity<Invitation>().HasData(invitations);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
