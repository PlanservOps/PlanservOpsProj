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

        public ChecklistController(IWebHostEnvironment env, ImagensChecklist imageHandler)
        {
            _env = env;
            _imageHandler = imageHandler;
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
                    var item = new ChecklistItemDto
                    {
                        Descricao = form.ItensDescricao[i],
                        HorarioInicio = form.ItensHorarioInicio[i],
                        HorarioFim = form.ItensHorarioFim[i],
                        Concluido = form.ItensConcluido[i],
                        Imagem = (form.ItensImagem.Count > i) ? form.ItensImagem[i] : null
                    };

                    //Salva imagem se necessário
                    if (item.Concluido && item.Imagem != null)
                    {
                        using var ms = new MemoryStream();
                        await item.Imagem.CopyToAsync(ms);
                        var bytes = ms.ToArray();

                        // Salva em disco
                        var caminhoImagem = _imageHandler.SalvarImagemTemporaria(bytes, item.Imagem.FileName);

                        // Aqui precisamos guardar o caminho ABSOLUTO para poder abrir com File.ReadAllBytes
                        var absolutePath = Path.Combine(_env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot"), "temporary-images", item.Imagem.FileName);

                        imagensSalvas[i] = absolutePath;
                    }

                    itens.Add(item);
                }

                var checklistSend = new ChecklistSendDto
                {
                    Cliente = form.Cliente,
                    DataHoraSubmissao = form.DataHoraSubmissao,
                    Itens = itens
                };

                byte[] pdfBytes = PdfGenerator.GerarFormularioPdf(form, checklistSend, imagensSalvas);
                return File(pdfBytes, "application/pdf", $"Checklist_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar PDF: " + ex);
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }           
        }
    }
}
