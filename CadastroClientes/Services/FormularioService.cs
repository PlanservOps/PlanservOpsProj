using CadastroCliente.Context;
using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public class FormularioService : IFormularioService
    {
        private readonly AppDbContext _context;
        public FormularioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateFormulario(FormularioOperacional formulario)
        {
            _context.FormularioOperacional.Add(formulario);
            await _context.SaveChangesAsync();
        }
        public async Task<FormularioOperacional> GetFormulario(int id)
        {
            var formulario = await _context.FormularioOperacional.FindAsync(id);
            return formulario;
        }
    }        
}
