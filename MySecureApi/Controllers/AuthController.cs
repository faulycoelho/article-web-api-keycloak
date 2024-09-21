using Microsoft.AspNetCore.Mvc;
using MySecureApi.Services;

namespace MySecureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KeycloakAuthService _keycloakAuthService;

        public AuthController(KeycloakAuthService keycloakAuthService)
        {
            _keycloakAuthService = keycloakAuthService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _keycloakAuthService.LoginAsync(request.Username, request.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}