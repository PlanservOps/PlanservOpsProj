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

        public async Task<IEnumerable<ClientesHumanas>> GetClientes()
        {
            //incluir filtro ou paginação de dados
            return await _context.ClientesHumanas.ToListAsync();
        }
        public async Task<IEnumerable<ClientesHumanas>> GetClientesByClientePosto(string posto)
        {
            IEnumerable<ClientesHumanas> cliente;
            if (!string.IsNullOrWhiteSpace(posto)) 
            {
                cliente = await _context.ClientesHumanas.Where(n=> n.ClientePosto.Contains(posto)).ToListAsync();
            }
            else
            {
                cliente = await GetClientes();
            }
            return cliente;
        }
        public async Task<ClientesHumanas> GetCliente(int id)
        {
            //implementação simples - necessário tratamento de erros global 
            var cliente = await _context.ClientesHumanas.FindAsync(id);
            return cliente;
        }
        public async Task CreateCliente(ClientesHumanas cliente)
        {
            _context.ClientesHumanas.Add(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCliente(ClientesHumanas cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCliente(ClientesHumanas cliente)
        {
            _context.ClientesHumanas.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
