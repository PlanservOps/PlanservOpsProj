using CadastroCliente.Models;
using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
