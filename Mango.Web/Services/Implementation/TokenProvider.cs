using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Mango.Web.Services.Implementation
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ClearToken()
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(Constant.GetTokenCookie());
        }

        public string? GetToken()
        {
           return  _httpContextAccessor.HttpContext?.Request.Cookies.TryGetValue(Constant.GetTokenCookie(), out var token) is true ? token : null;
        }

        public void SetToken(string token)
        {
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(Constant.GetTokenCookie(), token,new CookieOptions() { HttpOnly=true , Secure = true, SameSite = SameSiteMode.Strict});
        }
    }
}
