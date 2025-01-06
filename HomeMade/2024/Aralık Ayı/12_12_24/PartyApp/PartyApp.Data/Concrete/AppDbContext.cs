using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete
{
    public class AppDbContext : DbContext
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

            #region Participants HasData
            List<Participant> participants = [
                new (){
                    Id = 1,
                    FullName = "Ricardo Quaresma",
                    Age = 42,
                    Email = "q7@gmail.com",
                    NumberOfPeople = 1,
                    PhoneNumber = ""
                },
                new (){
                    Id = 2,
                    FullName = "Cristiano Ronaldo",
                    Age = 38,
                    Email = "cr7@gmail.com",
                    NumberOfPeople = 3,
                    PhoneNumber = "1234567890"
                },
                new (){
                    Id = 3,
                    FullName = "Lionel Messi",
                    Age = 36,
                    Email = "lm10@gmail.com",
                    NumberOfPeople = 4,
                    PhoneNumber = "0987654321"
                },
                new (){
                    Id = 4,
                    FullName = "Neymar Jr.",
                    Age = 32,
                    Email = "njr10@gmail.com",
                    NumberOfPeople = 2,
                    PhoneNumber = "1122334455"
                },
                new (){
                    Id = 5,
                    FullName = "Kylian Mbappe",
                    Age = 25,
                    Email = "km7@gmail.com",
                    NumberOfPeople = 1,
                    PhoneNumber = "6677889900"
                },
                new (){
                    Id = 6,
                    FullName = "Zlatan Ibrahimovic",
                    Age = 42,
                    Email = "zi9@gmail.com",
                    NumberOfPeople = 5,
                    PhoneNumber = "5566778899"
                },
                new (){
                    Id = 7,
                    FullName = "Sergio Ramos",
                    Age = 38,
                    Email = "sr4@gmail.com",
                    NumberOfPeople = 3,
                    PhoneNumber = "4455667788"
                },
                new (){
                    Id = 8,
                    FullName = "Luka Modric",
                    Age = 38,
                    Email = "lm10@gmail.com",
                    NumberOfPeople = 2,
                    PhoneNumber = "2233445566"
                },
                new (){
                    Id = 9,
                    FullName = "Kevin De Bruyne",
                    Age = 32,
                    Email = "kdb17@gmail.com",
                    NumberOfPeople = 4,
                    PhoneNumber = "3344556677"
                },
                new (){
                    Id = 10,
                    FullName = "Robert Lewandowski",
                    Age = 36,
                    Email = "rl9@gmail.com",
                    NumberOfPeople = 3,
                    PhoneNumber = "7788990011"
                },
                new (){
                    Id = 11,
                    FullName = "Mohamed Salah",
                    Age = 32,
                    Email = "ms11@gmail.com",
                    NumberOfPeople = 2,
                    PhoneNumber = "9988776655"
                }



                        ];
            modelBuilder.Entity<Participant>().HasData(participants);

            #endregion

            #region InvitationParticipant HasData
            List<InvitationParticipant> invitationParticipants = [
                new() {
                   
                    InvitationId = 1,
                    ParticipantId = 3
                },
                new() {
                    
                    InvitationId = 1,
                    ParticipantId = 7
                },
                new() {
                    
                    InvitationId = 1,
                    ParticipantId = 1
                },
                new() {
                   
                    InvitationId = 1,
                    ParticipantId = 9
                },
                new() {
                    
                    InvitationId = 1,
                    ParticipantId = 5
                },
                new() {
                    
                    InvitationId = 2,
                    ParticipantId = 2
                },
                new() {
                    
                    InvitationId = 2,
                    ParticipantId = 8
                },
                new() {
                   
                    InvitationId = 2,
                    ParticipantId = 4
                },
                new() {
                    
                    InvitationId = 2,
                    ParticipantId = 11
                },
                new() {
                   
                    InvitationId = 2,
                    ParticipantId = 6
                },
                new() {
                    
                    InvitationId = 2,
                    ParticipantId = 10
                }

                ];
            modelBuilder.Entity<InvitationParticipant>().HasData(invitationParticipants);

            #endregion

            // veri tabanıyla ilgili nerdeyse her şeyi burda yapıyoruz

            #region Invitations Configures
            modelBuilder.Entity<Invitation>().HasKey(x => x.Id); //primary key yapma ,  ZORUNLULUK YOK ama içinde ıd yerine number vs gibi bişi yapsaydım ve onu primary key yapmam lazım olsaydı işte bu komudu yazmam lazımdı

            modelBuilder.Entity<Invitation>().Property(x => x.Id).ValueGeneratedOnAdd(); //her yeni prop eklendiğinde yeni ıd ekliyor gibi (auto increment)


            modelBuilder
                .Entity<Invitation>()
                .Property(x => x.EventName)
                .IsRequired()
                .HasMaxLength(100); // not null (zorunlu kıl = true   zorunlu olmasın == false)  bir alt satırdaki  lenght ise istediğim yazı uzunluğunu ayarlamama yarıyor

            modelBuilder.Entity<Invitation>().ToTable("Invitations"); // tablo oluşurken tablo adını istediğim şekilde yapabiliyorum.



            #endregion

            #region Participants Configures

            

            modelBuilder.Entity<Participant>().HasKey(x => x.Id);
            modelBuilder.Entity<Participant>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Participant>().Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>().Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>().Property(x => x.Age).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x => x.PhoneNumber).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x => x.NumberOfPeople).IsRequired();
            modelBuilder.Entity<Participant>().ToTable("Participants");

            #endregion

            #region InvitationParticipants

            modelBuilder.Entity<InvitationParticipant>().HasKey(x => new {x.InvitationId,x.ParticipantId}); //her x için senin primary key olarak kabul etmen gereken bilgi şudur (parantez içindeki ıdler) ıd ler bir kez daha tekrar etmicek

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
