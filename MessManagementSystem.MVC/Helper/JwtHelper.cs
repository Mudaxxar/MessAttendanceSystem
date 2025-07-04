// Helpers/JwtHelper.cs
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

public static class JwtHelper
{
    public static string GetClaimFromToken(string token, string claimType)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        return jwtToken?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;
    }
}
