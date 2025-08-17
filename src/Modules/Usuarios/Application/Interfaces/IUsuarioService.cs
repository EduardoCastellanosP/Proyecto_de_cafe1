using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Usuarios.Domain.Entities;

namespace proyectoC_.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task RegistrarUsuarioAsync(string nombre, string clave);
        Task<IEnumerable<Usuario>> ConsultarUsuariosAsync();
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string nombre);  
    }
}