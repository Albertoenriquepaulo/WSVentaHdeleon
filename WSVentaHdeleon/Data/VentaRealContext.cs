using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSVentaHdeleon.Models
{
    public partial class VentaRealContext : DbContext
    {
        public VentaRealContext()
        {
        }

        public VentaRealContext(DbContextOptions<VentaRealContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=ALBERTLAPTOP;Database=VentaReal;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.Property(e => e.Importe).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.VentaId).HasColumnName("Venta_Id");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Concepto_Producto");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.Concepto)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Concepto_Venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Costo).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
