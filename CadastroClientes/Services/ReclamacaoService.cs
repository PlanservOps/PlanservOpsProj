using CadastroCliente.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class ReclamacaoService : IReclamacaoService
    {
        private readonly AppDbContext _context;

        public ReclamacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateReclamacao(Reclamacoes reclamacoes)
        {
            _context.Reclamacoes.Add(reclamacoes);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Reclamacoes>> GetReclamacao()
        {
            return await _context.Reclamacoes.ToListAsync();
        }
        public async Task<Reclamacoes> GetReclamacaoById(int id)
        {
            var reclamacoes = await _context.Reclamacoes.FindAsync(id);
            return reclamacoes;
        }
        public async Task UpdateReclamacao(Reclamacoes reclamacoes)
        {
            _context.Entry(reclamacoes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReclamacao(Reclamacoes reclamacoes)
        {
            _context.Reclamacoes.Remove(reclamacoes);
            await _context.SaveChangesAsync();
        }
    }
}
