using CadastroCliente.Context;
using CadastroClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _context;
        public Task<bool> AuthenticateAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> CreateUserAsync(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }

        public ActionResult<TokenResponse> GenerateToken(LoginViewModel userInfo)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> LoginAsync(LoginViewModel userInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
