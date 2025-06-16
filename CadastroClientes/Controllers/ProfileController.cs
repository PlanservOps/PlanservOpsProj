using CadastroClientes.Services;
using CadastroClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthAccess _authentication;

        public ProfileController(IConfiguration configuration, IAuthAccess authentication)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "As senhas não coincidem.");
                return BadRequest(ModelState);
            }

            var (success, errors) = await _authentication.RegisterUser(model.Email, model.Password);

            if (success)
            {
                return Ok($"Usuário {model.Email} criado com sucesso");
            }
            else
            {
                ModelState.AddModelError("Register", string.Join("; ", errors));
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var token = await _authentication.Authenticate(model.Email, model.Password);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Usuário ou senha inválidos");

            return Ok(new TokenResponse
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Email = model.Email,
                // O campo Role pode ser recuperado do token no frontend se necessário
            });
        }
    }
}
