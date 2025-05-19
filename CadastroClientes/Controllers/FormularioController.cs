using CadastroClientes.Models;
using CadastroClientes.Services;
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
        public async Task<ActionResult<FormularioOperacional>> GetFormulario(int id)
        {
            try
            {
                var formulario = await _formularioService.GetFormulario(id);
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
