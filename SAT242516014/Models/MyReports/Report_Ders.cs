using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MyReports;

// 1. Ders Modeli (Rapor için gerekli alanlar)
public class Ders
{
    public int Id { get; set; }
    public string Kod { get; set; }
    public string Ad { get; set; }
    public int Kredi { get; set; }
    public string SinifAdi { get; set; } // Hangi sınıfa ait olduğu
}

public class Report_Ders
{
    // Hücre stili (Student raporundaki ile aynı)
    static IContainer CellStyle(IContainer container) =>
        container
            .Padding(5)
            .BorderBottom(1)
            .BorderColor(Colors.Grey.Lighten2);

    public byte[] Generate(List<Ders> dersler)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        // Logo yolu (Dosyanın var olduğundan emin olun)
        var imagePath = "wwwroot/logo_siyah.png";
        byte[] imageData = null;

        try
        {
            if (File.Exists(imagePath))
                imageData = File.ReadAllBytes(imagePath);
        }
        catch
        {
            // Resim bulunamazsa hata vermesin, boş geçsin diye try-catch
            imageData = Placeholders.Image(100, 50);
        }

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);

                // --- ÜST BİLGİ (HEADER) ---
                page.Header().Row(row =>
                {
                    // Logo Alanı
                    if (imageData != null)
                    {
                        row.ConstantColumn(100).Image(imageData).FitArea();
                    }

                    row.ConstantColumn(20); // Boşluk

                    // Başlık Alanı
                    row.RelativeColumn().Column(col =>
                    {
                        col.Item().Text("Ders Listesi Raporu")
                            .FontSize(20)
                            .Bold()
                            .FontColor(Colors.Blue.Medium);

                        col.Item().Text($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}")
                            .FontSize(10)
                            .FontColor(Colors.Grey.Medium);
                    });
                });

                // --- İÇERİK (CONTENT) ---
                page.Content().PaddingVertical(20).Column(col =>
                {
                    col.Item().Table(table =>
                    {
                        // Sütun Genişlikleri (5 Sütun)
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(40); // Id (Dar)
                            columns.ConstantColumn(80); // Kod
                            columns.RelativeColumn();   // Ad (Geniş - Esnek)
                            columns.ConstantColumn(60); // Kredi
                            columns.ConstantColumn(80); // Sınıf
                        });

                        // Tablo Başlıkları
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Id").Bold();
                            header.Cell().Element(CellStyle).Text("Kod").Bold();
                            header.Cell().Element(CellStyle).Text("Ders Adı").Bold();
                            header.Cell().Element(CellStyle).Text("Kredi").Bold();
                            header.Cell().Element(CellStyle).Text("Sınıf").Bold();
                        });

                        // Tablo Verileri
                        foreach (var ders in dersler)
                        {
                            table.Cell().Element(CellStyle).Text(ders.Id.ToString());
                            table.Cell().Element(CellStyle).Text(ders.Kod);
                            table.Cell().Element(CellStyle).Text(ders.Ad);
                            table.Cell().Element(CellStyle).Text(ders.Kredi.ToString());
                            // SinifAdi null gelirse tire (-) koy
                            table.Cell().Element(CellStyle).Text(ders.SinifAdi ?? "-");
                        }
                    });
                });

                // --- ALT BİLGİ (FOOTER) ---
                page.Footer().Row(row =>
                {
                    row.RelativeColumn().AlignLeft().Text("Öğrenci İşleri Sistemi").FontSize(9).FontColor(Colors.Grey.Medium);

                    row.RelativeColumn().AlignCenter().Text(text =>
                    {
                        text.Span("Sayfa ").FontSize(9);
                        text.CurrentPageNumber().FontSize(9);
                        text.Span(" / ").FontSize(9);
                        text.TotalPages().FontSize(9);
                    });

                    row.RelativeColumn().AlignRight().Text($"Oluşturulma: {DateTime.Now:t}").FontSize(9);
                });
            });
        })
        .GeneratePdf();
    }
}