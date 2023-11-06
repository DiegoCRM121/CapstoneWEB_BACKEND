using CapstoneWEB.CORE.Settings;
using CapstoneWEB.CORE.Entities;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}
