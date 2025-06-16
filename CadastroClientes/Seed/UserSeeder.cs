using Microsoft.AspNetCore.Identity;

namespace CadastroCliente.Seed
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            var users = new[]
            {
                new { Nome = "Delano Thomaz", Email = "delano@planservrh.com.br", Senha = "rp_p2WJVNe", Role = "Diretoria" },
                new { Nome = "Emelly Lima", Email = "emelly.planservrh@gmail.com", Senha = "wrl_p8$aIi", Role = "Diretoria" },
                new { Nome = "Luiza Santos", Email = "luiza@planservrh.com.br", Senha = "T0Xm&hIDQt", Role = "Diretoria" },
                new { Nome = "João Ramalho", Email = "joao.planservrh@gmail.com", Senha = "xgACk4yux=", Role = "GerenteOperacional" },
                new { Nome = "Deisy", Email = "deisyara@planservrh.com.br", Senha = "vdw+Vj_Dvz", Role = "AdministradorInterno" },
                new { Nome = "Igor Rocha", Email = "lordao.planserv@gmail.com", Senha = "fs2@S6bQgH", Role = "Fiscal" },
            };

            foreach (var u in users)
            {
                var existingUser = await userManager.FindByEmailAsync(u.Email);
                if (existingUser == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = u.Email,
                        Email = u.Email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, u.Senha);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, u.Role);
                    }
                    else
                    {
                        // Log errors (opcional)
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Erro ao criar usuário {u.Email}: {error.Description}");
                        }
                    }
                }
            }
        }
    }
}
