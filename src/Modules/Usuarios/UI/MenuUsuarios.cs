using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoC_.src.Modules.Variedades.UI;
using proyectoC_.src.Modules.Usuarios.Application.Services;
using proyectoC_.src.Modules.Usuarios.Domain.Entities;
using proyectoC_.src.Modules.Usuarios.Infrastructure.Repositories;
using proyectoC_.src.Shared.Context;


namespace proyectoC_.src.Modules.Usuarios.UI
{
    public class MenuUsuarios
    {
        private readonly AppDbContext _context;
        readonly UsuarioRepository repo = null!;
        readonly UsuarioService service = null!;
        public MenuUsuarios(AppDbContext context)
        {
            _context = context;
            repo = new UsuarioRepository(context);
            service = new UsuarioService(repo);
        }
        public async Task RenderMenu()
        {
            bool regresar = false;
            while (!regresar)
            {
               Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║              👤 M E N Ú  U S U A R I O     ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║  1) 📝 Registrar usuario                   ║");
                Console.WriteLine("║  2) 🔑 Iniciar sesión                      ║");
                Console.WriteLine("║  3) 🔙 Regresar al menú principal          ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write("👉 ¿Qué acción desea realizar?: ");
                string? opcion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(opcion))
                {
                    continue;
                }
                else
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════╗");
                            Console.WriteLine("║            Registrar Usuario               ║");
                            Console.WriteLine("╠════════════════════════════════════════════╣");
                            Console.WriteLine("║        Ingrese el nombre del usuario       ║");
                            Console.WriteLine("║           (letras y / o números):          ║");
                            Console.WriteLine("╚════════════════════════════════════════════╝");
                            string? nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese la contraseña (letras y / o números):");
                            string? clave = Console.ReadLine();

                            
                            await service.RegistrarUsuarioAsync(nombre!, clave!);
                            Console.WriteLine("✅ Usuario registrado con exito.");
                         



                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════╗");
                            Console.WriteLine("║               Iniciar Sesion               ║");
                            Console.WriteLine("╠════════════════════════════════════════════╣");
                            Console.WriteLine("║          Ingrese el nombre del usuario     ║");
                            Console.WriteLine("╚════════════════════════════════════════════╝");
                            string nombre2 = Console.ReadLine()!;

                            if (string.IsNullOrWhiteSpace(nombre2))
                            {
                                Console.WriteLine("⚠️ El nombre de usuario no puede estar vacío.");
                                Console.ReadKey();
                                break;
                            }

                           
                            Usuario? usuario = await service.ObtenerUsuarioPorNombreAsync(nombre2); 
                            
                            

                            if (usuario == null)
                            {
                                Console.WriteLine("❌ Usuario no encontrado.");
                                Console.ReadKey();
                                break;
                            }

                           
                            Console.Write("Ingrese la contraseña: ");
                            string? claveIngresada = Console.ReadLine();

                            
                            if (usuario.Clave == claveIngresada)
                            {
                                Console.WriteLine($"✅ Bienvenido, {usuario.Nombre}.");
                                Sesion.UsuarioLogueado = true;
                                Console.WriteLine("✅ Inicio de sesión exitoso.");
                                await new MenuVariedades(_context).RenderMenu();
                            }
                            else
                            {
                                Console.WriteLine("❌ Contraseña incorrecta.");
                            }

                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Regresando al menú anterior...");
                            Console.ReadKey();
                            regresar = true;
                            break;
                        default:
                            Console.WriteLine("Opción no valida");
                            Console.ReadKey();
                            break;
                    }
                }

            }

        }

    }
}