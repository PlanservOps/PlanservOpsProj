using System.IO;
using CadastroClientes.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CadastroClientes.Services.Pdf
{
    public class FormularioPdf : IDocument
    {
        private readonly ChecklistSendDto _send;
        private readonly ChecklistFormDto _form;
        private readonly Dictionary<int, string> _imagens;

        public FormularioPdf(ChecklistFormDto form, ChecklistSendDto send, Dictionary<int, string> imagens)
        {
            _send = send ?? throw new ArgumentNullException(nameof(send));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _imagens = imagens ?? new Dictionary<int, string>();
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
                page.Margin(2, Unit.Centimetre);

                // Cabeçalho
                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text("Planserv").FontSize(16).Bold().FontColor(Colors.Green.Darken2);
                        column.Item().Text("Relatório de Formulário Gerencial Operacional")
                                     .FontSize(14)
                                     .Italic()
                                     .FontColor(Colors.Grey.Darken4);
                    });
                });

                // Conteúdo
                page.Content().Column(col =>
                {
                    col.Item().Text($"Checklist - {_form.DataHoraSubmissao:dd/MM/yyyy HH:mm}");
                    col.Item().Text($"Cliente: {_form.Cliente}").FontSize(12).Italic();
                    col.Item().Text($"Total de itens: {_send.Itens?.Count ?? 0}");

                    if (_send.Itens != null && _send.Itens.Any())
                    {
                        foreach (var (item, index) in _send.Itens.Select((x, i) => (x, i)))
                        {
                            col.Item().PaddingVertical(10).BorderBottom(1).Row(row =>
                            {
                                // Coluna da esquerda: texto
                                row.RelativeItem(2).Column(c =>
                                {
                                    c.Item().Text($"Horário: {item.HorarioInicio} - {item.HorarioFim}");
                                    c.Item().Text($"Atividade: {item.Descricao}");
                                    c.Item().Text($"Concluído: {(item.Concluido ? "Sim" : "Não")}");
                                });

                                // Coluna da direita: imagem
                                row.RelativeItem(1).AlignMiddle().Element(elem =>
                                {
                                    if (item.Concluido && _imagens.TryGetValue(index, out var imagemPath) && File.Exists(imagemPath))
                                    {
                                        try
                                        {
                                            var bytes = File.ReadAllBytes(imagemPath);
                                            elem.Image(bytes)
                                                .FitArea();
                                                /*.MaxHeight(150)*/ // ajusta para não ocupar espaço excessivo
                                                //.MaxWidth(200);
                                        }
                                        catch (Exception ex)
                                        {
                                            elem.Text($"[Erro ao carregar imagem: {ex.Message}]")
                                                .FontColor(Colors.Red.Darken2);
                                        }
                                    }
                                    else
                                    {
                                        elem.Text("[Sem imagem]").FontSize(10).FontColor(Colors.Grey.Lighten1);
                                    }
                                });
                            });
                        }
                    }
                    else
                    {
                        col.Item().PaddingTop(8).Text("Nenhum item registrado.");
                    }
                });

                // Rodapé
                page.Footer().AlignCenter()
                    .Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                    .FontSize(10)
                    .FontColor(Colors.Grey.Lighten1);
            });
        }
    }
}
