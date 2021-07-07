using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Unblock_Me.Models
{
    public partial class Unblock_MeContext : IdentityDbContext<User>
    {
        public Unblock_MeContext()
        {
        }

        public Unblock_MeContext(DbContextOptions<Unblock_MeContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-VRLK5JVV\\SQLEXPRESS;Database=Unblock_Me;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.LicencePlate)
                    .HasName("PK__car__6570E330584EDC0D");

                entity.ToTable("car");

                entity.Property(e => e.LicencePlate)
                    .HasColumnName("licence_plate")
                    .HasMaxLength(10);

                entity.Property(e => e.BlockedByLicencePlate)
                    .HasColumnName("blockedBy_licence_plate")
                    .HasMaxLength(10);

                entity.Property(e => e.BlockedLicencePlate)
                    .HasColumnName("blocked_licence_plate")
                    .HasMaxLength(10);

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Maker)
                    .HasColumnName("maker")
                    .HasMaxLength(30);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(20);

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Car_AspNetUsers");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.MainLicensePlate);

                entity.ToTable("status");

                entity.Property(e => e.MainLicensePlate)
                    .HasColumnName("main_license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.BlockedByLicensePlate)
                    .HasColumnName("blockedBy_license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.BlockedLicensePlate)
                    .HasColumnName("blocked_license_plate")
                    .HasMaxLength(20);

                entity.Property(e => e.NrBlockedCars).HasColumnName("nr_blocked_cars");
            });

            modelBuilder.Entity<User>(entity =>
            {

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(30);

                entity.Property(e => e.Rating).HasColumnName("Rating");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
