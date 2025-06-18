using CadastroCliente.Models;
using CadastroClientes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public async Task<ActionResult<ClienteTest>> CreateCliente([FromBody]ClienteTest cliente)
        {
            try
            {
                Console.WriteLine($"[DEBUG] Dados recebidos: {JsonSerializer.Serialize(cliente)}");
                await _clienteService.CreateCliente(cliente);
                return Ok(cliente);

            }
            catch
            {
                Console.WriteLine($"[ERROR] Não foi.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar cliente");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCliente(int id, [FromBody] ClienteTest cliente)
        {
            try
            {                
                if (cliente.ClienteId == id)
                {
                    await _clienteService.UpdateCliente(cliente);
                    return Ok($"Cliente com id={id} foi atualizado com sucesso");
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
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _clienteService.GetCliente(id);
                if (cliente != null)
                {
                    await _clienteService.DeleteCliente(cliente);
                    return Ok($"Cliente com id={id} foi excluído com sucesso");

                }
                else
                {
                    return NotFound($"Não existe cliente com id={id}");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }
    }
}
