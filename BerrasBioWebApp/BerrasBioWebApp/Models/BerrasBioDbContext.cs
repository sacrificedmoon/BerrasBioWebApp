using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BerrasBioWebApp.Models
{
    public partial class BerrasBioDbContext : DbContext
    {
        public BerrasBioDbContext()
        {
        }

        public BerrasBioDbContext(DbContextOptions<BerrasBioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FilmSchedule> FilmSchedule { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmSchedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Filmid).HasColumnName("filmid");

                entity.Property(e => e.Freechairs).HasColumnName("freechairs");

                entity.Property(e => e.Fullybooked).HasColumnName("fullybooked");

                entity.Property(e => e.Salonid).HasColumnName("salonid");

                entity.Property(e => e.Showtime)
                    .HasColumnName("showtime")
                    .HasColumnType("time(0)");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmSchedule)
                    .HasForeignKey(d => d.Filmid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FilmSched__filmi__3F466844");

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.FilmSchedule)
                    .HasForeignKey(d => d.Salonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FilmSched__salon__403A8C7D");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("time(0)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Salon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Seats).HasColumnName("seats");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
