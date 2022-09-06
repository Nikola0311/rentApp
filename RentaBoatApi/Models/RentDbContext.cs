using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentaBoatApi.Models
{
    public partial class RentDbContext : DbContext
    {
        public RentDbContext()
        {
        }

        public RentDbContext(DbContextOptions<RentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boat> Boats { get; set; } = null!;
        public virtual DbSet<BoatReservation> BoatReservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=DESKTOP-3OD504Q;Database=RentDb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Model)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.PersonsMax).HasColumnName("persons_max");

                entity.Property(e => e.Producer)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("producer");

                entity.Property(e => e.ProductionYear).HasColumnName("production_year");
            });

            modelBuilder.Entity<BoatReservation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("check_in_date");

                entity.Property(e => e.CheckInTime).HasColumnName("check_in_time");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("date")
                    .HasColumnName("check_out_date");

                entity.Property(e => e.CheckOutTime).HasColumnName("chek_out_time");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdBoat).HasColumnName("id_boat");

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("message");

                entity.Property(e => e.PersonsNumber).HasColumnName("persons_number");

                entity.Property(e => e.Phone)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.IdBoatNavigation)
                    .WithMany(p => p.BoatReservations)
                    .HasForeignKey(d => d.IdBoat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BoatReser__id_bo__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
