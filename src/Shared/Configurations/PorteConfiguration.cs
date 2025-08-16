using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class PorteConfiguration : IEntityTypeConfiguration<Porte>
    {
        public void Configure(EntityTypeBuilder<Porte> builder)
        {
            // Tabla y clave primaria
            builder.ToTable("porte");
            builder.HasKey(p => p.Id);

            // Propiedades
            builder.Property(p => p.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            // Índices (opcional)
            builder.HasIndex(p => p.Nombre).IsUnique();
        }
    }
}