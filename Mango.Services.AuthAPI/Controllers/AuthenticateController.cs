using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthService _authenticateService;
        protected ResponseDto _response;

        public AuthenticateController(IAuthService authenticateService)
        {
            _authenticateService = authenticateService;
            _response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authenticateService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var loginResponse = await _authenticateService.Login(request);

            if(loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "userName is inValid";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto request)
        {
            var loginResponse = await _authenticateService.AssignRole(request.Email ,request.Role);

            if (!loginResponse)
            {
                _response.IsSuccess = false;
                _response.Message = "Error Encounter";
                return BadRequest(_response);
            }
            return Ok(_response);
        }

    }
}
