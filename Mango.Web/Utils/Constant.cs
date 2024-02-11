namespace Mango.Web.Utils
{
    public static class Constant
    {
        private static string TOKEN_COOKIE = "JWTToken";

        public static string GetTokenCookie()
        {
            return TOKEN_COOKIE;
        }

    }
}
