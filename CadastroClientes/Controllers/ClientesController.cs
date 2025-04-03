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
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name="GetCliente")]
        public async Task<ActionResult<ClienteTest>> GetCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(id);
                if (cliente == null)
                    return NotFound($"Não existe cliente com id={id}");
                
                return Ok(cliente);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteTest>> CreateCliente(ClienteTest cliente)
        {
            try
            {               
                await _clienteService.CreateCliente(cliente);
                return CreatedAtRoute(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar cliente");
            }
        }
    }
}
