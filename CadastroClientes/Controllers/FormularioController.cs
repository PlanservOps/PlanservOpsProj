using CadastroCliente.Context;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormularioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FormularioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostFormulario([FromBody] FormularioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var formulario = new Formulario
            {
                Campo1 = dto.Campo1,
                Campo2 = dto.Campo2,
                OutraEntidadeId = dto.OutraEntidadeId,
                DataEnvio = DateTime.UtcNow
            };

            _context.Formularios.Add(formulario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFormulario), new { id = formulario.Id }, formulario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormulario(int id)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
                return NotFound();

            return Ok(formulario);
        }
    }

}
