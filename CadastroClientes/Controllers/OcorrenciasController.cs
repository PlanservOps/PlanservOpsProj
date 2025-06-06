using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "AdminMaster,GerenteOperacional")]
    public class OcorrenciasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOcorrencias()
        {
            return Ok("Você tem acesso a esta rota!");
        }
    }
}

