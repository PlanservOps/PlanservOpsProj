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

        public ChecklistController(
            IWebHostEnvironment env,
            ImagensChecklist imageHandler,
            PdfStorageService pdfStorageService)
        {
            _env = env;
            _imageHandler = imageHandler;
            _pdfStorageService = pdfStorageService;
        }

        [HttpPost("gerar-pdf")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> GerarChecklistPdf([FromForm] ChecklistFormDto form)
        {
            var imagensSalvas = new Dictionary<int, string>();

            try
            {
                // Segurança contra null
                form.ItensDescricao ??= [];
                form.ItensHorarioInicio ??= [];
                form.ItensHorarioFim ??= [];
                form.ItensConcluido ??= [];
                form.ItensImagem ??= [];

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
                    var file = form.ItensImagem.Count > i ? form.ItensImagem[i] : null;

                    if (form.ItensConcluido[i] && file != null && file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        await file.CopyToAsync(ms);
                        var path = _imageHandler.SalvarImagemTemporaria(ms.ToArray(), file.FileName);
                        imagensSalvas[i] = path;
                    }

                    itens.Add(new ChecklistItemDto
                    {
                        Descricao = form.ItensDescricao[i],
                        HorarioInicio = form.ItensHorarioInicio[i],
                        HorarioFim = form.ItensHorarioFim[i],
                        Concluido = form.ItensConcluido[i],
                        Imagem = file
                    });
                }

                var checklistSend = new ChecklistSendDto
                {
                    Cliente = form.Cliente,
                    DataHoraSubmissao = form.DataHoraSubmissao,
                    Itens = itens
                };

                var pdfBytes = PdfGenerator.GerarFormularioPdf(form, checklistSend, imagensSalvas);

                var pdfId = await _pdfStorageService
                    .SalvarPdfAsync(form.Cliente, form.DataHoraSubmissao, pdfBytes);

                return Ok(new
                {
                    message = "Checklist enviado e PDF armazenado com sucesso.",
                    pdfId
                });
            }
            finally
            {
                // Remove imagens temporárias
                foreach (var path in imagensSalvas.Values)
                    _imageHandler.ExcluirImagemTemporaria(path);
            }
        }
    }
}
