using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using proyectoC_.src.Shared.Context;
using proyectoC_.src.Modules.Variedades.Application.Interfaces;
using proyectoC_.src.Modules.Variedades.Application.Services;
using proyectoC_.src.Modules.Variedades.Domain.Entities;
using proyectoC_.src.Modules.Variedades.Infrastructure.Repositories;
using proyectoC_.src.Modules.Pdf.UI;

namespace proyectc_.src.Modules.Variedades.UI
{
   
    public class MenuVariedades
    {
        private readonly AppDbContext _context;
        private readonly VariedadRepository _repo = null!;
        private readonly VariedadService _service = null!;

        public MenuVariedades(AppDbContext context)
        {
            _context = context;
            _repo = new VariedadRepository(context);
            _service = new VariedadService(_repo);
            
           
        }

        public async Task RenderMenu()
        {
            bool regresar = false;
            while (!regresar)
            {
                Console.Clear();
                Console.WriteLine("+==================================+");
                Console.WriteLine("|          Menu Variedades         |");
                Console.WriteLine("+==================================+");
                Console.WriteLine("| 1. 🌱 Ver Variedades de cafe     |");
                Console.WriteLine("| 2. 🔍 Filtrar                    |");
                Console.WriteLine("| 3. 📄 Generar PDF                 |");
                Console.WriteLine("| 4. 🔙 Regresar al menú anterior  |");
                Console.WriteLine("+==================================+");
                Console.Write("¿Qué acción desea realizar? ");

                string? opcion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(opcion))
                    continue;

                switch (opcion)
                {
                    case "1":
                        await MostrarAsync(_service);
                        break;

                    case "2":
                        await FiltrarAsync();
                        break;

                    case "3":
                        var menuPdf = new MenuPdf(_context);
                        await menuPdf.MostrarMenuPdfAsync();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Regresando...");
                        Console.ReadKey();
                        regresar = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

       
    private static async Task MostrarAsync(IVariedadService service)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== MENU CAFES ==========");
             Console.WriteLine("1) Ver lista de cafés");
             Console.WriteLine("2) Ver ficha técnica por ID");
             Console.WriteLine("0) Volver / Salir");
            Console.Write("Seleccione una opción: ");
             var op = Console.ReadLine()?.Trim();

            switch (op)
            {
                case "1":
                     await ListarCafesAsync(service);
                     break;

            case "2":
                    await VerFichaPorIdAsync((VariedadService)service);
                    break;

             case "0":
                    return;

                 default:
                     Console.WriteLine("Opción inválida.");
                    Pausa();
                    break;
             }
        }
     }

    private static async Task ListarCafesAsync(IVariedadService service)
    {
        Console.Clear();
        Console.WriteLine("========== CAFES DISPONIBLES ==========\n");

        var todos = (await service.ConsultarVariedadAsync())
            .OrderBy(v => v.Nombre)
            .ToList();

        if (todos.Count == 0)
        {
            Console.WriteLine("No hay variedades registradas.");
            Pausa();
            return;
        }

        Console.WriteLine("ID   Nombre");
        Console.WriteLine("------------------------------");
        foreach (var v in todos)
            Console.WriteLine($"{v.Id,-4} {v.Nombre}");

        Pausa();
    }

   private static async Task VerFichaPorIdAsync(IVariedadService service)
{
    const int WIDTH = 59; // ancho del cuadro (ajústalo si quieres)
    string Top()        => "┌" + new string('─', WIDTH - 2) + "┐";
    string Sep()        => "├" + new string('─', WIDTH - 2) + "┤";
    string Bottom()     => "└" + new string('─', WIDTH - 2) + "┘";
    string Row(string s)
    {
        // sin comillas, recorta y rellena derecha
        s = s ?? "";
        if (s.Length > WIDTH - 4) s = s.Substring(0, WIDTH - 4);
        return "│ " + s.PadRight(WIDTH - 4) + " │";
    }

    Console.Clear();
    Console.Write("Ingrese el ID de la variedad: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido.");
        Pausa();
        return;
    }

    var v = await service.GetVariedadPorIdAsync(id);
    if (v == null)
    {
        Console.WriteLine($"No se encontró una variedad con ID {id}.");
        Pausa();
        return;
    }

    Console.Clear();
    Console.WriteLine(Top());
    Console.WriteLine(Row($"📜 Ficha técnica – Variedad (ID: {v.Id})"));
    Console.WriteLine(Sep());

    Console.WriteLine(Row($"Nombre: {v.Nombre}"));
    Console.WriteLine(Row($"Nombre científico: {v.NombreCientifico?.Nombre ?? "-"}"));
    Console.WriteLine(Sep());

    Console.WriteLine(Row($"Porte: {v.Porte?.Nombre ?? "-"}"));
    Console.WriteLine(Row($"Tamaño de grano: {v.TamanoGrano?.Nombre ?? "-"}"));
    Console.WriteLine(Row($"Altitud óptima: {v.AltitudOptima?.Nombre ?? "-"}"));
    Console.WriteLine(Row($"Rendimiento: {v.Potencial?.Nombre ?? "-"}"));
    Console.WriteLine(Row($"Calidad-altitud: {v.CalidadGrano?.Nombre ?? "-"}"));
    Console.WriteLine(Sep());

