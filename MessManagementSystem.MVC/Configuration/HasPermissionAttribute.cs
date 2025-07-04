using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MessManagementSystem.MVC.Configuration;

public class HasPermissionAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _requiredPermission;

    public HasPermissionAttribute(string requiredPermission)
    {
        _requiredPermission = requiredPermission;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Not logged in
        if (!ConfigService.IsUserLoggedIn())
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        // Admin can access everything
        if (ConfigService.HasPermission("Admin"))
            return;

        // If missing required permission
        if (!ConfigService.HasPermission(_requiredPermission))
        {
            context.Result = new RedirectToActionResult("Unauthorized", "Account", null);
        }
    }
}
