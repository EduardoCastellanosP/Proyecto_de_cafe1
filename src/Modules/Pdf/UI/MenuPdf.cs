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
                Console.WriteLine("== Menú PDF Variedades de Café ==");
                Console.WriteLine("1. Typica");
                Console.WriteLine("2. Bourbon");
                Console.WriteLine("3. Caturra");
                Console.WriteLine("4. Colombia");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
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
