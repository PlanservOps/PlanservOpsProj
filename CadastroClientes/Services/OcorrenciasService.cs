using CadastroCliente.Context;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class OcorrenciasService : IOcorrenciasService
    {
        private readonly AppDbContext _context;

        public OcorrenciasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ocorrencias>> GetOcorrencia()
        {
            return await _context.Ocorrencias.ToListAsync();
        }
        public async Task<Ocorrencias> GetOcorrenciaById(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            return ocorrencia;
        }
        public async Task CreateOcorrencia(Ocorrencias ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOcorrencia(Ocorrencias ocorrencia)
        {
            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();
        }


    }
}
