using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class ResistenciaConfiguration : IEntityTypeConfiguration<Resistencia>
    {
        public void Configure(EntityTypeBuilder<Resistencia> builder)
        {
            builder.ToTable("resistencia");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Nombre).IsUnique();
        }
    }
}