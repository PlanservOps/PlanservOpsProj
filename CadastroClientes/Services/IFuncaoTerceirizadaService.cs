using CadastroCliente.Models;
using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFuncaoTerceirizadaService
    {
        Task<IEnumerable<FuncaoTerceirizada>> GetAllFuncao();
        Task<FuncaoTerceirizada> GetFuncaoById(int id);
        Task CreateFuncao(FuncaoTerceirizada funcaoTerceirizada);
        Task UpdateFuncao(FuncaoTerceirizada funcaoTerceirizada);
        Task DeleteFuncao(FuncaoTerceirizada funcao);
    }
}
