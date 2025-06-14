using CadastroClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Services
{
    public interface IProfileService
    {
        Task<ProfileToken> CreateUserAsync(RegisterViewModel model);
        Task<ProfileToken> LoginAsync(LoginViewModel userInfo);
        Task<bool> RegisterUserAsync(string email, string password);
        Task<bool> AuthenticateAsync(string email, string password);
        ActionResult<ProfileToken> GenerateToken(LoginViewModel userInfo);
    }
}
