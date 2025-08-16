using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class VariedadConfiguration : IEntityTypeConfiguration<Variedad>
    {
        public void Configure(EntityTypeBuilder<Variedad> builder)
        {
            // Tabla y clave primaria
            builder.ToTable("variedades");
            builder.HasKey(v => v.Id);

            // Propiedades básicas
            builder.Property(v => v.Nombre)
                   .IsRequired()
                   .HasMaxLength(120);


            // Índices (opcional: único por nombre si lo quieres así)
            builder.HasIndex(v => v.Nombre).IsUnique();

            // ===== Relaciones (FKs) con catálogos =====

            builder.Property(v => v.TamanoGranoId)
           .HasColumnName("tamano_grano_id");

            builder.HasOne(v => v.TamanoGrano)
           .WithMany()
           .HasForeignKey(v => v.TamanoGranoId)
           .OnDelete(DeleteBehavior.Restrict)
           .HasConstraintName("fk_variedades_tamano_grano");


            builder.Property(v => v.PorteId)
            .HasColumnName("porte_id"); // quítalo si dejaste 'PorteId'
            

            builder.HasOne(v => v.Porte)
                .WithMany()
                .HasForeignKey(v => v.PorteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_porte");


            builder.Property(v => v.EnfermedadId)
                .HasColumnName("enfermedad_id");

            builder.HasOne(v => v.Enfermedad)
                .WithMany()
                .HasForeignKey(v => v.EnfermedadId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_enfermedad");


            builder.Property(v => v.ResistenciaNivelId)
                .HasColumnName("resistencia_nivel_id");
                

            builder.HasOne(v => v.ResistenciaNivel)
                .WithMany()
                .HasForeignKey(v => v.ResistenciaNivelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_resistencia_nivel");


            builder.Property(v => v.TiempoCosechaId)
                .HasColumnName("tiempo_cosecha_id");
                

            builder.HasOne(v => v.TiempoCosecha)
                .WithMany()
                .HasForeignKey(v => v.TiempoCosechaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_tiempo_cosecha");



            builder.Property(v => v.CalidadGranoId)
                .HasColumnName("calidad_grano_id");
                

            builder.HasOne(v => v.CalidadGrano)
                .WithMany()
                .HasForeignKey(v => v.CalidadGranoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_calidad_grano");



            builder.Property(v => v.PotencialId)
                .HasColumnName("potencial_id");
                

            builder.HasOne(v => v.Potencial)
                .WithMany()
                .HasForeignKey(v => v.PotencialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_potencial");




            builder.Property(v => v.ResistenciaId)
                .HasColumnName("resistencia_id");
           


            builder.HasOne(v => v.Resistencia)
                .WithMany()
                .HasForeignKey(v => v.ResistenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_resistencia");


            builder.Property(v => v.NombreCientificoId)
                .HasColumnName("nombre_cientifico_id");
               

            builder.HasOne(v => v.NombreCientifico)
                .WithMany()
                .HasForeignKey(v => v.NombreCientificoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_nombre_cientifico");



            builder.Property(v => v.AltitudOptimaId)
                .HasColumnName("altitud_optima_id");

            builder.HasOne(v => v.AltitudOptima)
                .WithMany()
                .HasForeignKey(v => v.AltitudOptimaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_altitud_optima");



            builder.Property(v => v.MaduracionId)
                .HasColumnName("maduracion_id");

            builder.HasOne(v => v.Maduracion)
                .WithMany()
                .HasForeignKey(v => v.MaduracionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_maduracion");




            builder.Property(v => v.OrigenLinajeId)
                .HasColumnName("origen_linaje_id");

            builder.HasOne(v => v.OrigenLinaje)
                .WithMany()
                .HasForeignKey(v => v.OrigenLinajeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_variedades_origen_linaje");

            

        }
                

    }
}
