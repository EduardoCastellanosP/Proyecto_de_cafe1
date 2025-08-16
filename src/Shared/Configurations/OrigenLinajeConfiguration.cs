using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class OrigenLinajeConfiguracion : IEntityTypeConfiguration<OrigenLinaje>
    {
        public void Configure(EntityTypeBuilder<OrigenLinaje> builder)
        {
            builder.ToTable("Origen_Linaje");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(o => o.Nombre)
                .IsUnique();
        }
    }
}