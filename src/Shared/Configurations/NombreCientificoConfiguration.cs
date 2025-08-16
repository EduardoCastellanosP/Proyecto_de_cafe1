using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class NombreCientificoConfiguration : IEntityTypeConfiguration<NombreCientifico>
    {
        public void Configure(EntityTypeBuilder<NombreCientifico> builder)
        {
            builder.ToTable("nombre_cientifico");
            builder.HasKey(nc => nc.Id);

            builder.Property(nc => nc.Nombre)
            .IsRequired()
            .HasMaxLength(120);

            builder.HasIndex(nc => nc.Nombre)
                   .IsUnique();
        }
    }
}