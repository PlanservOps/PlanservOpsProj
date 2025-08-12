using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioOperacionalController : ControllerBase
    {
        private IFormularioOperacionalService _formularioService;

        public FormularioOperacionalController(IFormularioOperacionalService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpPost]
        public async Task<ActionResult<FormularioOperacional>> CreateFormulario([FromBody] FormularioOperacional formulario)
        {
            try
            {
                await _formularioService.CreateFormulario(formulario);
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateFormulario(int id, [FromBody] FormularioOperacional formulario)
        {
            if (id != formulario.Id)
                return BadRequest("Id do formulário não corresponde ao id na URL");
            try
            {
                await _formularioService.Updateformulario(formulario);
                return Ok(formulario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar formulário");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFormulario(int id)
        {
            try
            {
                var formulario = await _formularioService.GetFormularioId(id);
                if (formulario == null)
                    return NotFound($"Não existe formulário com id={id}");
                await _formularioService.DeleteFormulario(formulario);
                return Ok($"Formulário com id={id} foi deletado com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar formulário");
            }
        }
    }

}
