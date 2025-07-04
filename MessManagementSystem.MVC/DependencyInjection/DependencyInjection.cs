using MessManagementSystem.MVC.Clients.Client;
using MessManagementSystem.MVC.Clients.IClients;
using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.Helper;
using MessManagementSystem.MVC.Services.IService;
using MessManagementSystem.MVC.Services.Service;

namespace MessManagementSystem.MVC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            return
                services
                .AddHttpClient()


                .AddScoped<ISiteConfiguration, SiteConfiguration>()
                .AddScoped<IHttpClientHelper, HttpClientHelper>()
                .AddScoped<IUserApiClient, UserApiClient>()
                .AddScoped<IRoleClient, RoleClient>()
                .AddScoped<IPermissionClient, PermissionService>()
                .AddScoped<IMenuClient, MenuClient>()
                .AddScoped<IStudentClient, StudentClient>()
                .AddScoped<ISummaryClient, SummaryClient>()
                .AddScoped<IExpenseHeadsClient, ExpenseHeadsClient>()
                .AddScoped<IExpenseClient, ExpenseClient>()

            //.AddHttpClient<IHttpClientHelper, HttpClientHelper>()
            ;
        }

    }
}
