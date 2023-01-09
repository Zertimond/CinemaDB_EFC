using System;
using System.Collections.Generic;
using CinemaDB_EFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CinemaDB_EFC;

public partial class CinemaContext : DbContext
{
    public CinemaContext() {}

    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();       
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        string? connectionString = config.GetConnectionString("DefaultConnection");

        var options = optionsBuilder.UseSqlServer(connectionString).Options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var FullName = modelBuilder.Entity<Person>();
        FullName.HasAlternateKey(s => new { s.FirstName, s.LastName, s.MiddleName});

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.ToTable("Cinema", tb => tb.HasTrigger("Delete_Cinema"));

            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.CinemaName).HasDefaultValue("Filmax");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Actors).HasMaxLength(70);
            entity.Property(e => e.Anagraph).HasMaxLength(50);
            entity.Property(e => e.FilmName).HasMaxLength(20);
            entity.Property(e => e.FilmType).HasMaxLength(2);
            entity.Property(e => e.Genre).HasMaxLength(20);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.ToTable("Hall");

            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.HallNumber).HasDefaultValue(1);
            entity.Property(e => e.FilmList).HasMaxLength(30);
            entity.Property(e => e.PlaceAmmount).HasColumnName("Place_ammount");
            entity.Property(e => e.Schedule).HasMaxLength(30);

            entity.HasOne(d => d.Cinema).WithMany(p => p.Halls)
                .HasForeignKey(d => d.CinemaId);
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.ToTable("Show");

            entity.Property(e => e.ShowId).HasColumnName("ShowID");
            entity.Property(e => e.BoughtTickets).HasColumnName("Bought_tickets");
            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.ShowDate).HasColumnType("date");

            entity.HasOne(d => d.Film).WithMany(p => p.Shows)
                .HasForeignKey(d => d.FilmId);

            entity.HasOne(d => d.Hall).WithMany(p => p.Shows)
                .HasForeignKey(d => d.HallId);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC6273EA99273");

            entity.ToTable("Ticket", tb =>
                {
                    tb.HasTrigger("Delete_ticket");
                    tb.HasTrigger("Minus_ticket");
                    tb.HasTrigger("New_ticket");
                    tb.HasTrigger("Place_check");
                    tb.HasTrigger("Plus_ticket");
                });

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.ShowId).HasColumnName("ShowID");

            entity.HasOne(d => d.Show).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ShowId);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("Worker");

            entity.Property(e => e.PersonId).HasColumnName("WorkerID");
            entity.Property(e => e.Adress).HasMaxLength(40);
            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.Idcard).HasColumnName("IDcard");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.NumberId).HasColumnName("NumberID");
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.Telephone).HasMaxLength(10);

            entity.HasOne(d => d.Cinema).WithMany(p => p.Workers)
                .HasForeignKey(d => d.CinemaId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
