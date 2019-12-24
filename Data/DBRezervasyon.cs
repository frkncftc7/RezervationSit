using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationSite.Data
{
    public partial class DBRezervasyon : DbContext
    {
        public DBRezervasyon()
        {
        }

        public DBRezervasyon(DbContextOptions<DBRezervasyon> options)
            : base(options)
        {
        }

        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Oteller> Oteller { get; set; }
        public virtual DbSet<Rezervasyonlar> Rezervasyonlar { get; set; }
        public virtual DbSet<Roller> Roller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dbrezervasyon.database.windows.net,1433;Initial Catalog=DBRezervasyon;Persist Security Info=False;User ID=cihangir;Password=Rezervasyon13579;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Oteller>(entity =>
            {
                entity.Property(e => e.OtelAdi).IsUnicode(false);

                entity.Property(e => e.Resim).IsUnicode(false);
            });

            modelBuilder.Entity<Rezervasyonlar>(entity =>
            {
                entity.HasOne(d => d.Kullanici)
                    .WithMany(p => p.Rezervasyonlar)
                    .HasForeignKey(d => d.KullaniciId)
                    .HasConstraintName("FK_Rezervasyonlar_Kullanicilar");

                entity.HasOne(d => d.Otel)
                    .WithMany(p => p.Rezervasyonlar)
                    .HasForeignKey(d => d.OtelId)
                    .HasConstraintName("FK_Rezervasyonlar_Oteller");
            });

            modelBuilder.Entity<Roller>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roller)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Roles_Kullanicilar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
