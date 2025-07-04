using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MessManagementSystem.MVC.Configuration;
using Microsoft.AspNetCore.Authorization;

public class RequireLoginFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Skip if [AllowAnonymous] is applied
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata
            .OfType<AllowAnonymousAttribute>().Any();

        if (allowAnonymous)
            return;

        // Redirect if not logged in
        if (!ConfigService.IsUserLoggedIn())
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }
}
