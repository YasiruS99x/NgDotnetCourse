using Microsoft.AspNetCore.Identity;

namespace CultureIntelligence.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
