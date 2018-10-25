using Hirportal.Bll.Dtos.Account;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hirportal.Web.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountApiController(
            ITokenService tokenService,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]      
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            //todo elszáll ha nincs ilyen user. 
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return BadRequest("Invalid username or password.");
            }
            var token = await _tokenService.GetTokenForUserAsync(user);
            return Ok(token);
        }
    }
}
