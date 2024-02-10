using Mango.Services.AuthAPI.Models.Dto;

namespace Mango.Services.AuthAPI.Services.Interface
{
    public interface IAuthService
    {
        Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginResponseDto loginResponseDto);
    }
}
