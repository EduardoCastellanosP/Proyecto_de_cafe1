using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Modules.Variedades.Application.Interfaces
{
    public interface IVariedadService
    {
        Task RegistrarVariedadAsync(string nombre);
        Task<IEnumerable<Variedad?>> ConsultarVariedadAsync();
        Task<Variedad?> ObtenerVariedadPorNombreAsync(string nombre);

        Task<List<Variedad?>> GetByTamanoAsync(string nombreTamano);
        Task<Variedad?> GetVariedadPorIdAsync(int id);
        Task<List<Variedad?>> GetByNombreAsync(string nombre);
        Task<List<Variedad?>> GetVariedadAsync(int id);

        Task<List<Variedad>> GetByPorteAsync(string nombrePorte);

        Task<List<Variedad>> GetByResistenciaAsync(string nombreResistencia);
        Task<List<Variedad>> GetByTiempoCosechaAsync(string tiempoCosecha);
        Task<List<Variedad>> GetByPotencialAsync(string nombrePotencial);
        Task<List<Variedad>> GetByCalidadGranoAsync(string nombreCalidad);
        Task<List<Variedad>> GetByNombreCientificoAsync(string nombreCientifico);
        Task<List<Variedad>> GetByOrigenLinajeAsync(string origenLinaje);
        Task<List<Variedad>> GetByAltitudOptimaAsync(string altitudOptima);
        Task<IEnumerable<Variedad>> GetAllAsync();

        Task<List<Variedad>> GetByMaduracionAsync(string nombreMaduracion);
    }
}