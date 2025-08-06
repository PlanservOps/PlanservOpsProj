using CadastroClientes.Dtos;
using CadastroClientes.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CadastroClientes.Services.Pdf
{
    public class FormularioPdf : IDocument
    {
        private readonly ChecklistItemDto _item;      // ⬅️  modelo
        private readonly ChecklistFormDto _form;      // ⬅️  modelo
        private readonly Dictionary<int, string> _imagens;

        public FormularioPdf(ChecklistFormDto form, Dictionary<int, string> imagens)   // ⬅️  construtor certo
        {
            _form = form;
            _imagens = imagens;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
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
                                .Text("Relatório de Formulário Gerencial Operacional").FontSize(14).Italic().FontColor(Colors.Grey.Darken4);
                            });       
                        
                    });
          
                page.Content()
                    .Column(col =>
                    {
                        col.Item().Text($"Checklist - {_form.DataHoraSubmissao:dd/MM/yyyy HH:mm}");
                        col.Item().Text($"Cliente: {_form.ClienteId}").FontSize(12).Italic();

                        foreach (var (item, index) in _form.Itens.Select((x, i) => (x, i)))
                        {
                            col.Item().PaddingTop(10).BorderBottom(1).Column(c =>
                            {
                                c.Item().Text($"Horário: {item.HorarioInicio} - {item.HorarioFim}");
                                c.Item().Text($"Atividade: {item.Descricao}");
                                c.Item().Text($"Concluído: {(item.Concluido ? "Sim" : "Não")}");

                                if (item.Concluido && _imagens.ContainsKey(index))
                                {
                                    c.Item().PaddingTop(5).Image(_imagens[index]);
                                }
                            });
                        }
                    });

                page.Footer()
                    .AlignCenter()
                    .Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}").FontSize(10).FontColor(Colors.Grey.Lighten1);
            });
        }       
    }
}
