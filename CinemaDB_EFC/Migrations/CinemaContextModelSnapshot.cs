﻿// <auto-generated />
using System;
using CinemaDB_EFC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaDBEFC.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaDB_EFC.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CinemaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CinemaId"));

                    b.Property<string>("CinemaName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Filmax");

                    b.Property<int>("WorkerAmmount")
                        .HasColumnType("int");

                    b.HasKey("CinemaId");

                    b.ToTable("Cinema", null, t =>
                        {
                            t.HasTrigger("Delete_Cinema");
                        });
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("Actors")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Anagraph")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("FilmName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FilmType")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Genre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FilmId");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Hall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HallID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HallId"));

                    b.Property<int>("CinemaId")
                        .HasColumnType("int")
                        .HasColumnName("CinemaID");

                    b.Property<string>("FilmList")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("HallNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("PlaceAmmount")
                        .HasColumnType("int")
                        .HasColumnName("Place_ammount");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("HallId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Hall", (string)null);
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WorkerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonId");

                    b.HasAlternateKey("FirstName", "LastName", "MiddleName");

                    b.ToTable("Person", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShowID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowId"));

                    b.Property<int>("BoughtTickets")
                        .HasColumnType("int")
                        .HasColumnName("Bought_tickets");

                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnName("FilmID");

                    b.Property<int>("HallId")
                        .HasColumnType("int")
                        .HasColumnName("HallID");

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("ShowId");

                    b.HasIndex("FilmId");

                    b.HasIndex("HallId");

                    b.ToTable("Show", (string)null);
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int")
                        .HasColumnName("ShowID");

                    b.HasKey("TicketId")
                        .HasName("PK__Ticket__712CC6273EA99273");

                    b.HasIndex("ShowId");

                    b.ToTable("Ticket", null, t =>
                        {
                            t.HasTrigger("Delete_ticket");

                            t.HasTrigger("Minus_ticket");

                            t.HasTrigger("New_ticket");

                            t.HasTrigger("Place_check");

                            t.HasTrigger("Plus_ticket");
                        });
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Worker", b =>
                {
                    b.HasBaseType("CinemaDB_EFC.Models.Person");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int")
                        .HasColumnName("CinemaID");

                    b.Property<int?>("Idcard")
                        .HasColumnType("int")
                        .HasColumnName("IDcard");

                    b.Property<int?>("NumberId")
                        .HasColumnType("int")
                        .HasColumnName("NumberID");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasIndex("CinemaId");

                    b.ToTable("Worker", (string)null);
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Hall", b =>
                {
                    b.HasOne("CinemaDB_EFC.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Show", b =>
                {
                    b.HasOne("CinemaDB_EFC.Models.Film", "Film")
                        .WithMany("Shows")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaDB_EFC.Models.Hall", "Hall")
                        .WithMany("Shows")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Ticket", b =>
                {
                    b.HasOne("CinemaDB_EFC.Models.Show", "Show")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Worker", b =>
                {
                    b.HasOne("CinemaDB_EFC.Models.Cinema", "Cinema")
                        .WithMany("Workers")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaDB_EFC.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("CinemaDB_EFC.Models.Worker", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Cinema", b =>
                {
                    b.Navigation("Halls");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Film", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Hall", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("CinemaDB_EFC.Models.Show", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
