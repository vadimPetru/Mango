using Mango.Web.Models;
using Mango.Web.Models.AuthenticateDto;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.Extensions.Options;
using Variables;

namespace Mango.Web.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        private readonly IOptions<ServiceUrls> _options;
        public AuthService(IBaseService baseService, IOptions<ServiceUrls> options)
        {
            _baseService = baseService;
            _options = options;
        }

        public async Task<ResponseDto?> AssignRole(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data = registrationRequestDto,
                Url = _options.Value.AuthAPI + "/api/auth/assignRole"
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data = loginRequestDto,
                Url = _options.Value.AuthAPI + "/api/auth/login"
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data = registrationRequestDto,
                Url = _options.Value.AuthAPI + "/api/auth/register"
            });
        }
    }
}
