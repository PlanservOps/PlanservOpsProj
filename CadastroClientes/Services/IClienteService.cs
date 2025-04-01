using CadastroCliente.Models;

namespace CadastroClientes.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteTest>> GetClientes();
        Task<ClienteTest> GetCliente(int id);
        Task<IEnumerable<ClienteTest>> GetClientesByClientePosto(string posto);
        Task CreateCliente(ClienteTest cliente);
        Task UpdateCliente(ClienteTest cliente);
        Task DeleteCliente(ClienteTest cliente);
    }
}
