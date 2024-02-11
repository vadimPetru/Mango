using Mango.Web.Models;
using Mango.Web.Models.AuthenticateDto;
using Mango.Web.Models.Enum;
using Mango.Web.Services.Implementation;
using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IAuthService service, ITokenProvider tokenProvider)
        {
            _service = service;
            _tokenProvider = tokenProvider;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var responseDto = await _service.LoginAsync(dto);

            if(responseDto != null && responseDto.IsSuccess)
            {
                var loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                await _service.SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(dto);
            }
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {Text=nameof(Role.Admin) , Value=nameof(Role.Admin)},
                new SelectListItem() {Text=nameof(Role.Customer), Value=nameof(Role.Customer)},
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDto dto)
        {
            ResponseDto result = await _service.RegisterAsync(dto);
            ResponseDto assignRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(dto.Role))
                {
                    dto.Role = nameof(Role.Customer);
                }
                assignRole = await _service.AssignRole(dto);
                if(assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration SuccesssFully";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {Text=nameof(Role.Admin) , Value=nameof(Role.Admin)},
                new SelectListItem() {Text=nameof(Role.Customer), Value=nameof(Role.Customer)},
            };

            ViewBag.RoleList = roleList;
            return View(dto);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
