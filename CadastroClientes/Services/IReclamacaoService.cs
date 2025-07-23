using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IReclamacaoService
    {
        Task<IEnumerable<Reclamacoes>> GetReclamacao();
        Task<Reclamacoes> GetReclamacaoById(int id);
        Task CreateReclamacao(Reclamacoes reclamacoes);
        Task UpdateReclamacao(Reclamacoes reclamacoes);
        Task DeleteReclamacao(Reclamacoes reclamacoes);
    }
}
