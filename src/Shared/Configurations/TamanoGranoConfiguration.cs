using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class TamanoGranoConfiguration : IEntityTypeConfiguration<TamanoGrano>
    {
        public void Configure(EntityTypeBuilder<TamanoGrano> builder)
        {
            // Tabla y clave primaria
            builder.ToTable("tamanogranos");
            builder.HasKey(tg => tg.Id);

            // Propiedades
            builder.Property(tg => tg.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            // Índices (opcional)
            builder.HasIndex(tg => tg.Nombre).IsUnique();
        }
    }
}