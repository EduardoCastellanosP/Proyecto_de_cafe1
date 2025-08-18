using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyectoC_.src.Shared.Context;
using proyectoC_.src.Modules.Variedades.Domain.Entities;

namespace proyectoC_.src.Modules.Admin.UI
{
    public class MenuAdmin
    {
        private readonly AppDbContext _ctx;

        private const string ADMIN_PASSWORD = "admin123";

        public MenuAdmin(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task RenderMenuAsync()
        {
            if (!PedirClaveAdmin()) return;

            bool volver = false;
            while (!volver)
            {
                Console.Clear();

                int width = 42; // ancho del marco
                string line(char left, char fill, char right)
                    => left + new string(fill, width - 2) + right;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(line('╔', '═', '╗'));
                Console.WriteLine("║" + "           🛠 PANEL ADMIN           ".PadRight(width - 1) +  "║");
                Console.WriteLine(line('╠', '═', '╣'));
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("║  1. ➕ Añadir variedad de café         ║");
                Console.WriteLine("║  2. 🗑 Eliminar variedad de café        ║");
                Console.WriteLine("║  0. ↩ Volver                           ║"); 
                Console.ResetColor();

                Console.WriteLine(line('╚', '═', '╝'));
                Console.Write("Seleccione una opción: ");

                var op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        await CrearVariedadAsync();
                        break;
                    case "2":
                        await EliminarVariedadAsync();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Pausa();
                        break;
                }
            }
        }

        private bool PedirClaveAdmin()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           🔐  Acceso de Administrador      ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║  Ingrese la contraseña del administrador   ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            var pass = Console.ReadLine();
            if (pass != ADMIN_PASSWORD)
            {
                Console.WriteLine("❌ Contraseña incorrecta.");
                Pausa();
                return false;
            }
            Console.WriteLine("✅ Acceso concedido.");
            Pausa();
            return true;
        }

        
        private async Task CrearVariedadAsync()
        {
            Console.Clear();
           Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║       ➕  Añadir variedad de café          ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║  Complete los datos y presione ENTER.      ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            // Nombre (único)
            Console.Write("Nombre de la variedad: ");
            var nombre = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ El nombre es obligatorio.");
                Pausa();
                return;
            }

            var existe = await _ctx.Variedades.AsNoTracking().AnyAsync(v => v.Nombre == nombre);
            if (existe)
            {
                Console.WriteLine("❌ Ya existe una variedad con ese nombre.");
                Pausa();
                return;
            }

          
            var tamanoGranoId = await ElegirIdObligatorioAsync<TamanoGrano>("TAMAÑOS DE GRANO");
            var porteId = await ElegirIdObligatorioAsync<Porte>("PORTE");
            var enfermedadId = await ElegirIdObligatorioAsync<Enfermedad>("ENFERMEDAD");
            var resistenciaNivelId = await ElegirIdObligatorioAsync<ResistenciaNivel>("NIVEL DE RESISTENCIA");
            var tiempoCosechaId = await ElegirIdObligatorioAsync<TiempoCosecha>("TIEMPO DE COSECHA");
            var calidadGranoId = await ElegirIdObligatorioAsync<CalidadGrano>("CALIDAD DE GRANO");
            var potencialId = await ElegirIdObligatorioAsync<Potencial>("POTENCIAL");
            var nombreCientId = await ElegirIdObligatorioAsync<NombreCientifico>("NOMBRE CIENTÍFICO");

            if (tamanoGranoId == 0 || porteId == 0 || enfermedadId == 0 || resistenciaNivelId == 0 ||
                tiempoCosechaId == 0 || calidadGranoId == 0 || potencialId == 0 || nombreCientId == 0)
            {
                Console.WriteLine("Operación cancelada.");
                Pausa();
                return;
            }

            var resistenciaId = await ElegirIdOpcionalAsync<Resistencia>("RESISTENCIA (opcional)");
            var altitudOptimaId = await ElegirIdOpcionalAsync<AltitudOptima>("ALTITUD ÓPTIMA (opcional)");
            var maduracionId = await ElegirIdOpcionalAsync<Maduracion>("MADURACIÓN (opcional)");
            var origenLinajeId = await ElegirIdOpcionalAsync<OrigenLinaje>("ORIGEN/LINAJE (opcional)");