    Console.WriteLine(Row($"Resistencias: {v.Resistencia?.Nombre ?? "-"}"));
    Console.WriteLine(Sep());

    Console.WriteLine(Row($"Tiempo de cosecha: {v.TiempoCosecha?.Nombre ?? "-"}"));
    Console.WriteLine(Row($"Maduración: {v.Maduracion?.Nombre ?? "-"}"));
    Console.WriteLine(Sep());

    Console.WriteLine(Row($"Origen/linaje: {v.OrigenLinaje?.Nombre ?? "-"}"));
    Console.WriteLine(Bottom());

    Pausa();
}

    private static void Pausa()
    {
        Console.WriteLine("\nPresiona una tecla para continuar...");
        Console.ReadKey();
    }

        // ====== Opción 2: Filtrar ======
        private async Task FiltrarAsync()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("== Filtros de Variedades ==");
                Console.WriteLine("1. Por nombre (contiene)");
                Console.WriteLine("2. Por Tamaño de grano ");
                Console.WriteLine("3. Por Porte ");
                Console.WriteLine("4. Por Resistencia");
                Console.WriteLine("5. Por Tiempo de Cosecha ");
                Console.WriteLine("6. Por Potencial ");
                Console.WriteLine("7. Por Calidad de Grano ");
                Console.WriteLine("8. Volver");
                Console.Write("Seleccione una opción: ");
                var op = Console.ReadLine();

                var todas = await _service.ConsultarVariedadAsync();
                
                if (todas == null || !todas.Any())
                {
                    Console.WriteLine("No hay variedades para filtrar.");
                    Console.ReadKey();
                    return;
                }

                IEnumerable<Variedad> resultado = Enumerable.Empty<Variedad>();

                switch (op)
                {
                    case "1":


                        var cafes = await _repo.GetAllByNombreAsync();
                        Console.WriteLine("Cafés Disponibles:");
                        foreach (var cafe in cafes)
                        {
                            Console.WriteLine($"- {cafe.Nombre}");
                        }

                        // 3️⃣ Leer entrada del usuario si quieres continuar
                        var texto = Console.ReadLine() ?? string.Empty;

                        break;

                    case "2":

                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR TAMAÑO (Nombre - Tamaño)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese el tamaño de grano (ej. Pequeño, Mediano, Grande): ");
                        var nombreTamano = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades = await _service.GetByTamanoAsync(nombreTamano); // usa tu servicio

                        if (variedades.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para ese tamaño de grano.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Tamaño de grano",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.TamanoGrano?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();


                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR PORTE (Nombre - Porte)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese el porte (ej. Bajo, Medio, Alto): ");
                        var nombrePorte = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades2 = await _service.GetByPorteAsync(nombrePorte);

                        if (variedades2.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para ese porte.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Tamaño de grano",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades2)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.Porte?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR RESISTENCIA (Nombre - Resistencia)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese el nivel de resistencia (ej. Resistente a Plagas, Resistente a Roya, Resistente a Sequía): ");
                        var nombreResistencia = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades3 = await _service.GetByResistenciaAsync(nombreResistencia);

                        if (variedades3.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para ese nivel de resistencia.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Resistencia",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades3)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.Resistencia?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "5":

                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR TIEMPO DE COSECHA (Nombre - Tiempo)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese el tiempo de cosecha (ej. 3 meses, 4 meses, 5 meses, 6 meses, 8 meses): ");
                        var tiempoCosecha = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades4 = await _service.GetByTiempoCosechaAsync(tiempoCosecha);

                        if (variedades4.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para ese tiempo de cosecha.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Resistencia",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades4)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.TiempoCosecha?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR POTENCIAL (Nombre - Potencial)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese el potencial (ej. Alto Rendimiento, Medio Rendimiento, Bajo Rendimiento): ");
                        var nombrePotencial = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades5 = await _service.GetByPotencialAsync(nombrePotencial);

                        if (variedades5.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para ese potencial.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Potencial",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades5)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.Potencial?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "7":

                        Console.Clear();
                        Console.WriteLine("==============================================");
                        Console.WriteLine("   VARIEDADES POR CALIDAD (Nombre - Calidad)    ");
                        Console.WriteLine("==============================================\n");

                        Console.Write("Ingrese la calidad (ej. Excelso, Extra, Premiun, Supremo): ");
                        var nombreCalidad = (Console.ReadLine() ?? string.Empty).Trim();

                        var variedades6 = await _service.GetByCalidadGranoAsync(nombreCalidad);

                        if (variedades6.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo se encontraron variedades para esa calidad.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nResultados:\n");
                            Console.WriteLine($"{"Variedad",-24} {"Potencial",-18}");
                            Console.WriteLine(new string('-', 44));

                            foreach (var v in variedades6)
                            {
                                Console.WriteLine($"{v.Nombre,-24} {v.CalidadGrano?.Nombre ?? "-",-18}");
                            }
                        }

                        Console.WriteLine("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "8":

                        volver = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                        

                }

                Console.Clear();
            }
        }

        
        }
    }

