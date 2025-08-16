using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Modules.Variedades.Application.Interfaces
{
    public interface IVariedadRepository
    {
        Task<IEnumerable<Variedad>> GetAllAsync();
        Task<Variedad?> GetByIdAsync(int id);
        Task<Variedad?> GetByNombreAsync(string nombre);
        void Add(Variedad entity);
        void Update(Variedad entity);
        void Remove(Variedad entity);
        Task<bool> ExistsByNombreAsync(string nombre);
        Task SaveAsync();

        Task<List<Variedad>> GetAllByNombreAsync();
        Task<List<Variedad>> GetByTamanoAsync(string nombreTamano);

        Task<List<Variedad>> GetByPorteAsync(string nombrePorte);

        Task<List<Variedad>> GetByResistenciaAsync(string nombreResistencia);

        Task<List<Variedad>> GetByTiempoCosechaAsync(string tiempoCosecha);

        Task<List<Variedad>> GetByPotencialAsync(string nombrePotencial);

        Task<List<Variedad>> GetByCalidadGranoAsync(string nombreCalidad);

        Task<List<Variedad>> GetByNombreCientificoAsync(string nombreCientifico);

        Task<List<Variedad>> GetByOrigenLinajeAsync(string origenLinaje);

        Task<List<Variedad>> GetByAltitudOptimaAsync(string altitudOptima);

        Task<List<Variedad>> GetByMaduracionAsync(string nombreMaduracion);
    
    }
}