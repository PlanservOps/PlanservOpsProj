
using Microsoft.AspNetCore.Identity;

namespace CadastroClientes.Services
{
    public class AuthAccessService : IAuthAccess
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthAccessService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Autheticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
