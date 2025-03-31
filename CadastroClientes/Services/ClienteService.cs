using CadastroCliente.Models;

namespace CadastroClientes.Services
{
    public class ClienteService : IClienteService
    {
        public Task CreateCliente(ClienteTest cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCliente(ClienteTest cliente)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteTest> GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteTest>> GetClienteS()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteTest>> GetClientesByName(string nome)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCliente(ClienteTest cliente)
        {
            throw new NotImplementedException();
        }
    }
}
