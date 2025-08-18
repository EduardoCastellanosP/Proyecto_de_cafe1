using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; // para Path.Combine y FileStream
using iTextSharp.text;
using iTextSharp.text.pdf;
using proyectoC_.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace proyectoC_.src.Modules.Pdf.Resources
{
    public static class Colombia
    {
        public static async Task GenerarAsync(AppDbContext context)
        {
            var colombia = await context.Variedades
                .Include(v => v.TamanoGrano)
                .Include(v => v.Porte)
                .Include(v => v.ResistenciaNivel)
                .Include(v => v.TiempoCosecha)
                .Include(v => v.Potencial)
                .Include(v => v.CalidadGrano)
                .FirstOrDefaultAsync(v => v.Nombre == "Colombia");

            if (colombia == null)
            {
                Console.WriteLine("❌ No se encontró Colombia en la BD.");
                return;
            }

            string rutaArchivo = "Colombia.pdf";
            GenerarPdf(colombia.Nombre, rutaArchivo, colombia);
        }

        private static void GenerarPdf(string nombreVariedad, string rutaArchivo, dynamic variedad)
        {
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(documento, fs);
                documento.Open();

                BaseColor verde = new BaseColor(34, 139, 34);
                BaseColor grisClaro = new BaseColor(240, 240, 240);
                var tituloFuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30, verde);
                var labelFuente  = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
                var valorFuente  = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

                documento.Add(new Paragraph("\n"));
                documento.Add(new Paragraph(variedad.Nombre, tituloFuente));
                documento.Add(new Paragraph($"Coffea arabica var. {variedad.Nombre}.", valorFuente));
                documento.Add(new Paragraph("\n"));

                // Imagen DESPUÉS del título (desde carpeta 'Imagenes' en la raíz del proyecto)
                string rutaImagen = Path.Combine("Imagenes", nombreVariedad.ToLower() + ".png");
                if (File.Exists(rutaImagen))
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(rutaImagen);
                    img.ScaleToFit(500, 200);
                    img.Alignment = Element.ALIGN_CENTER;
                    documento.Add(img);
                }

                PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 2, 3 });

                void Celda(string texto, Font fuente, BaseColor fondo)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(texto, fuente))
                    {
                        BackgroundColor = fondo,
                        Padding = 5,
                        BorderColor = BaseColor.LIGHT_GRAY
                    };
                    tabla.AddCell(celda);
                }

                documento.Add(new Paragraph("\n"));

                Celda("Potencial", labelFuente, grisClaro);
                Celda(variedad.Potencial?.Nombre ?? "-", valorFuente, BaseColor.WHITE);
                Celda("Porte", labelFuente, grisClaro);
                Celda(variedad.Porte?.Nombre ?? "-", valorFuente, BaseColor.WHITE);
                Celda("Tamaño de grano", labelFuente, grisClaro);
                Celda(variedad.TamanoGrano?.Nombre ?? "-", valorFuente, BaseColor.WHITE);
                Celda("Tiempo de cosecha", labelFuente, grisClaro);
                Celda(variedad.TiempoCosecha?.Nombre ?? "-", valorFuente, BaseColor.WHITE);
                Celda("Calidad de grano", labelFuente, grisClaro);
                Celda(variedad.CalidadGrano?.Nombre ?? "-", valorFuente, BaseColor.WHITE);
                Celda("Resistencia", labelFuente, grisClaro);
                Celda(variedad.ResistenciaNivel?.Nombre ?? "-", valorFuente, BaseColor.WHITE);

                documento.Add(tabla);
                documento.Close();
            }

            Console.WriteLine($"✅ PDF creado: {Path.GetFullPath(rutaArchivo)}");
        }
    }
}
