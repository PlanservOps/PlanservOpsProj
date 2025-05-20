using CadastroCliente.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly AppDbContext _context;
        public FormularioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FormularioOperacional>> GetFormulario()
        {
            return await _context.FormularioOperacional.ToListAsync();            
        }
        public async Task PostFormulario(FormularioOperacional formulario)
        {
            _context.FormularioOperacional.Add(formulario);
            await _context.SaveChangesAsync();
        }
        public async Task<FormularioOperacional> GetFormularioId(int id)
        {
            var formulario = await _context.FormularioOperacional.FindAsync(id);
            return formulario;
        }
    }        
}
