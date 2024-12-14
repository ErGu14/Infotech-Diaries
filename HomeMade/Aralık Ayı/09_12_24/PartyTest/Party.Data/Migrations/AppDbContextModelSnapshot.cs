﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Party.Data;

#nullable disable

namespace Party.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Party.Entity.Concrete.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Etkinlik-Tarihi");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Etkinlik-Adı");

                    b.HasKey("Id");

                    b.ToTable("Etkinlikler", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventDate = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Beşiktaş Fenerbahçe Maçı"
                        },
                        new
                        {
                            Id = 2,
                            EventDate = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Düğün Organizasyonu"
                        },
                        new
                        {
                            Id = 3,
                            EventDate = new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Oyun Turnuvası"
                        });
                });

            modelBuilder.Entity("Party.Entity.Concrete.InvitationParticipant", b =>
                {
                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("InvitationId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "InvitationId");

                    b.HasIndex("InvitationId");

                    b.ToTable("InvitationParticipants");

                    b.HasData(
                        new
                        {
                            ParticipantId = 1,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 2,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 3,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 4,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 5,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 6,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 7,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 8,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 9,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 10,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 11,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 12,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 13,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 14,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 15,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 16,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 1,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 2,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 3,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 4,
                            InvitationId = 1
                        },
                        new
                        {
                            ParticipantId = 5,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 6,
                            InvitationId = 2
                        },
                        new
                        {
                            ParticipantId = 7,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 8,
                            InvitationId = 3
                        },
                        new
                        {
                            ParticipantId = 9,
                            InvitationId = 1
                        });
                });

            modelBuilder.Entity("Party.Entity.Concrete.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte?>("Age")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("E-Posta");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Ad-Soyad");

                    b.Property<byte>("NumberOfPeople")
                        .HasMaxLength(255)
                        .HasColumnType("tinyint")
                        .HasColumnName("Ekstra-Katılım");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Telefon-Numarası");

                    b.HasKey("Id");

                    b.ToTable("Davetliler", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (byte)48,
                            Email = "didierdrogba@gmail.com",
                            FullName = "Didier Drogba",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0001"
                        },
                        new
                        {
                            Id = 2,
                            Age = (byte)36,
                            Email = "lionelmessi@gmail.com",
                            FullName = "Lionel Messi",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0002"
                        },
                        new
                        {
                            Id = 3,
                            Age = (byte)39,
                            Email = "cristianoronaldo@gmail.com",
                            FullName = "Cristiano Ronaldo",
                            NumberOfPeople = (byte)3,
                            PhoneNumber = "555-0003"
                        },
                        new
                        {
                            Id = 4,
                            Age = (byte)25,
                            Email = "kylianmbappe@gmail.com",
                            FullName = "Kylian Mbappe",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0004"
                        },
                        new
                        {
                            Id = 5,
                            Age = (byte)32,
                            Email = "neymarjr@gmail.com",
                            FullName = "Neymar Jr",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0005"
                        },
                        new
                        {
                            Id = 6,
                            Age = (byte)33,
                            Email = "kevindebruyne@gmail.com",
                            FullName = "Kevin De Bruyne",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0006"
                        },
                        new
                        {
                            Id = 7,
                            Age = (byte)35,
                            Email = "robertlewandowski@gmail.com",
                            FullName = "Robert Lewandowski",
                            NumberOfPeople = (byte)4,
                            PhoneNumber = "555-0007"
                        },
                        new
                        {
                            Id = 8,
                            Age = (byte)38,
                            Email = "sergioramos@gmail.com",
                            FullName = "Sergio Ramos",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0008"
                        },
                        new
                        {
                            Id = 9,
                            Age = (byte)38,
                            Email = "lukamodric@gmail.com",
                            FullName = "Luka Modric",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0009"
                        },
                        new
                        {
                            Id = 10,
                            Age = (byte)32,
                            Email = "virgilvandijk@gmail.com",
                            FullName = "Virgil van Dijk",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0010"
                        },
                        new
                        {
                            Id = 11,
                            Age = (byte)31,
                            Email = "mohamedsalah@gmail.com",
                            FullName = "Mohamed Salah",
                            NumberOfPeople = (byte)3,
                            PhoneNumber = "555-0011"
                        },
                        new
                        {
                            Id = 12,
                            Age = (byte)32,
                            Email = "sadiomane@gmail.com",
                            FullName = "Sadio Mane",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0012"
                        },
                        new
                        {
                            Id = 13,
                            Age = (byte)31,
                            Email = "harrykane@gmail.com",
                            FullName = "Harry Kane",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0013"
                        },
                        new
                        {
                            Id = 14,
                            Age = (byte)30,
                            Email = "raheemsterling@gmail.com",
                            FullName = "Raheem Sterling",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0014"
                        },
                        new
                        {
                            Id = 15,
                            Age = (byte)31,
                            Email = "paulpogba@gmail.com",
                            FullName = "Paul Pogba",
                            NumberOfPeople = (byte)1,
                            PhoneNumber = "555-0015"
                        },
                        new
                        {
                            Id = 16,
                            Age = (byte)33,
                            Email = "antoinegriezmann@gmail.com",
                            FullName = "Antoine Griezmann",
                            NumberOfPeople = (byte)2,
                            PhoneNumber = "555-0016"
                        });
                });

            modelBuilder.Entity("Party.Entity.Concrete.InvitationParticipant", b =>
                {
                    b.HasOne("Party.Entity.Concrete.Invitation", "Invitation")
                        .WithMany("İnvitationParticipants")
                        .HasForeignKey("InvitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Party.Entity.Concrete.Participant", "Participant")
                        .WithMany("InvitationParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invitation");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Party.Entity.Concrete.Invitation", b =>
                {
                    b.Navigation("İnvitationParticipants");
                });

            modelBuilder.Entity("Party.Entity.Concrete.Participant", b =>
                {
                    b.Navigation("InvitationParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
