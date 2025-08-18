using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using proyectoC_.src.Shared.Context;

namespace proyectoC_.src.Modules.Pdf.Resources
{
    public static class VariedadPdf
    {
        public static async Task GenerarPorNombreAsync(AppDbContext context, string nombreVariedad)
        {
            if (string.IsNullOrWhiteSpace(nombreVariedad))
            {
                Console.WriteLine("❌ Debe indicar el nombre de la variedad.");
                return;
            }

            var variedad = await context.Variedades
                .AsNoTracking()
                .Include(v => v.TamanoGrano)
                .Include(v => v.Porte)
                .Include(v => v.ResistenciaNivel)
                .Include(v => v.TiempoCosecha)
                .Include(v => v.Potencial)
                .Include(v => v.CalidadGrano)
                .FirstOrDefaultAsync(v => v.Nombre == nombreVariedad);

            if (variedad == null)
            {
                Console.WriteLine($"❌ No se encontró la variedad '{nombreVariedad}' en la BD.");
                return;
            }

            string nombreArchivo = SanitizarNombreArchivo($"{variedad.Nombre}.pdf");
            GenerarPdfVariedad(nombreArchivo, variedad);
        }

        public static async Task GenerarTodasAsync(AppDbContext context)
        {
            var variedades = await context.Variedades
                .AsNoTracking()
                .Include(v => v.TamanoGrano)
                .Include(v => v.Porte)
                .Include(v => v.ResistenciaNivel)
                .Include(v => v.TiempoCosecha)
                .Include(v => v.Potencial)
                .Include(v => v.CalidadGrano)
                .OrderBy(v => v.Nombre)
                .ToListAsync();

            if (variedades.Count == 0)
            {
                Console.WriteLine("⚠ No hay variedades en la base de datos.");
                return;
            }

            int ok = 0, fail = 0;
            foreach (var v in variedades)
            {
                try
                {
                    string nombreArchivo = SanitizarNombreArchivo($"{v.Nombre}.pdf");
                    GenerarPdfVariedad(nombreArchivo, v);
                    ok++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error generando PDF de {v.Nombre}: {ex.Message}");
                    fail++;
                }
            }

            Console.WriteLine($"\n✅ PDFs generados: {ok}. ❌ Fallidos: {fail}.");
            Console.WriteLine($"📂 Carpeta de salida: {Environment.CurrentDirectory}");
        }

        private static string SanitizarNombreArchivo(string nombre)
        {
            var invalid = Path.GetInvalidFileNameChars();
            var limpio = string.Join("_", nombre.Split(invalid, StringSplitOptions.RemoveEmptyEntries)).Trim();
            return string.IsNullOrWhiteSpace(limpio) ? "salida.pdf" : limpio;
        }

        private static void GenerarPdfVariedad(string rutaArchivo, dynamic variedad)
        {
            var margen = 40f;
            using var fs = new FileStream(rutaArchivo, FileMode.Create);
            using var documento = new Document(PageSize.A4, margen, margen, margen, margen);
            PdfWriter.GetInstance(documento, fs);
            documento.Open();

            var verde       = new BaseColor(34, 139, 34);
            var grisClaro   = new BaseColor(240, 240, 240);
            var blanco      = new BaseColor(255, 255, 255);
            var negro       = new BaseColor(0, 0, 0);
            var grisBorde   = new BaseColor(200, 200, 200);

            var tituloFuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 28, verde);
            var labelFuente  = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, negro);
            var valorFuente  = FontFactory.GetFont(FontFactory.HELVETICA, 11, negro);

            documento.Add(new Paragraph((string)variedad.Nombre, tituloFuente));
            documento.Add(new Paragraph($"Coffea arabica var. {variedad.Nombre}.", valorFuente));
            documento.Add(new Paragraph("\n"));

            // === CARGA DE IMAGEN DESDE ./Imagenes/{nombre}.png ===
            var rutaImagen = Path.Combine("Imagenes", ((string)variedad.Nombre).ToLower() + ".png");
            if (File.Exists(rutaImagen))
            {
                var img = iTextSharp.text.Image.GetInstance(rutaImagen);
                img.ScaleToFit(500, 200);
                img.Alignment = Element.ALIGN_CENTER;
                documento.Add(img);
                documento.Add(new Paragraph("\n"));
            }

            var tabla = new PdfPTable(2) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 2, 3 });

            void Celda(string texto, Font fuente, BaseColor fondo)
            {
                var celda = new PdfPCell(new Phrase(texto ?? "-", fuente))
                {
                    BackgroundColor = fondo,
                    Padding = 6f,
                    BorderColor = grisBorde
                };
                tabla.AddCell(celda);
            }

            Celda("Potencial", labelFuente, grisClaro);
            Celda(variedad.Potencial?.Nombre, valorFuente, blanco);

            Celda("Porte", labelFuente, grisClaro);
            Celda(variedad.Porte?.Nombre, valorFuente, blanco);

            Celda("Tamaño de grano", labelFuente, grisClaro);
            Celda(variedad.TamanoGrano?.Nombre, valorFuente, blanco);

            Celda("Tiempo de cosecha", labelFuente, grisClaro);
            Celda(variedad.TiempoCosecha?.Nombre, valorFuente, blanco);

            Celda("Calidad de grano", labelFuente, grisClaro);
            Celda(variedad.CalidadGrano?.Nombre, valorFuente, blanco);

            Celda("Resistencia", labelFuente, grisClaro);
            Celda(variedad.ResistenciaNivel?.Nombre, valorFuente, blanco);

            documento.Add(tabla);
            documento.Close();

            Console.WriteLine($"✅ PDF creado: {Path.GetFullPath(rutaArchivo)}");
        }
    }
}
