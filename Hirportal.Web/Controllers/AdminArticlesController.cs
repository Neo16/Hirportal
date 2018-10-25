using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hirportal.Web.WebServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminArticlesController : Controller
    {
        private readonly CurrentUserService currentUserService;

        public AdminArticlesController(CurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }

        [Route("authtest")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AuthTest()
        {
            var user = await currentUserService.GetCurrentUser();
            return Ok();
        }
    }
}