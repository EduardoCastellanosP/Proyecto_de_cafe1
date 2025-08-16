using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoC_.src.Modules.Usuarios.Domain.Entities;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Shared.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    
    public DbSet<Variedad> Variedades => Set<Variedad>();
    
    public DbSet<TamanoGrano> TamanoGranos => Set<TamanoGrano>();
    public DbSet<Porte> Portes => Set<Porte>();

    public DbSet<ResistenciaNivel> ResistenciasNivel => Set<ResistenciaNivel>();

    public DbSet<TiempoCosecha> TiemposCosecha => Set<TiempoCosecha>();

    public DbSet<CalidadGrano> CalidadesGrano => Set<CalidadGrano>();

    public DbSet<Potencial> Potenciales => Set<Potencial>();


    public DbSet<Enfermedad> Enfermedades => Set<Enfermedad>();

    public DbSet<Resistencia> Resistencias => Set<Resistencia>();

    public DbSet<NombreCientifico> NombresCientificos => Set<NombreCientifico>();

    public DbSet<AltitudOptima> AltitudesOptimas => Set<AltitudOptima>();

    public DbSet<Maduracion> Maduraciones => Set<Maduracion>();

    public DbSet<OrigenLinaje> OrigenesLinaje => Set<OrigenLinaje>();

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}