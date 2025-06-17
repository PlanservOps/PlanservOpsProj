using CadastroCliente.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class FuncaoTerceirizadaService : IFuncaoTerceirizadaService
    {
        private readonly AppDbContext _context;
        public FuncaoTerceirizadaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateFuncao(FuncaoTerceirizada funcao)
        {
            _context.FuncaoTerceirizada.Add(funcao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFuncao(FuncaoTerceirizada funcao)
        {
            _context.FuncaoTerceirizada.Remove(funcao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FuncaoTerceirizada>> GetAllFuncao()
        {
            //incluir filtro ou paginação de dados
            return await _context.FuncaoTerceirizada.ToListAsync();
        }

        public async Task<FuncaoTerceirizada> GetFuncaoById(int id)
        {
            var funcao = await _context.FuncaoTerceirizada.FindAsync(id);
            return funcao;
        }

        public async Task UpdateFuncao(FuncaoTerceirizada funcao)
        {
            _context.Entry(funcao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
