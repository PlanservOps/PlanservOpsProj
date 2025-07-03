using CadastroClientes.Models;
using CadastroClientes.Services;
using CadastroClientes.Services.Pdf;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioController : ControllerBase
    {
        private IFormularioService _formularioService;

        public FormularioController(IFormularioService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpPost]
        public async Task<ActionResult<FormularioOperacional>> PostFormulario([FromBody] FormularioOperacional formulario)
        {
            try
            {
                await _formularioService.PostFormulario(formulario);
                return Ok(formulario);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar cliente");
            }
        }

        [HttpPost("gerar-pdf")]
        public ActionResult<FormularioOperacional> GerarPdfFormulario([FromBody] FormularioOperacional formulario)
        {
#if DEBUG
            PdfGenerator.MostrarPreview(formulario);
            return Ok("PDF aberto no Companion para visualização.");
#else
            var pdf = PdfGenerator.GerarFormularioPdf(formulario);
            return File(pdf, "application/pdf", $"relatorio-{clientePosto}.pdf");
#endif
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<FormularioOperacional>>> GetFormulario()
        {
            try
            {
                var formulario = await _formularioService.GetFormulario();
                return Ok(formulario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Clientes");
            }
        }

        [HttpGet("{id:int}", Name ="GetFormulario")]
        public async Task<ActionResult<FormularioOperacional>> GetFormularioId(int id)
        {
            try
            {
                var formulario = await _formularioService.GetFormularioId(id);
                if (formulario == null)
                    return NotFound($"Não existe formulário com id={id}");

                return Ok(formulario);
            }
            catch
            {
                return BadRequest("Request inválido"); 
            }
        }
    }

}
