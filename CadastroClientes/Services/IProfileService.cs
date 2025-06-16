using CadastroClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Services
{
    public interface IProfileService
    {
        Task<TokenResponse> CreateUserAsync(RegisterViewModel model);
        Task<TokenResponse> LoginAsync(LoginViewModel userInfo);
        Task<bool> RegisterUserAsync(string email, string password);
        Task<bool> AuthenticateAsync(string email, string password);
        ActionResult<TokenResponse> GenerateToken(LoginViewModel userInfo);
    }
}
