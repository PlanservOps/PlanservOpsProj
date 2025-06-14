using CadastroClientes.Services;
using CadastroClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public async Task<ActionResult<ProfileToken>> CreateUser([FromBody] RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "As senhas não coincidem.");
                return BadRequest(ModelState);
            }
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {                
                return Ok($"Usuário {model.Email} criado com sucesso");
            }
            else
            {
                ModelState.AddModelError("Register", "Falha ao criar usuário. Verifique as credenciais.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ProfileToken>> Login([FromBody] LoginViewModel userInfo)
        {
            var result = await _authentication.Autheticate(userInfo.Email, userInfo.Password);

            if(result)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                ModelState.AddModelError("LoginUser", "Login inválido.");
                return BadRequest(ModelState);
            }
        }

        private ActionResult<ProfileToken> GenerateToken(LoginViewModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("planservToken", "Token Planserv"),
                new Claim(ClaimTypes.Role, userInfo.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(20));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new ProfileToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };
        }
    }
}
