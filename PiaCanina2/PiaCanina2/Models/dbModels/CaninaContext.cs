using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

//Base de Datos SQL en Visual

namespace PiaCanina2.Models.dbModels
{
    public partial class CaninaContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public CaninaContext()
        {
        }

        public CaninaContext(DbContextOptions<CaninaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Perro> Perros { get; set; }
        public virtual DbSet<PerroVacuna> PerroVacunas { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Tamano> Tamanos { get; set; }
        public virtual DbSet<Vacuna> Vacunas { get; set; }
        public virtual DbSet<Vcliente> Vclientes { get; set; }
        public virtual DbSet<VhistorialMedico> VhistorialMedicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Perro>(entity =>
            {
                entity.HasOne(d => d.RazaNavigation)
                    .WithMany(p => p.Perros)
                    .HasForeignKey(d => d.Raza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perros_Raza");

                entity.HasOne(d => d.TamañoNavigation)
                    .WithMany(p => p.Perros)
                    .HasForeignKey(d => d.Tamaño)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perros_Tamano");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Perros)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perros_Usuarios");
            });

            modelBuilder.Entity<PerroVacuna>(entity =>
            {
                entity.HasKey(e => new { e.Idperro, e.Idvacuna });

                entity.HasOne(d => d.IdperroNavigation)
                    .WithMany(p => p.PerroVacunas)
                    .HasForeignKey(d => d.Idperro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerroVacuna_Perros");

                entity.HasOne(d => d.IdvacunaNavigation)
                    .WithMany(p => p.PerroVacunas)
                    .HasForeignKey(d => d.Idvacuna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerroVacuna_Vacunas");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.Property(e => e.NombreVacuna).IsFixedLength(true);
            });

            modelBuilder.Entity<Vcliente>(entity =>
            {
                entity.ToView("VCliente");
            });

            modelBuilder.Entity<VhistorialMedico>(entity =>
            {
                entity.ToView("VHistorial_Medico");

                entity.Property(e => e.NombreVacuna).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
