using CadastroCliente.Context;
using CadastroClientes.Migrations;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class FormularioOperacionalService : IFormularioOperacionalService
    {
        private readonly AppDbContext _context;

        public FormularioOperacionalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateFormulario(FormularioOperacional formulario)
        {
            _context.FormularioOperacional.Add(formulario);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<FormularioOperacional>> GetFormulario()
        {
            return await _context.FormularioOperacional.ToListAsync();
        }
        public async Task<FormularioOperacional> GetFormularioId(int id)
        {
            var formulario = await _context.FormularioOperacional.FindAsync(id);
            return formulario;
        }
        public async Task Updateformulario(FormularioOperacional formulario)
        {
            _context.Entry(formulario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFormulario(FormularioOperacional formulario)
        {
            _context.FormularioOperacional.Remove(formulario);
            await _context.SaveChangesAsync();
        }
    }        
}
