using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoC_.src.Modules.Variedades.Application.Interfaces;
using proyectoC_.src.Modules.Variedades.Domain.Entities;
using proyectoC_.src.Shared.Context;

namespace proyectoC_.src.Modules.Variedades.Infrastructure.Repositories
{
    public class VariedadRepository : IVariedadRepository
    {
        private readonly AppDbContext _context;

        public VariedadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Variedad?>> GetAllAsync()
        {
            return await _context.Variedades.AsNoTracking()
            .ToListAsync();

        }

        public async Task<Variedad?> GetByIdAsync(int id)
        {
            return await _context.Variedades
                .AsNoTracking()
                 .Include(v => v.NombreCientifico)
                .Include(v => v.Porte)
                .Include(v => v.TamanoGrano)
                .Include(v => v.AltitudOptima)
                .Include(v => v.Potencial)
                .Include(v => v.CalidadGrano)
                .Include(v => v.Resistencia)
                .Include(v => v.TiempoCosecha)
                .Include(v => v.Maduracion)
                .Include(v => v.OrigenLinaje)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Variedad?> GetByNombreAsync(string nombre)
        {
            var n = (nombre ?? string.Empty).Trim();
            return await _context.Variedades
                .FirstOrDefaultAsync(v => v.Nombre == n);
        }

        public async Task<bool> ExistsByNombreAsync(string nombre)
        {
            var n = (nombre ?? string.Empty).Trim();
            return await _context.Variedades.AnyAsync(v => v.Nombre == n);
        }

        public void Add(Variedad entity) =>
            _context.Variedades.Add(entity);

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();

        public void Remove(Variedad entity) =>
            _context.Variedades.Remove(entity);

        public void Update(Variedad entity) =>
            _context.SaveChanges();

        public async Task<Variedad?> ObtenerVariedadPorNombreAsync(string nombre)
        {
            return await _context.Variedades
                .FirstOrDefaultAsync(v => v.Nombre == nombre);

        }

        public async Task<List<Variedad>> GetAllByNombreAsync()
        {
            return await _context.Variedades
                .AsNoTracking()
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByTamanoAsync(string nombreTamano)
        {
            var n = (nombreTamano ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.TamanoGrano)
                .Where(v => v.TamanoGrano.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByPorteAsync(string nombrePorte)
        {
            var n = (nombrePorte ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.Porte)
                .Where(v => v.Porte.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByResistenciaAsync(string nombreResistencia)
        {
            var n = (nombreResistencia ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.Resistencia)
                .Where(v => v.Resistencia.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByTiempoCosechaAsync(string tiempoCosecha)
        {
            var n = (tiempoCosecha ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.TiempoCosecha)
                .Where(v => v.TiempoCosecha.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByPotencialAsync(string nombrePotencial)
        {
            var n = (nombrePotencial ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.Potencial)
                .Where(v => v.Potencial.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByCalidadGranoAsync(string nombreCalidad)
        {
            var n = (nombreCalidad ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.CalidadGrano)
                .Where(v => v.CalidadGrano.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();

        }

        public async Task<List<Variedad>> GetByNombreCientificoAsync(string nombreCientifico)
        {
            var n = (nombreCientifico ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.NombreCientifico)
                .Where(v => v.NombreCientifico.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByOrigenLinajeAsync(string origenLinaje)
        {
            var n = (origenLinaje ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.OrigenLinaje)
                .Where(v => v.OrigenLinaje.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByAltitudOptimaAsync(string altitudOptima)
        {
            var n = (altitudOptima ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.AltitudOptima)
                .Where(v => v.AltitudOptima.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }

        public async Task<List<Variedad>> GetByMaduracionAsync(string nombreMaduracion)
        {
            var n = (nombreMaduracion ?? string.Empty).Trim();

            return await _context.Variedades
                .AsNoTracking()
                .Include(v => v.Maduracion)
                .Where(v => v.Maduracion.Nombre == n)
                .OrderBy(v => v.Nombre)
                .ToListAsync();
        }
    }
}