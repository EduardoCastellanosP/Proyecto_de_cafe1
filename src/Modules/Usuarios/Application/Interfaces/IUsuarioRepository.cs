using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Usuarios.Domain.Entities;

namespace proyectoC_.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        void Add(Usuario entity);
        void Update(Usuario entity);
        void Remove(Usuario entity);
        Task<bool> ExistsByNombreAsync(string nombre);
        Task SaveAsync();
        Task<Usuario?> GetByNombreAsync(string nombre);
    }
}