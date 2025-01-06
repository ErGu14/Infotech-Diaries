using Azure;
using Microsoft.EntityFrameworkCore;
using Party.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party.Data
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
            #region Invitation Configures
            modelBuilder.Entity<Invitation>().HasKey(x => x.Id);
            modelBuilder.Entity<Invitation>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Invitation>().Property(x => x.EventName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Invitation>().Property(x => x.EventName).HasColumnName("Etkinlik-Adı");
            modelBuilder.Entity<Invitation>().Property(x => x.EventDate).HasColumnName("Etkinlik-Tarihi");
            modelBuilder.Entity<Invitation>().ToTable("Etkinlikler");
            #endregion
            #region Participant Configures
            modelBuilder.Entity<Participant>().HasKey(x => x.Id);
            modelBuilder.Entity<Participant>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Participant>().Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>().Property(x => x.FullName).HasColumnName("Ad-Soyad");
            
            modelBuilder.Entity<Participant>().Property(x => x.Age).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x => x.FullName).HasColumnName("Ad-Soyad");
            modelBuilder.Entity<Participant>().Property(x => x.Email).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Participant>().Property(x => x.Email).HasColumnName("E-Posta");
            modelBuilder.Entity<Participant>().Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Participant>().Property(x => x.PhoneNumber).HasColumnName("Telefon-Numarası");
            modelBuilder.Entity<Participant>().Property(x => x.NumberOfPeople).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Participant>().Property(x => x.NumberOfPeople).HasColumnName("Ekstra-Katılım");
            modelBuilder.Entity<Participant>().ToTable("Davetliler");
            #endregion
            #region IntitationsParticipants Configures

            modelBuilder.Entity<InvitationParticipant>().HasKey(x => new { x.ParticipantId, x.InvitationId }); //2 sininde primary olup tekrar ETMEMESİNİ sağlıyoruz

            #endregion

            #region Invitation HasData

            List<Invitation> invitations = [
                 new Invitation
                    {
                        Id=1,
                        EventName="Beşiktaş Fenerbahçe Maçı",
                        EventDate =new DateTime(2024,12,12)
                    },
                    new Invitation
                    {
                        Id=2,
                        EventName="Düğün Organizasyonu",
                        EventDate=new DateTime(2024,12,12)
                    },
                    new Invitation
                    {
                        Id=3,
                        EventName="Oyun Turnuvası",
                        EventDate=new DateTime(2025,01,14)
                    }
            ];
            modelBuilder.Entity<Invitation>().HasData(invitations);
            #endregion
            #region ParticipantsHasData
            List<Participant> participants = [
                  new Participant { Id = 1, FullName = "Didier Drogba", Age = 48, Email = "didierdrogba@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0001" },
                  new Participant { Id = 2, FullName = "Lionel Messi", Age = 36, Email = "lionelmessi@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0002" },
                  new Participant { Id = 3, FullName = "Cristiano Ronaldo", Age = 39, Email = "cristianoronaldo@gmail.com", NumberOfPeople = 3, PhoneNumber = "555-0003" },
                  new Participant { Id = 4, FullName = "Kylian Mbappe", Age = 25, Email = "kylianmbappe@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0004" },
                  new Participant { Id = 5, FullName = "Neymar Jr", Age = 32, Email = "neymarjr@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0005" },
                  new Participant { Id = 6, FullName = "Kevin De Bruyne", Age = 33, Email = "kevindebruyne@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0006" },
                  new Participant { Id = 7, FullName = "Robert Lewandowski", Age = 35, Email = "robertlewandowski@gmail.com", NumberOfPeople = 4, PhoneNumber = "555-0007" },
                  new Participant { Id = 8, FullName = "Sergio Ramos", Age = 38, Email = "sergioramos@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0008" },
                  new Participant { Id = 9, FullName = "Luka Modric", Age = 38, Email = "lukamodric@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0009" },
                  new Participant { Id = 10, FullName = "Virgil van Dijk", Age = 32, Email = "virgilvandijk@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0010" },
                  new Participant { Id = 11, FullName = "Mohamed Salah", Age = 31, Email = "mohamedsalah@gmail.com", NumberOfPeople = 3, PhoneNumber = "555-0011" },
                  new Participant { Id = 12, FullName = "Sadio Mane", Age = 32, Email = "sadiomane@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0012" },
                  new Participant { Id = 13, FullName = "Harry Kane", Age = 31, Email = "harrykane@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0013" },
                  new Participant { Id = 14, FullName = "Raheem Sterling", Age = 30, Email = "raheemsterling@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0014" },
                  new Participant { Id = 15, FullName = "Paul Pogba", Age = 31, Email = "paulpogba@gmail.com", NumberOfPeople = 1, PhoneNumber = "555-0015" },
                  new Participant { Id = 16, FullName = "Antoine Griezmann", Age = 33, Email = "antoinegriezmann@gmail.com", NumberOfPeople = 2, PhoneNumber = "555-0016" }];
                    
             modelBuilder.Entity<Participant>().HasData(participants);
            #endregion
            #region InvitationParticipants HasData
            List<InvitationParticipant> invparts = [

                new () {InvitationId = 1, ParticipantId = 1}, 
                new () {InvitationId = 1, ParticipantId = 2},
                new () {InvitationId = 2, ParticipantId = 3}, 
                new () {InvitationId = 2, ParticipantId = 4}, 
                new () {InvitationId = 3, ParticipantId = 5},
                new () {InvitationId = 3, ParticipantId = 6}, 
                new () {InvitationId = 1, ParticipantId = 7},
                new () {InvitationId = 1, ParticipantId = 8},
                new () {InvitationId = 2, ParticipantId = 9},
                new () {InvitationId = 2, ParticipantId = 10},
                new () {InvitationId = 3, ParticipantId = 11}, 
                new () {InvitationId = 3, ParticipantId = 12}, 
                new () {InvitationId = 1, ParticipantId = 13}, 
                new () {InvitationId = 1, ParticipantId = 14}, 
                new () {InvitationId = 2, ParticipantId = 15}, 
                new () {InvitationId = 2, ParticipantId = 16},
                new () {InvitationId = 3, ParticipantId = 1}, 
                new () {InvitationId = 3, ParticipantId = 2},
                new () {InvitationId = 1, ParticipantId = 3}, 
                new () {InvitationId = 1, ParticipantId = 4}, 
                new () {InvitationId = 2, ParticipantId = 5}, 
                new () {InvitationId = 2, ParticipantId = 6}, 
                new () {InvitationId = 3, ParticipantId = 7}, 
                new () {InvitationId = 3, ParticipantId = 8}, 
                new () {InvitationId = 1, ParticipantId = 9}

                ];
            modelBuilder.Entity<InvitationParticipant>().HasData(invparts);
            #endregion
            base.OnModelCreating(modelBuilder);
        }

    }
}

