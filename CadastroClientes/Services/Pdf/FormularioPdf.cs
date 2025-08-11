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
            // Reconstrução já feita no controller; aqui apenas atribuimos
            _send = send ?? throw new ArgumentNullException(nameof(send));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _imagens = imagens ?? new Dictionary<int, string>();
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            // Página(s) de cabeçalho + tarefas — QuestPDF vai paginar automaticamente se necessário
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
                page.Margin(2, Unit.Centimetre);

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().Text("Planserv").FontSize(16).Bold().FontColor(Colors.Green.Darken2);
                        column.Item().Text("Relatório de Formulário Gerencial Operacional").FontSize(14).Italic().FontColor(Colors.Grey.Darken4);
                    });
                });

                page.Content().Column(col =>
                {
                    col.Item().Text($"Checklist - {_form.DataHoraSubmissao:dd/MM/yyyy HH:mm}");
                    col.Item().Text($"Cliente: {_form.Cliente}").FontSize(12).Italic();
                    col.Item().Text($"Total de itens: {_send.Itens?.Count ?? 0}");

                    if (_send.Itens != null && _send.Itens.Any())
                    {
                        foreach (var item in _send.Itens)
                        {
                            // Cada item é um bloco que pode ser quebrado entre páginas — não forçamos a manter tudo junto
                            col.Item().PaddingTop(6).BorderBottom(1).Column(c =>
                            {
                                c.Item().Text($"Horário: {item.HorarioInicio} - {item.HorarioFim}");
                                c.Item().Text($"Atividade: {item.Descricao}");
                                c.Item().Text($"Concluído: {(item.Concluido ? "Sim" : "Não")}");
                            });
                        }
                    }
                    else
                    {
                        col.Item().PaddingTop(8).Text("Nenhum item registrado.");
                    }
                });

                page.Footer().AlignCenter().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}").FontSize(10).FontColor(Colors.Grey.Lighten1);
            });

            // Página(s) de imagens: cria uma página por imagem (apenas itens marcados como concluídos com imagem válida)
            if (_send.Itens != null)
            {
                foreach (var (item, index) in _send.Itens.Select((x, i) => (x, i)))
                {
                    if (!item.Concluido) continue;
                    if (!_imagens.TryGetValue(index, out var imagemPath)) continue;
                    if (!File.Exists(imagemPath)) continue;

                    // Cria uma página exclusiva para esta imagem
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.PageColor(Colors.White);
                        page.Margin(2, Unit.Centimetre);

                        page.Header().Column(header =>
                        {
                            header.Item().Text("Imagens do Checklist").FontSize(14).Bold().FontColor(Colors.Grey.Darken3);
                            header.Item().Text($"Item {index + 1} - {item.Descricao}").FontSize(12).Italic();
                        });

                        page.Content().Column(col =>
                        {
                            col.Item().PaddingTop(6).Text($"Horário: {item.HorarioInicio} - {item.HorarioFim}");
                            col.Item().Text($"Concluído: {(item.Concluido ? "Sim" : "Não")}");
                            col.Item().PaddingTop(8).Element(elem =>
                            {
                                try
                                {
                                    var bytes = File.ReadAllBytes(imagemPath);

                                    // Corrected: Use the proper method chain for scaling the image
                                    elem.Image(bytes)
                                        .FitArea(); // Adjusted to use the correct method
                                }
                                catch (Exception ex)
                                {
                                    // Se houver problema ao ler/imprimir a imagem, mostra mensagem no PDF
                                    elem.Text($"[Erro ao carregar imagem: {ex.Message}]").FontColor(Colors.Red.Darken2);
                                }
                            });
                        });

                        page.Footer().AlignCenter().Text($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}").FontSize(10).FontColor(Colors.Grey.Lighten1);
                    });
                }
            }
        }
    }
}
