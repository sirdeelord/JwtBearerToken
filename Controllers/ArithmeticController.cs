
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwtBearerToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArithmenticController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [Route("sumValues")]
        public IActionResult Sum([FromQuery( Name = "ValOne" )] int valOne, [FromQuery( Name = "ValTwo" )] int valTwo)
        {
            return Ok(valOne + valTwo);
        }
    }
}