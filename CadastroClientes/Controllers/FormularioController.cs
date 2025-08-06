using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioPdfController : ControllerBase
    {
        private IFormularioService _formularioService;

        public FormularioPdfController(IFormularioService formularioService)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar formulário");
            }
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter formulários");
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
