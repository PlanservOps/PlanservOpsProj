using CadastroCliente.Models;

namespace CadastroClientes.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClientesHumanas>> GetClientes();
        Task<ClientesHumanas> GetCliente(int id);
        Task<IEnumerable<ClientesHumanas>> GetClientesByClientePosto(string posto);
        Task CreateCliente(ClientesHumanas cliente);
        Task UpdateCliente(ClientesHumanas cliente);
        Task DeleteCliente(ClientesHumanas cliente);
    }
}
