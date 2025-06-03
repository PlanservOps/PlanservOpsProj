using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciasController : ControllerBase
    {
        [Authorize(Roles = "AdminMaster,GerenteOperacional")]
        [HttpGet]
        public IActionResult GetOcorrencias()
        {
            return Ok("Você tem acesso a esta rota!");
        }
    }
}

