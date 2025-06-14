﻿
using Microsoft.AspNetCore.Identity;

namespace CadastroClientes.Services
{
    public class AuthAccessService : IAuthAccess
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AuthAccessService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Autheticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result.Succeeded;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
