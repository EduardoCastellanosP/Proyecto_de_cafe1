using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class AltitudOptimaConfiguration : IEntityTypeConfiguration<AltitudOptima>
    {
        public void Configure(EntityTypeBuilder<AltitudOptima> builder)
        {
            builder.ToTable("Altitud_Optima");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(a => a.Nombre)
                .IsUnique();

            
        }
    }
}