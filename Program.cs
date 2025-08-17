using proyectoC_.src.Modules.Variedades.UI;
using proyectoC_.src.Modules.Usuarios.UI;
using proyectoC_.src.Shared.Helpers;
using proyectoC_.src.Modules.Admin.UI;
using proyectoC_.src.Modules.Pdf.UI;

var context = DbContextFactory.Create();

bool salir = false;
while (!salir)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╔════════════════════════════════════════════╗");
    Console.WriteLine("║        ☕  Colombian Coffee  ☕            ║");
    Console.WriteLine("║            Menú Principal                  ║");
    Console.WriteLine("╠════════════════════════════════════════════╣");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("║ 1. 🔑 Login                                ║");
    Console.WriteLine("║ 2. 🌱 Explorar variedades                  ║");
    Console.WriteLine("║ 3. 🛠 Panel Admin                           ║");
    Console.WriteLine("║ 4. 📄 Generar PDF                          ║");
    Console.WriteLine("║ 5. 🚪 Salir                                ║");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("╚════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.Write("Seleccione una opción: ");

    var input = Console.ReadLine();
    if (!int.TryParse(input, out int opm))
    {
        Console.WriteLine("❗ Opción inválida.");
        Console.ReadKey();
        continue;
    }

    switch (opm)
    {
        case 1: // Login
        {
            var menuUsuarios = new MenuUsuarios(context);
            await menuUsuarios.RenderMenu(); 
            break;
        }

        case 2: 
             Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("║                🔒  A C C E S O  🔒             ║");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("║   Debe iniciar sesión para acceder a           ║");
            Console.WriteLine("║   las 🌱 V A R I E D A D E S 🌱 de café.       ║");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ReadKey();
            {
                if (!Sesion.UsuarioLogueado)
                {
                    Console.Clear();
                    Console.WriteLine("╔══════════════════════════════════════════════════╗");
                    Console.WriteLine("║                                                  ║");
                    Console.WriteLine("║   ⚠  Debes iniciar sesión antes de acceder a     ║");
                    Console.WriteLine("║      las 🌱 V A R I E D A D E S 🌱 de café.      ║");
                    Console.WriteLine("║                                                  ║");
                    Console.WriteLine("╚══════════════════════════════════════════════════╝");
                    var menuUsuarios = new MenuUsuarios(context);
                    await menuUsuarios.RenderMenu();

                    if (!Sesion.UsuarioLogueado)
                    {
                        Console.Clear();
                        Console.WriteLine("╔════════════════════════════════════════════════╗");
                        Console.WriteLine("║                                                ║");
                        Console.WriteLine("║   ❌  No se inició sesión.  A C C E S O  🚫    ║");
                        Console.WriteLine("║                  D E N E G A D O               ║");
                        Console.WriteLine("║                                                ║");
                        Console.WriteLine("╚════════════════════════════════════════════════╝");
                        Console.ReadKey();
                        break;
                    }
                }

                await new MenuVariedades(context).RenderMenu();
                break;
            }

        case 3: 
        
            await new MenuAdmin(context).RenderMenuAsync();

           
            Console.ReadKey();
            break;
        

        case 4: // Generar PDF (si quieres también exige login)
            var menuPdf = new MenuPdf(context);
            await menuPdf.MostrarMenuPdfAsync();
            break;
        

        case 5: // Salir
            salir = true;
            break;

        default:
            Console.WriteLine("❗ Opción inválida.");
            Console.ReadKey();
            break;
    }
}

// Estado de sesión súper simple
public static class Sesion
{
    public static bool UsuarioLogueado { get; set; } = false;
}
