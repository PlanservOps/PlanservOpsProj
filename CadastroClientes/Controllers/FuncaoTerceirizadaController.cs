using CadastroClientes.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncaoTerceirizadaController : ControllerBase
    {
        private IFuncaoTerceirizadaService _funcaoTerceirizadaService;

        public FuncaoTerceirizadaController(IFuncaoTerceirizadaService funcaoTerceirizadaService)
        {
            _funcaoTerceirizadaService = funcaoTerceirizadaService;
        }

        [HttpPost]
        public async Task<ActionResult<FuncaoTerceirizada>> CreateFuncao([FromBody] FuncaoTerceirizada funcao)
        {
            try
            {
                await _funcaoTerceirizadaService.CreateFuncao(funcao);
                return Ok(funcao);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar Função Terceirizada");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<FuncaoTerceirizada>>> GetAllFuncao()
        {
            try
            {
                var funcao = await _funcaoTerceirizadaService.GetAllFuncao();
                return Ok(funcao);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Função Terceirizada");
            }
        }

        [HttpGet("{id:int}", Name = "GetFuncaoTerceirizada")]
        public async Task<ActionResult<FuncaoTerceirizada>> GetFuncaoById(int id)
        {
            try
            {
                var funcao = await _funcaoTerceirizadaService.GetFuncaoById(id);
                if (funcao == null)
                    return NotFound($"Não existe função terceirizada com id={id}");

                return Ok(funcao);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateFuncao(int id, [FromBody] FuncaoTerceirizada funcao)
        {
            try
            {
                if (funcao.funcoaterceirizadaid == id)
                {
                    await _funcaoTerceirizadaService.UpdateFuncao(funcao);
                    return Ok($"Função terceirizada com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest($"O id da função terceirizada não confere com o id da URL");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFuncao(int id)
        {
            try
            {
                var funcao = await _funcaoTerceirizadaService.GetFuncaoById(id);
                if (funcao != null)
                {
                    await _funcaoTerceirizadaService.DeleteFuncao(funcao);
                    return Ok($"Função terceirizada com id={id} foi excluído com sucesso");

                }
                else
                {
                    return NotFound($"Não existe função terceirizada com id={id}");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
