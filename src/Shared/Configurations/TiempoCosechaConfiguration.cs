using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class TiempoCosechaConfiguration : IEntityTypeConfiguration<TiempoCosecha>
    {
        public void Configure(EntityTypeBuilder<TiempoCosecha> builder)
        {
            builder.ToTable("tiempo_cosecha");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(t => t.Nombre).IsUnique();
        }
    }
}