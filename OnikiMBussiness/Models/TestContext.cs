using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnikiMBussiness.Models
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sti> Sti { get; set; }
        public virtual DbSet<Stk> Stk { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=Test;Trusted_Connection=True;");
            }
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sti>(entity =>
            {
                entity.HasKey(e => new { e.EvrakNo, e.Tarih, e.IslemTur })
                    .HasName("pkSTI");

                entity.ToTable("STI");

                entity.Property(e => e.EvrakNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Birim)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Fiyat).HasColumnType("numeric(25, 6)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MalKodu)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Miktar).HasColumnType("numeric(25, 6)");

                entity.Property(e => e.Tutar).HasColumnType("numeric(25, 6)");
            });

            modelBuilder.Entity<Stk>(entity =>
            {
                entity.HasKey(e => e.MalKodu)
                    .HasName("pkSTK");

                entity.ToTable("STK");

                entity.Property(e => e.MalKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MalAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<spModel>();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

      
    }
}
