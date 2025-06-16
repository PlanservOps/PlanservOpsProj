using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFuncaoTerceirizadaService
    {
        Task<IEnumerable<FuncaoTerceirizada>> GetAllFuncao();
        Task<FuncaoTerceirizada> GetFuncaoById(int id);
        Task<FuncaoTerceirizada> CreateFuncao(FuncaoTerceirizada funcaoTerceirizada);
        Task<FuncaoTerceirizada> UpdateFuncao(FuncaoTerceirizada funcaoTerceirizada);
        Task<bool> DeleteFuncao(int id);
    }
}
