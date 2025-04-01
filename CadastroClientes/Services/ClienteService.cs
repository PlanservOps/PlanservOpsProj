using CadastroCliente.Context;
using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteTest>> GetClientes()
        {
            //incluir filtro ou paginação de dados
            return await _context.ClienteTest.ToListAsync();
        }
        public async Task<IEnumerable<ClienteTest>> GetClientesByClientePosto(string posto)
        {
            IEnumerable<ClienteTest> cliente;
            if (string.IsNullOrWhiteSpace(posto)) 
            {
                cliente = await _context.ClienteTest.Where(n=> n.ClientePosto.Contains(posto)).ToListAsync();
            }
            else
            {
                cliente = await GetClientes();
            }
            return cliente;
        }
        public async Task<ClienteTest> GetCliente(int id)
        {
            //implementação simples - necessário tratamento de erros global 
            var cliente = await _context.ClienteTest.FindAsync(id);
            return cliente;
        }
        public async Task CreateCliente(ClienteTest cliente)
        {
            _context.ClienteTest.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCliente(ClienteTest cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCliente(ClienteTest cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
