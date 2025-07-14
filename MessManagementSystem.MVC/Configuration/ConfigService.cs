using System.IdentityModel.Tokens.Jwt;

namespace MessManagementSystem.MVC.Configuration
{
    public static class ConfigService
    {
        public static void SetJwtToken(string jwtToken)
        {
            if (jwtToken != null)
            {
                AppContext.Current.Response.Cookies.Append("AspNetCore.Usk", jwtToken, new CookieOptions
                {
                    HttpOnly = true,
					Expires = DateTimeOffset.UtcNow.AddMinutes(30)
				});
            }
        }
        public static string GetJwtToken()
        {
            return AppContext.Current.Request.Cookies["AspNetCore.Usk"];
        }

        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(GetJwtToken());
        }
        public static void RemoveJwtToken()
        {
            if (!string.IsNullOrEmpty(GetJwtToken()))
            {
                AppContext.Current.Response.Cookies.Delete("AspNetCore.Usk");
            }
        }
        public static void SetUserId(int UserId)
        {
            if (UserId != 0)
            {
                AppContext.Current.Response.Cookies.Append("AspNetCore.NmIdent", UserId.ToString(), new CookieOptions
                {
                    HttpOnly = true
                });
            }
        }
        public static int GetUserId()
        {
            var userId = AppContext.Current.Request.Cookies["AspNetCore.NmIdent"];
            return userId != null ? Convert.ToInt32(userId) : 0;
        }

        public static void SetEmail(string email)
        {
            if (email != null)
            {
                AppContext.Current.Response.Cookies.Append("AspNetCore.Email", email, new CookieOptions
                {
                    HttpOnly = true
                });
            }
        }

        public static string GetEmail()
        {
            string email = AppContext.Current.Request.Cookies["AspNetCore.Email"];
            return email;
        }

        public static void Logout()
        {
            RemoveJwtToken();
            AppContext.Current.Response.Cookies.Delete("AspNetCore.NmIdent");
            AppContext.Current.Response.Cookies.Delete("AspNetCore.Email");
        }
        public static bool HasPermission(string permission)
        {
            var token = GetJwtToken();
            if (string.IsNullOrEmpty(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var hasPermission = jwtToken.Claims.Any(c =>
                (c.Type == "permission" || c.Type == "permissions") &&
                c.Value.Equals(permission, StringComparison.OrdinalIgnoreCase));

            return hasPermission;
        }

    }
}
