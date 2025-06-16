using Microsoft.AspNetCore.Identity;

namespace CadastroCliente.Seed
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            var users = new[]
            {
                new { Nome = "Delano Thomaz", Email = "delano@planservrh.com.br", Senha = "Z1QSGTk8l1", Role = "Diretoria" },
                new { Nome = "Emelly Lima", Email = "emelly.planservrh@gmail.com", Senha = "Ymeqli1JIG", Role = "Diretoria" },
                new { Nome = "Luiza Santos", Email = "luiza@planservrh.com.br", Senha = "Y9ZHE0QMWX", Role = "Diretoria" },
                new { Nome = "João Ramalho", Email = "joao.planservrh@gmail.com", Senha = "zis6Cwyv1U", Role = "GerenteOperacional" },
                new { Nome = "Deisy", Email = "deisyara@planservrh.com.br", Senha = "YBMs7o49Xa", Role = "AdministradorInterno" },
                new { Nome = "Igor Rocha", Email = "lordao.planserv@gmail.com", Senha = "zLY1ALa1xS", Role = "Fiscal" },
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
