using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Invitation>  Invitations { get; set; }
        public DbSet<Participant>  Participants { get; set; }
        public DbSet<InvitationParticipant>  InvitationParticipants { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region InvitationsHasData
            List<Invitation> invitations = [
                    new Invitation
                    {
                        Id=1,
                        EventName="Noel Partisi",
                        EventDate=new DateTime(2024,12,25)
                    },
                    new Invitation
                    {
                        Id=2,
                        EventName="Doğum Günü Partisi",
                        EventDate=new DateTime(2024,12,12)
                    }
                ];
            modelBuilder.Entity<Invitation>().HasData(invitations);
            #endregion

            #region ParticipantsHasData
            List<Participant> participants = [
            new Participant { Id = 1, FullName = "Didier Drogba", Age = 48, Email = "didierdrogba@gmail.com", NumberOfPeople = 1, PhoneNumber = "" },
            new Participant { Id = 2, FullName = "Lionel Messi", Age = 37, Email = "lionelmessi@gmail.com", NumberOfPeople = 3, PhoneNumber = "123-456-7890" },
            new Participant { Id = 3, FullName = "Cristiano Ronaldo", Age = 39, Email = "cristianoronaldo@gmail.com", NumberOfPeople = 5, PhoneNumber = "234-567-8901" },
            new Participant { Id = 4, FullName = "Neymar Jr.", Age = 32, Email = "neymar@gmail.com", NumberOfPeople = 2, PhoneNumber = "345-678-9012" },
            new Participant { Id = 5, FullName = "Kylian Mbappé", Age = 25, Email = "kylianmbappe@gmail.com", NumberOfPeople = 4, PhoneNumber = "456-789-0123" },
            new Participant { Id = 6, FullName = "Mohamed Salah", Age = 31, Email = "mohamedsalah@gmail.com", NumberOfPeople = 4, PhoneNumber = "567-890-1234" },
            new Participant { Id = 7, FullName = "Kevin De Bruyne", Age = 33, Email = "kevindebruyne@gmail.com", NumberOfPeople = 2, PhoneNumber = "678-901-2345" },
            new Participant { Id = 8, FullName = "Harry Kane", Age = 30, Email = "harrykane@gmail.com", NumberOfPeople = 3, PhoneNumber = "789-012-3456" },
            new Participant { Id = 9, FullName = "Sergio Ramos", Age = 38, Email = "sergioramos@gmail.com", NumberOfPeople = 2, PhoneNumber = "890-123-4567" },
            new Participant { Id = 10, FullName = "Robert Lewandowski", Age = 35, Email = "robertlewandowski@gmail.com", NumberOfPeople = 4, PhoneNumber = "901-234-5678" }
                ];
            modelBuilder.Entity<Participant>().HasData(participants);
            #endregion

            #region InvitationParticipantsHasData
            List<InvitationParticipant> invitationParticipants = [
                new() {InvitationId = 1, ParticipantId=1},
                new() {InvitationId = 1, ParticipantId=2},
                new() {InvitationId = 1, ParticipantId=3},
                new() {InvitationId = 1, ParticipantId=4},
                new() {InvitationId = 1, ParticipantId=5},
                new() {InvitationId = 1, ParticipantId=6},
                new() {InvitationId = 1, ParticipantId=7},
                new() {InvitationId = 1, ParticipantId=8},
                new() {InvitationId = 1, ParticipantId=10},

                new() {InvitationId = 2, ParticipantId=2},
                new() {InvitationId = 2, ParticipantId=4},
                new() {InvitationId = 2, ParticipantId=6},
                new() {InvitationId = 2, ParticipantId=7},
                new() {InvitationId = 2, ParticipantId=8},
                new() {InvitationId = 2, ParticipantId=9},
                new() {InvitationId = 2, ParticipantId=10}
                ];
            modelBuilder.Entity<InvitationParticipant>().HasData(invitationParticipants);
            #endregion

            #region InvitationConfigures
            modelBuilder.Entity<Invitation>().HasKey(x => x.Id);//Primary key
            modelBuilder.Entity<Invitation>().Property(x => x.Id).ValueGeneratedOnAdd();//Auto increment
            modelBuilder.Entity<Invitation>().Property(x=>x.EventName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Invitation>().ToTable("Invitations");
            #endregion

            #region ParticipantConfigures
            modelBuilder.Entity<Participant>().HasKey(x => x.Id);
            modelBuilder.Entity<Participant>().Property(x=>x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Participant>().Property(x=>x.FullName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>().Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(300);
            modelBuilder.Entity<Participant>().Property(x=>x.Age).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x=>x.PhoneNumber).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x=>x.NumberOfPeople).IsRequired();
            modelBuilder.Entity<Participant>().ToTable("Participants");
            #endregion

            #region InvitationParticipantConfigures
            modelBuilder.Entity<InvitationParticipant>().HasKey(x => new { x.InvitationId, x.ParticipantId });
            #endregion
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
