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

        public void GeneratePdf(FormularioOperacional formulario, string filePath)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Content()
                        .Column(col =>
                        {
                            col.Item().Text($"Data de Envio: {formulario.DataEnvio:dd/MM/yyyy}");
                            col.Item().Text($"Hora de Envio: {formulario.HoraEnvio:HH:mm:ss}");
                            col.Item().Text($"Clientes Atendidos: {formulario.ClientesAtendidos}");
                            col.Item().Text($"Problemas Reportados: {formulario.ProblemasReportados}");
                            col.Item().Text($"Gestores Atendidos: {formulario.GestoresAtendidos}");
                            col.Item().Text($"Cliente Posto: {formulario.ClientePosto}");
                            col.Item().Text($"Problemas Identificados: {formulario.ProblemasIdentificados}");
                            col.Item().Text($"Soluções Apresentadas: {formulario.SolucoesApresentadas}");
                            col.Item().Text($"Avaliação Igo: {formulario.AvaliacaoIgo}");
                            col.Item().Text($"Avaliação Robson: {formulario.AvaliacaoRobson}");
                            col.Item().Text($"Observações Gerais: {formulario.ObservacoesGerais}");
                        });
                });
            }).GeneratePdf(filePath);
        }

        public void Compose(IDocumentContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
