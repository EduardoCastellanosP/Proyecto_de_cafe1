using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class ResistenciaNivelConfiguration : IEntityTypeConfiguration<ResistenciaNivel>
    {
        public void Configure(EntityTypeBuilder<ResistenciaNivel> builder)
        {
            builder.ToTable("Resistencia_Nivel");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(r => r.Nombre)
                .IsUnique();
        }
    }
}