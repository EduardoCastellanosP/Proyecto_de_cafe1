using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoC_.src.Modules.Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace proyectoC_.src.Shared.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Clave).IsRequired().HasMaxLength(200);


        builder.HasIndex(x => x.Nombre).IsUnique();
    }
    }
}