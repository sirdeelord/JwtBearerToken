
using jwtBearerToken.AuthResources;
using jwtBearerToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwtBearerToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] AuthRequest authRequest)
        {
            var authManager = new AuthManager();
            var authResult = authManager.Authenticate(authRequest.Username, authRequest.Password);

            if (authResult == null)
                return BadRequest(new { message = "Username or password is incorrect" });           
            else
                return Ok(authResult);
        }
    }
}