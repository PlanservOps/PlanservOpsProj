using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFormularioOperacionalService
    {
        Task CreateFormulario(FormularioOperacional formulario);
        Task<IEnumerable<FormularioOperacional>> GetFormulario();
        Task<FormularioOperacional> GetFormularioId(int id);
        Task Updateformulario(FormularioOperacional formulario);
        Task DeleteFormulario(FormularioOperacional formulario);
    }
}
