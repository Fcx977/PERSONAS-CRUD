using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TALLERCON.Models
{
    public partial class TALLERCONContext : DbContext
    {
        public TALLERCONContext()
        {
        }

        public TALLERCONContext(DbContextOptions<TALLERCONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.DocIdentificacion)
                    .HasName("PK__PERSONA__E7DDBB2F7BFA4B14");

                entity.ToTable("PERSONA");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CiudadDireccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoNivelEstudio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Credencial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.oRol)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Rol");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__ROLES__2A49584CBF809E66");

                entity.ToTable("ROLES");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
