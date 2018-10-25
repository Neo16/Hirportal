using Hirportal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirportal.Web.WebServices
{
    public class CurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            var userClaimsPrincipal = httpContextAccessor.HttpContext.User;
            var user = await userManager.GetUserAsync(userClaimsPrincipal);
            return user;
        }
    }
}
