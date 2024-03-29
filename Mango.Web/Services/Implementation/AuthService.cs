﻿using Mango.Web.Models;
using Mango.Web.Models.AuthenticateDto;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Variables;

namespace Mango.Web.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        private readonly IOptions<ServiceUrls> _options;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IBaseService baseService, IOptions<ServiceUrls> options, IHttpContextAccessor httpContextAccessor)
        {
            _baseService = baseService;
            _options = options;
            _httpContextAccessor = httpContextAccessor;
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
            }, withBearer:false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data = registrationRequestDto,
                Url = _options.Value.AuthAPI + "/api/auth/register"
            }, withBearer: false);
        }

        public  async Task SignInUser(LoginResponseDto response)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(response.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim
                (JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(cliam => cliam.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim
                (JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(cliam => cliam.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim
                (JwtRegisteredClaimNames.Name, jwt.Claims.FirstOrDefault(cliam => cliam.Type == JwtRegisteredClaimNames.Name).Value));
            identity.AddClaim(new Claim
              (ClaimTypes.Name, jwt.Claims.FirstOrDefault(cliam => cliam.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(claim => claim.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        }
    }
}
