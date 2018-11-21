using Hirportal.Bll.Dtos.Account;
using Hirportal.Model;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface ITokenService
    {
        Task<LoginResultDto> GetTokenForUserAsync(ApplicationUser user);
    }
}
