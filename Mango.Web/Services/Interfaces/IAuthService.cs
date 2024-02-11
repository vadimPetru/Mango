
using Mango.Web.Models;
using Mango.Web.Models.AuthenticateDto;

namespace Mango.Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRole(RegistrationRequestDto registrationRequestDto);
        Task SignInUser(LoginResponseDto response);
    }
}
