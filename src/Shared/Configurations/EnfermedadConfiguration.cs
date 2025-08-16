using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Configurations
{
    public class EnfermedadConfiguration : IEntityTypeConfiguration<Enfermedad>
    {
        public void Configure(EntityTypeBuilder<Enfermedad> builder)
        {
            builder.ToTable("enfermedad");  
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nombre)
                   .HasMaxLength(120)
                   .IsRequired();
            builder.HasIndex(e => e.Nombre).IsUnique();
        }
    }
}