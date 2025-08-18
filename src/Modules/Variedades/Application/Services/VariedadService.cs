using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Variedades.Application.Interfaces;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Modules.Variedades.Application.Services
{
    public class VariedadService : IVariedadService
    {
        private readonly IVariedadRepository _repo;

        public VariedadService(IVariedadRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Variedad>> ConsultarVariedadAsync()
        {
            return await _repo.GetAllAsync();
        }


        public async Task<Variedad?> GetVariedadPorIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }


        public async Task RegistrarVariedadAsync(string nombre)
        {


            if (await _repo.ExistsByNombreAsync(nombre))
                throw new Exception("La variedad ya existe.");
            var variedad = new Variedad
            {
                Nombre = nombre

            };

            _repo.Add(variedad);
            await _repo.SaveAsync();
        }


        public async Task<IEnumerable<Variedad>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<Variedad?>> GetByNombreAsync(string nombre)
        {
            var n = (nombre ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad?>(); 
            return await _repo.GetAllByNombreAsync();
        }

        public async Task<List<Variedad>> GetByTamanoAsync(string nombreTamano)
        {
            
            var n = (nombreTamano ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

           
            return await _repo.GetByTamanoAsync(n);
        }

        public async Task<List<Variedad>> GetByPorteAsync(string nombrePorte)
        {
           
            var n = (nombrePorte ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

           
            return await _repo.GetByPorteAsync(n);
        }


        public async Task<List<Variedad>> GetByResistenciaAsync(string nombreResistencia)
        {
            
            var n = (nombreResistencia ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

           
            return await _repo.GetByResistenciaAsync(n);
        }


        public async Task<List<Variedad>> GetByTiempoCosechaAsync(string tiempoCosecha)
        {
            
            var n = (tiempoCosecha ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

            
            return await _repo.GetByTiempoCosechaAsync(n);
        }

        public async Task<List<Variedad>> GetByPotencialAsync(string potencial)
        {
          
            var n = (potencial ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

           
            return await _repo.GetByPotencialAsync(n);
        }

        public async Task<List<Variedad>> GetByCalidadGranoAsync(string calidad)
        {
            
            var n = (calidad ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 


            return await _repo.GetByCalidadGranoAsync(n);

        }

        public async Task<List<Variedad>> GetByNombreCientificoAsync(string nombreCientifico)
        {
          
            var n = (nombreCientifico ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

            
            return await _repo.GetByNombreCientificoAsync(n);
        }

        public async Task<List<Variedad>> GetByOrigenLinajeAsync(string origenLinaje)
        {
           
            var n = (origenLinaje ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); 

            
            return await _repo.GetByOrigenLinajeAsync(n);
        }

        public async Task<List<Variedad>> GetByAltitudOptimaAsync(string altitudOptima)
        {
           
            var n = (altitudOptima ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad>(); // si no pasan altitud óptima, no devolvemos nada
            return await _repo.GetByAltitudOptimaAsync(n);
        }

        public async Task<Variedad?> ObtenerVariedadPorNombreAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            return await _repo.GetByNombreAsync(nombre);
        }

        Task<Variedad?> IVariedadService.GetVariedadPorIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public async Task<List<Variedad?>> GetVariedadAsync(int id)
        {
            var variedad = await _repo.GetByIdAsync(id);
            return variedad != null ? new List<Variedad?> { variedad } : new List<Variedad?>();
        }

        public async Task<List<Variedad?>> GetByMaduracionAsync(string nombreMaduracion)
        {
            var n = (nombreMaduracion ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(n))
                return new List<Variedad?>();

            return await _repo.GetByMaduracionAsync(n);
        }
    }
}
    
