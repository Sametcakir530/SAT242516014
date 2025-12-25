using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SAT242516014.Components.Pages.Students;

namespace MyReports;

public class Student
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Email { get; set; }
    public string Numara { get; set; }
    public string Tc {  get; set; }
}


public class Report_Student
{
    static IContainer CellStyle(IContainer container) =>
      container
        .Padding(5)
        .BorderBottom(1)
        .BorderColor(Colors.Grey.Lighten2);
    public byte[] Generate(List<Student> students)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var imagePath = "wwwroot/logo_siyah.png";
        var imageData = File.ReadAllBytes(imagePath);

        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.Header().Text("Header : Student List")
                  .FontSize(20)
                  .Bold();
                page.Content().Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        // logo + boşluk + başlık alanı
                        row.ConstantColumn(100)
              .Image(imageData)
              .FitArea();
                        row.ConstantColumn(20);
                        row.RelativeColumn().Column(c =>
                        {
                            c.Item().Text("Header").FontSize(16).Bold();
                            c.Item().Text($"DateTime: {DateTime.Now:d}");
                        });
                    });
                    col.Item().PaddingTop(10);
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Id").Bold();
                            header.Cell().Element(CellStyle).Text("Ad").Bold();
                            header.Cell().Element(CellStyle).Text("Soyad").Bold();
                            header.Cell().Element(CellStyle).Text("Email").Bold();
                            header.Cell().Element(CellStyle).Text("Numara").Bold();
                            header.Cell().Element(CellStyle).Text("Tc").Bold();

                        });
                        foreach (var student in students)
                        {
                            table.Cell().Element(CellStyle).Text(student.Id.ToString());
                            table.Cell().Element(CellStyle).Text(student.Ad);
                            table.Cell().Element(CellStyle).Text(student.Soyad);
                            table.Cell().Element(CellStyle).Text(student.Email);
                            table.Cell().Element(CellStyle).Text(student.Numara);
                            table.Cell().Element(CellStyle).Text(student.Tc);

                        }

                    });
                });

                page.Footer().Row(row =>
                {
                    row.RelativeColumn().AlignLeft().Text("Footer Left").FontSize(10);
                    row.RelativeColumn().AlignCenter().Text(text =>
                    {
                        text.Span("Page: ").FontSize(10);
                        text.CurrentPageNumber().FontSize(10).Bold();
                        text.Span(" / ").FontSize(10);
                        text.TotalPages().FontSize(10).Bold();
                    });
                    row.RelativeColumn().AlignRight().Text($"DateTime: {DateTime.Now:d}").FontSize(10);
                });
            });
        })
          .GeneratePdf();
    }
}        