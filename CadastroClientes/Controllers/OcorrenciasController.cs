using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciasController : ControllerBase
    {
        private IOcorrenciasService _ocorrenciasService;

        public OcorrenciasController(IOcorrenciasService ocorrenciasService)
        {
            _ocorrenciasService = ocorrenciasService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Ocorrencias>>> GetOcorrencia()
        {
            try
            {
                var ocorrencia = await _ocorrenciasService.GetOcorrencia();
                return Ok(ocorrencia);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Ocorrencia");
            }
        }

        [HttpGet("{id:int}", Name = "GetOcorrencia")]
        public async Task<ActionResult<Ocorrencias>> GetOcorrenciaById(int id)
        {
            try
            {
                var ocorrencia = await _ocorrenciasService.GetOcorrenciaById(id);
                if (ocorrencia == null)
                    return NotFound($"Não existe ocorrencia com id={id}");

                return Ok(ocorrencia);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ocorrencias>> CreateOcorrencia([FromBody] Ocorrencias ocorrencia)
        {
            try
            {
                await _ocorrenciasService.CreateOcorrencia(ocorrencia);
                return Ok(ocorrencia);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Ocorrencia");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteOcorrencia(int id)
        {
            try
            {
                var ocorrencia = await _ocorrenciasService.GetOcorrenciaById(id);
                if (ocorrencia != null)
                {
                    await _ocorrenciasService.DeleteOcorrencia(ocorrencia);
                    return Ok($"Ocorrencia com id={id} foi excluído com sucesso");

                }
                else
                {
                    return NotFound($"Não existe ocorrencia com id={id}");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}

