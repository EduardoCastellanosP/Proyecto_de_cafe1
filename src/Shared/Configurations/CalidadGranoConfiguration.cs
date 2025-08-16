using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class CalidadGranoConfiguration: IEntityTypeConfiguration<CalidadGrano>
    {
        public void Configure(EntityTypeBuilder<CalidadGrano> builder)
        {
            builder.ToTable("Calidad_grano");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.Nombre)
                .IsUnique();
        }
    }
}