using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFormularioService
    {
        Task CreateFormulario(FormularioOperacional formulario);
        Task<FormularioOperacional> GetFormulario(int id);
    }
}
