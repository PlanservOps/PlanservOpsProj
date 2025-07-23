using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReclamacoesController : ControllerBase
    {
        private IReclamacaoService _reclamacaoService;
        public ReclamacoesController(IReclamacaoService reclamacaosService)
        {
            _reclamacaoService = reclamacaosService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Reclamacoes>>> GetOcorrencia()
        {
            try
            {
                var reclamacao = await _reclamacaoService.GetReclamacao();
                return Ok(reclamacao);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Ocorrencia");
            }
        }

        [HttpGet("{id:int}", Name = "GetReclamacao")]
        public async Task<ActionResult<Ocorrencias>> GetReclamacaoById(int id)
        {
            try
            {
                var reclamacao = await _reclamacaoService.GetReclamacaoById(id);
                if (reclamacao == null)
                    return NotFound($"Não existe reclamacao com id={id}");

                return Ok(reclamacao);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Reclamacoes>> CreateReclamacao([FromBody] Reclamacoes reclamacao)
        {
            try
            {
                await _reclamacaoService.CreateReclamacao(reclamacao);
                return Ok(reclamacao);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Ocorrencia");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateReclamacao(int id, [FromBody] Reclamacoes reclamacao)
        {
            try
            {
                if (reclamacao.Reclamacaoid == id)
                {
                    await _reclamacaoService.UpdateReclamacao(reclamacao);
                    return Ok($"Reclamacao com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest($"O id do cliente não confere com o id da URL");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteReclamacao(int id)
        {
            try
            {
                var reclamacao = await _reclamacaoService.GetReclamacaoById(id);
                if (reclamacao != null)
                {
                    await _reclamacaoService.DeleteReclamacao(reclamacao);
                    return Ok($"Ocorrencia com id={id} foi excluído com sucesso");

                }
                else
                {
                    return NotFound($"Não existe reclamacao com id={id}");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
