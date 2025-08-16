using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class MaduracionConfiguracion : IEntityTypeConfiguration<Maduracion>
    {
        public void Configure(EntityTypeBuilder<Maduracion> builder)
        {
            builder.ToTable("maduracion");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(m => m.Nombre)
                .IsUnique();

          
        }
    }
}