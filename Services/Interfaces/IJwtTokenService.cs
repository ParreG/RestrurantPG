using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(Admin admin);

    }
}
