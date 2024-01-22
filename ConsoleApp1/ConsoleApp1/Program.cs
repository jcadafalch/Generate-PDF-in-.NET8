using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;


Document.Create(document =>
{
    document.Page(page =>
    {
        page.Margin(30);

        //page.Header().Height(100).Background(Colors.Blue.Lighten1);
        //page.Content().Background(Colors.Yellow.Lighten1);
        //page.Footer().Height(50).Background(Colors.Red.Lighten1);

        page.Header().ShowOnce().Row(row =>
        {
            row.ConstantItem(140).Height(60).Placeholder();

            row.RelativeItem().Column(col =>
            {
                col.Item().AlignCenter().Text("Código Estudiante SAC").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Jr. Las mercedes N378 - Lima").FontSize(9);
                col.Item().AlignCenter().Text("987 987 123 / 02 213232").FontSize(9);
                col.Item().AlignCenter().Text("codigo@example.com").FontSize(9);

            });

            row.RelativeItem().Column(col =>
            {
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("RUC 123752155");

                col.Item().Background("#257272").Border(1).BorderColor("#257272").AlignCenter().Text("Boleta de venta").FontColor("#fff");

                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("B0001 - 234");

            });

        });

        page.Content().PaddingVertical(10).Column(col =>
        {
            col.Item().Column(col1 =>
            {
                col1.Item().Text("Datos del cliente").Underline().Bold();

                col1.Item().Text(txt =>
                {
                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                    txt.Span("Mario Mendoza").FontSize(10);
                });

                col1.Item().Text(txt =>
                {
                    txt.Span("DNI: ").SemiBold().FontSize(10);
                    txt.Span("00000000T").FontSize(10);
                });

                col1.Item().Text(txt =>
                {
                    txt.Span("Dirección: ").SemiBold().FontSize(10);
                    txt.Span("Av. Miraflores 123").FontSize(10);
                });
            });

            col.Item().LineHorizontal(0.5f);

            int precioTotal = 0;

            col.Item().Table(table =>
            {
                IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                {
                    return container
                        .BorderBottom(0.5f)
                        .BorderColor("#D9D9D9")
                        .Background(backgroundColor)
                        .Padding(2);
                        
                }

                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Background("#257272").Padding(2).Text("Producto").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Precio Unit").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Cantidad").FontColor("#fff");

                    header.Cell().Background("#257272").Padding(2).Text("Total").FontColor("#fff");
                });

                foreach(var item in Enumerable.Range(1, 45))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.Next(5, 15);
                    var total = cantidad * precio;

                    precioTotal += total;

                    table.Cell().Element(CellStyle).Text(Placeholders.Label()).FontSize(10);

                    table.Cell().Element(CellStyle).Text(precio.ToString()).FontSize(10);

                    table.Cell().Element(CellStyle).Text($"{cantidad} €").FontSize(10);

                    table.Cell().Element(CellStyle).AlignRight().Text($"{total} €").FontSize(10);

                    IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.White).ShowOnce();
                }

            });

            col.Item().AlignRight().Text($"Total: {precioTotal} €").SemiBold().FontSize(12);

            col.Item().Background(Colors.Grey.Medium).Padding(10).Column(column =>
            {
                column.Item().Text("Comentarios").FontSize(14);
                column.Item().Text(Placeholders.LoremIpsum());
                column.Spacing(5);
            });

            col.Spacing(10);
        });

    });
}).ShowInPreviewer();