using Hirportal.Bll.Dtos.Account;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Hirportal.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Hirportal.Bll.Services
{
    public class TokenService : ServiceBase, ITokenService
    {
        private readonly JwtSecurityTokenHandler _accessTokenHandler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //Todo kitenni configba
        private const string tokenKey = "asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd_asd";

        public TokenService(
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accessTokenHandler = new JwtSecurityTokenHandler
            {
                TokenLifetimeInMinutes = (int)(TimeSpan.FromDays(1)).TotalMinutes
            };
        }

        public async Task<LoginResultDto> GetTokenForUserAsync(ApplicationUser user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "https://localhost:44381/",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity((await _signInManager.CreateUserPrincipalAsync(user)).Claims),
            };

            var tokenHandler = _accessTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var accessToken = _accessTokenHandler.WriteToken(tokenHandler);

            var res = await _userManager.SetAuthenticationTokenAsync(user, "Local", "Access", accessToken);

            if (res.Succeeded)
            {
                return new LoginResultDto
                {
                    UserToken = accessToken,
                    UserName = user.UserName
                };
            }

            else
            {
                return null;
            }
        }
    }
}
