using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Shared.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CryptController(
        ICryptService cryptService) : ControllerBase
    {
        [HttpGet("crypt/{password}")]
        public IActionResult Crypt([FromRoute] string password)
        {
            var cryptResult = cryptService.HashPassword(password);
            return Ok(cryptResult);
        }

        [HttpPost("check/{password}")]
        public IActionResult Check(
            [FromBody] CheckRequest hashed, [FromRoute] string password)
        {
            var decryptResult = cryptService.VerifyHashedPassword(hashed.HashedPassword, password);
            return Ok(decryptResult);
        }
    }

    public record CheckRequest
    {
        public string HashedPassword { get; set; } =  string.Empty;
    }
}
