using CadastroCliente.Models;

namespace CadastroClientes.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteTest>> GetClienteS();
        Task<ClienteTest> GetCliente(int id);
        Task<IEnumerable<ClienteTest>> GetClientesByName(string nome);
        Task CreateCliente(ClienteTest cliente);
        Task UpdateCliente(ClienteTest cliente);
        Task DeleteCliente(ClienteTest cliente);
    }
}
