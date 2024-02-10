using Mango.Services.AuthAPI.Models;

namespace Mango.Services.AuthAPI.Services.Interface
{
    public interface IJwtTokenGeneration
    {
        string GenerationToken(ApplicationUser applicationUser);
    }
}
