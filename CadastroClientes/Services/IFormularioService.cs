using CadastroClientes.Models;

namespace CadastroClientes.Services
{
    public interface IFormularioService
    {
        Task PostFormulario(FormularioOperacional formulario);
        Task<FormularioOperacional> GetFormulario(int id);
    }
}
