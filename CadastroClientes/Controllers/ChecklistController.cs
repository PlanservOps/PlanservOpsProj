using CadastroClientes.Dtos;
using CadastroClientes.Services.Pdf;
using CadastroClientes.Store;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ImagensChecklist _imageHandler;
        private readonly PdfStorageService _pdfStorageService;
        private PdfStorageService? pdfStorageService;

        public ChecklistController(IWebHostEnvironment env, ImagensChecklist imageHandler)
        {
            _env = env;
            _imageHandler = imageHandler;
            _pdfStorageService = pdfStorageService;
        }

        [HttpPost("gerar-pdf")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> GerarChecklistPdf([FromForm] ChecklistFormDto form)
        {
            var imageHandler = new ImagensChecklist(_env);
            var imagensSalvas = new Dictionary<int, string>();

            try
            {
                // Garante que todas as listas não sejam nulas
                form.ItensDescricao ??= new List<string>();
                form.ItensHorarioInicio ??= new List<string>();
                form.ItensHorarioFim ??= new List<string>();
                form.ItensConcluido ??= new List<bool>();
                form.ItensImagem ??= new List<IFormFile>();

                // Determina o tamanho seguro baseado na menor lista
                int totalItens = new[]
                {
                    form.ItensDescricao.Count,
                    form.ItensHorarioInicio.Count,
                    form.ItensHorarioFim.Count,
                    form.ItensConcluido.Count
                }.Min();

                var itens = new List<ChecklistItemDto>();

                for (int i = 0; i < totalItens; i++)
                {
                    var file = (form.ItensImagem.Count > i) ? form.ItensImagem[i] : null;

                    var item = new ChecklistItemDto
                    {
                        Descricao = form.ItensDescricao[i],
                        HorarioInicio = form.ItensHorarioInicio[i],
                        HorarioFim = form.ItensHorarioFim[i],
                        Concluido = form.ItensConcluido[i],
                        Imagem = file
                    };

                    //Salva imagem se necessário
                    if (item.Concluido && file is { Length: > 0 })
                    {
                        using var ms = new MemoryStream();
                        await file.CopyToAsync(ms);
                        var pathAbs = _imageHandler.SalvarImagemTemporaria(ms.ToArray(), file.FileName);
                        imagensSalvas[i] = pathAbs;
                    }
                    itens.Add(item);
                }

                var checklistSend = new ChecklistSendDto
                {
                    Cliente = form.Cliente,
                    DataHoraSubmissao = form.DataHoraSubmissao,
                    Itens = form.ItensDescricao.Select((desc, i) => new ChecklistItemDto
                    {
                        Descricao = form.ItensDescricao[i],
                        HorarioInicio = form.ItensHorarioInicio[i],
                        HorarioFim = form.ItensHorarioFim[i],
                        Concluido = form.ItensConcluido[i],
                    }).ToList()
                };

                // Salvar imagens temporárias
                var imagens = new Dictionary<int, string>();
                if (form.ItensImagem != null)
                {
                    var store = new ImagensChecklist(_env);
                    for (int i = 0; i < form.ItensImagem.Count; i++)
                    {
                        using var ms = new MemoryStream();
                        await form.ItensImagem[i].CopyToAsync(ms);
                        var caminho = store.SalvarImagemTemporaria(ms.ToArray(), form.ItensImagem[i].FileName);
                        imagens[i] = caminho;
                    }
                }

                // Gerar PDF em memória
                var pdfBytes = PdfGenerator.GerarFormularioPdf(form, checklistSend, imagens);

                // Persistir PDF no banco
                var pdfId = await _pdfStorageService.SalvarPdfAsync(form.Cliente, form.DataHoraSubmissao, pdfBytes);

                // Retornar id para download posterior
                return Ok(new
                {
                    message = "Checklist enviado e PDF armazenado com sucesso.",
                    pdfId
                });
            }
            finally
            {
                // Limpar imagens temporárias
                foreach (var path in imagensSalvas.Values)
                {
                    _imageHandler.ExcluirImagemTemporaria(path);
                }
            }
        }
    }
}