            // Crear entidad
            var v = new Variedad
            {
                Nombre = nombre,

                TamanoGranoId = tamanoGranoId,
                PorteId = porteId,
                EnfermedadId = enfermedadId,
                ResistenciaNivelId = resistenciaNivelId,
                TiempoCosechaId = tiempoCosechaId,
                CalidadGranoId = calidadGranoId,
                PotencialId = potencialId,
                NombreCientificoId = nombreCientId,

                ResistenciaId = resistenciaId,
                AltitudOptimaId = altitudOptimaId,
                MaduracionId = maduracionId,
                OrigenLinajeId = origenLinajeId
            };

            _ctx.Variedades.Add(v);
            await _ctx.SaveChangesAsync();

            Console.WriteLine($"✅ Variedad creada con ID {v.Id}");
            Pausa();
        }

        // ===== Helpers muy simples =====

        private async Task<int> ElegirIdObligatorioAsync<T>(string titulo) where T : class
        {
            Console.WriteLine($"\n--- {titulo} ---");
            var lista = await _ctx.Set<T>().AsNoTracking().ToListAsync();
            foreach (var item in lista)
            {
                var id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
                var nombre = (string?)item.GetType().GetProperty("Nombre")?.GetValue(item) ?? id.ToString();
                Console.WriteLine($"{id}. {nombre}");
            }

            Console.Write("Seleccione ID (0 = cancelar): ");
            while (true)
            {
                var s = Console.ReadLine();
                if (int.TryParse(s, out var idSel))
                {
                    if (idSel == 0) return 0;
                    // valida que exista
                    var ok = await _ctx.Set<T>().AnyAsync(e => EF.Property<int>(e, "Id") == idSel);
                    if (ok) return idSel;
                }
                Console.Write("ID inválido. Intente de nuevo: ");
            }
        }

        private async Task<int?> ElegirIdOpcionalAsync<T>(string titulo) where T : class
        {
            Console.WriteLine($"\n--- {titulo} ---");
            var lista = await _ctx.Set<T>().AsNoTracking().ToListAsync();
            foreach (var item in lista)
            {
                var id = (int)item.GetType().GetProperty("Id")!.GetValue(item)!;
                var nombre = (string?)item.GetType().GetProperty("Nombre")?.GetValue(item) ?? id.ToString();
                Console.WriteLine($"{id}. {nombre}");
            }

            Console.Write("Seleccione ID (Enter = ninguno): ");
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) return null;

            if (int.TryParse(s, out var idSel))
            {
                var ok = await _ctx.Set<T>().AnyAsync(e => EF.Property<int>(e, "Id") == idSel);
                if (ok) return idSel;
            }

            Console.WriteLine("Valor inválido. Se dejará vacío.");
            return null;
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        private async Task EliminarVariedadAsync()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║        🗑  Eliminar variedad de café        ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║  Ingrese el ID de la variedad a eliminar.  ║");
            Console.WriteLine("║  Se pedirá confirmación antes de borrar.   ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            Console.Write("Ingrese el ID de la variedad a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ ID inválido.");
                Pausa();
                return;
            }

            var v = await _ctx.Variedades.FindAsync(id);
            if (v == null)
            {
                Console.WriteLine($"❌ No existe una variedad con ID {id}.");
                Pausa();
                return;
            }

            Console.WriteLine($"\nVas a eliminar: ID {v.Id} - {v.Nombre}");
            Console.Write("¿Confirmar? (s/n): ");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (char.ToLowerInvariant(key.KeyChar) != 's')
            {
                Console.WriteLine("Operación cancelada.");
                Pausa();
                return;
            }

            try
            {
                _ctx.Variedades.Remove(v);
                await _ctx.SaveChangesAsync();
                Console.WriteLine("✅ Variedad eliminada correctamente.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("❌ No se pudo eliminar. Es posible que esté referenciada por otros datos.");
                Console.WriteLine($"Detalle: {ex.InnerException?.Message ?? ex.Message}");
            }

            Pausa();
        }
    }
}
