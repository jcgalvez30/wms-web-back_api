using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CENARES.Infraestructure.Entity;
using CENARES.Infraestructure.Network.ADServices;
using System.DirectoryServices.AccountManagement;
using DataAccess_Seguridad.Data;
using DataAccess_Seguridad.Models;

namespace CENARES.LoginAD.Controllers
{
    [ApiController]
    [Route("cenares/wms/api/v1/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        { 
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> LoginAsync([FromBody] UserLoginBody settings)
        {
            bool isValid = false;
            string msg = string.Empty;
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, settings.DomainName, settings.Username, settings.Password))
                {
                    isValid = pc.ValidateCredentials(settings.Username, settings.Password);
                    if (isValid) {
                        var _token = TokenService.GenerateToken(settings.Username);
                        return Ok(new { token = _token});
                    } else
                        return BadRequest( new { message = "Credenciales incorrectas o Usuario no existe en AD", StatusCode=401 });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Dominio o DNS del Servidor no válido para las credenciales ingresadas: " + ex.Message, StatusCode = 400 });
            }
        }

    }
}
