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

        public ChecklistController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("checklist/gerar-pdf")]
        public async Task<IActionResult> GerarChecklistPdf([FromForm] ChecklistFormDto form)
        {
            var imageHandler = new ImagensChecklist(_env);
            var imagensSalvas = new Dictionary<int, string>();

            try
            {
                for (int i = 0; i < form.Itens.Count; i++)
                {
                    var item = form.Itens[i];
                    if (item.Concluido && item.Imagem != null)
                    {
                        var caminho = await imageHandler.SalvarAsync(item.Imagem);
                        imagensSalvas[i] = caminho;
                    }
                }

                byte[] pdfBytes = PdfGenerator.GerarFormularioPdf(form, imagensSalvas);
                return File(pdfBytes, "application/pdf", $"Checklist_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            }
            finally
            {
                // Limpeza das imagens temporárias
                foreach (var caminho in imagensSalvas.Values)
                {
                    imageHandler.RemoverImagem(caminho);
                }
            }
        }

    }
}
