using Microsoft.AspNetCore.Identity;

namespace BeeLineApi.Service
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user);
    }
}
