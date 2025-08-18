using System;
using System.Threading.Tasks;
using proyectoC_.src.Shared.Context;
using proyectoC_.src.Modules.Pdf.Resources;

namespace proyectoC_.src.Modules.Pdf.UI
{
    public class MenuPdf
    {
        private readonly AppDbContext _context;

        public MenuPdf(AppDbContext context)
        {
            _context = context;
        }

        public async Task MostrarMenuPdfAsync()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                Console.WriteLine("║        📄  M E N Ú   P D F — V A R I E D A D E S     ║");
                Console.WriteLine("║                   D E   C A F É                      ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣");
                Console.ResetColor();
                Console.WriteLine("║  1) Typica            ☕                             ║");
                Console.WriteLine("║  2) Bourbon           🫘                              ║");
                Console.WriteLine("║  3) Caturra           🌱                             ║");
                Console.WriteLine("║  4) Colombia          🇨🇴                              ║");
                Console.WriteLine("║  5) Castillo          🌾                              ║");
                Console.WriteLine("║  6) Generar todos los PDFs  🖨️                       ║");
                Console.WriteLine("║  0) Volver            ↩                              ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝");
                Console.Write("👉 Selecciona una opción: ");

                string opcion = Console.ReadLine() ?? "0";

                switch (opcion)
                {
                    case "1":
                        await Typica.GenerarAsync(_context);
                        Pausa();
                        break;
                    case "2":
                        await Bourbon.GenerarAsync(_context);
                        Pausa();
                        break;
                    case "3":
                        await Caturra.GenerarAsync(_context);
                        Pausa();
                        break;
                    case "4":
                        await Colombia.GenerarAsync(_context);
                        Pausa();
                        break;
                    case "5":
                        await Castillo.GenerarAsync(_context);
                        Pausa();
                        break;
                    case "6":
                        await VariedadPdf.GenerarTodasAsync(_context);
                        Pausa();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Pausa();
                        break;
                }
            }
        }

        private void Pausa()
        {
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
