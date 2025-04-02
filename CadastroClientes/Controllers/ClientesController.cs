using CadastroCliente.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ClienteTest>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.GetClientes();
                return Ok(clientes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Clientes");
            }
        }

        [HttpGet("ClientePorPosto")]
        public async Task<ActionResult<IAsyncEnumerable<ClienteTest>>> GetClientesByClientePosto([FromQuery]string posto)
        {
            try
            {
                var clientes = await _clienteService.GetClientesByClientePosto(posto);
                if (clientes.Count()==0)
                    return NotFound($"Não existem clientes com o critério {posto}");
                
                return Ok(clientes);
            }
            catch
            {
                return BadRequest("Erro ao obter Clientes");
            }
        }
    }
}
