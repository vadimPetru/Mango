using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
 
        public IActionResult Logout()
        {
            return View();
        }
    }
}
