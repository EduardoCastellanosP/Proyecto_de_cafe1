using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class PotencialConfiguration : IEntityTypeConfiguration<Potencial>
    {
        public void Configure(EntityTypeBuilder<Potencial> builder)
        {
            builder.ToTable("potencial");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.Nombre).IsUnique();
        }
    }
}