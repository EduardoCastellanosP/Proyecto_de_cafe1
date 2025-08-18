using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw; // ← separadores de línea
using proyectoC_.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace proyectoC_.src.Modules.Pdf.Resources
{
    public static class Typica
    {
        public static async Task GenerarAsync(AppDbContext context)
        {
            var typica = await context.Variedades
                .Include(v => v.TamanoGrano)
                .Include(v => v.Porte)
                .Include(v => v.ResistenciaNivel)
                .Include(v => v.TiempoCosecha)
                .Include(v => v.Potencial)
                .Include(v => v.CalidadGrano)
                .FirstOrDefaultAsync(v => v.Nombre == "Typica");

            if (typica == null)
            {
                Console.WriteLine("❌ No se encontró Typica en la BD.");
                return;
            }

            string rutaArchivo = "Typica_cafe.pdf";
            GenerarPdf(typica.Nombre, rutaArchivo, typica);
        }

        private static void GenerarPdf(string nombreVariedad, string rutaArchivo, dynamic variedad)
        {
            Document documento = new Document(PageSize.A4, 40, 40, 40, 40);
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                PdfWriter.GetInstance(documento, fs);
                documento.AddTitle($"{variedad.Nombre} - Ficha técnica");
                documento.AddAuthor("Proyecto Café");
                documento.AddSubject("Ficha técnica de variedad de café");
                documento.Open();

                // Paleta
                BaseColor acento     = new BaseColor(0, 121, 107);   // teal
                BaseColor grisClaro  = new BaseColor(245, 245, 245); // fondo etiquetas
                BaseColor grisBorde  = new BaseColor(220, 220, 220);

                // Fuentes
                var tituloBlanco   = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 28, BaseColor.WHITE);
                var subtituloBlanc = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.WHITE);
                var labelFuente    = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
                var valorFuente    = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                var pieFuente      = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9, BaseColor.GRAY);

                // Encabezado tipo "hero"
                PdfPTable hero = new PdfPTable(1) { WidthPercentage = 100 };
                var c1 = new PdfPCell(new Phrase(variedad.Nombre, tituloBlanco))
                {
                    BackgroundColor = acento,
                    PaddingTop = 14f,
                    PaddingBottom = 8f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                var c2 = new PdfPCell(new Phrase($"Coffea arabica var. {variedad.Nombre}.", subtituloBlanc))
                {
                    BackgroundColor = acento,
                    PaddingBottom = 12f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER
                };
                hero.AddCell(c1);
                hero.AddCell(c2);
                documento.Add(hero);
                documento.Add(new Paragraph("\n"));

                // Imagen desde carpeta 'Imagenes' (raíz del proyecto en runtime)
                string rutaImagen = Path.Combine("Imagenes", nombreVariedad.ToLower() + ".png");
                if (File.Exists(rutaImagen))
                {
                    var img = iTextSharp.text.Image.GetInstance(rutaImagen);
                    img.ScaleToFit(500, 220);
                    img.Alignment = Element.ALIGN_CENTER;
                    documento.Add(img);
                    documento.Add(new Paragraph("\n"));
                }

                // Separador fino
                var linea = new LineSeparator(0.8f, 100f, grisBorde, Element.ALIGN_CENTER, -2);
                documento.Add(new Chunk(linea));
                documento.Add(new Paragraph("\n"));

                // Tabla de atributos con cabecera
                PdfPTable tabla = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 5f, SpacingAfter = 10f };
                tabla.SetWidths(new float[] { 2.2f, 3f });

                var cabecera = new PdfPCell(new Phrase("Ficha técnica", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE)))
                {
                    BackgroundColor = acento,
                    Padding = 6f,
                    Colspan = 2,
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                tabla.AddCell(cabecera);

                void Celda(string texto, Font fuente, BaseColor fondo, int align = Element.ALIGN_LEFT)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(texto, fuente))
                    {
                        BackgroundColor = fondo,
                        PaddingTop = 7f,
                        PaddingBottom = 7f,
                        PaddingLeft = 8f,
                        PaddingRight = 8f,
                        BorderColor = grisBorde,
                        BorderWidth = 0.5f,
                        HorizontalAlignment = align
                    };
                    tabla.AddCell(celda);
                }

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

                // Pie de página simple
                var pie = new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", pieFuente)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                documento.Add(pie);

                documento.Close();
            }

            Console.WriteLine($"✅ PDF creado: {Path.GetFullPath(rutaArchivo)}");
        }
    }
}
