using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFormularioService
    {
        Task<IEnumerable<FormularioOperacional>> GetFormulario();
        Task PostFormulario(FormularioOperacional formulario);
        Task<FormularioOperacional> GetFormularioId(int id);
    }
}
