using CadastroClientes.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CadastroClientes.Services.Pdf
{
    public class FormularioPdf : IDocument
    {
        private readonly FormularioOperacional _data;      // ⬅️  modelo

        public FormularioPdf(FormularioOperacional data)   // ⬅️  construtor certo
        {
            _data = data;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);

                page.Header()
                    .Row(row =>
                    {
                        row.RelativeItem()
                            .Column(column =>
                            {
                                column.Item()
                                .Text("Planserv").FontSize(16).Bold().FontColor(Colors.Green.Darken2);
                                column.Item()
                                .Text("Relatório de Formulário Gerencial Operacional").FontSize(14).Italic().FontColor(Colors.Grey.Lighten1);
                            });                            
                    });

                page.Content().Column(col =>
                {
                    col.Item().Text($"Data de Envio: {_data.DataEnvio:dd/MM/yyyy}");
                    col.Item().Text($"Hora de Envio: {_data.HoraEnvio:HH:mm:ss}");
                    col.Item().Text($"Clientes Atendidos: {_data.ClientesAtendidos}");
                    col.Item().Text($"Problemas Reportados: {_data.ProblemasReportados}");
                    col.Item().Text($"Gestores Atendidos: {_data.GestoresAtendidos}");
                    col.Item().Text($"Cliente Posto: {_data.ClientePosto}");
                    col.Item().Text($"Problemas Identificados: {_data.ProblemasIdentificados}");
                    col.Item().Text($"Soluções Apresentadas: {_data.SolucoesApresentadas}");
                    col.Item().Text($"Avaliação Igo: {_data.AvaliacaoIgo}");
                    col.Item().Text($"Avaliação Robson: {_data.AvaliacaoRobson}");
                    col.Item().Text($"Observações Gerais: {_data.ObservacoesGerais}");
                });
            });
        }       
    }
}
