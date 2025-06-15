using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IOcorrenciasService
    {
        Task<IEnumerable<Ocorrencias>> GetOcorrencia();
        Task<Ocorrencias> GetOcorrenciaById(int id);
        Task CreateOcorrencia(Ocorrencias ocorrencia);
        Task DeleteOcorrencia(int id);
    }
}
