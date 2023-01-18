using Microsoft.EntityFrameworkCore;
using Persona_API_MedVision.Model;

namespace Persona_API_MedVision.Data
{
    public class SqlDbContext_PruebaMedVisionDB : DbContext
    {
        public SqlDbContext_PruebaMedVisionDB(DbContextOptions<SqlDbContext_PruebaMedVisionDB> options) : base(options)
        {
        }

        public virtual DbSet<Persona> persona { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Persona>(entity =>
            {

                entity.ToTable("persona");
                entity.HasKey(p => p.IdPersona);

                entity.Property(e => e.IdPersona)
                    .HasColumnName("id_persona")
                    .HasComment("Id persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .HasColumnName("apellido")
                    .HasComment("Apellidos persona");

                entity.Property(e => e.Edad)
                    .HasColumnName("edad")
                    .HasComment("Edad persona");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(30)
                    .HasColumnName("identificacion")
                    .HasComment("Identificacion persona");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .HasColumnName("nombre")
                    .HasComment("Nombre persona");
            });

        }
    }
}
