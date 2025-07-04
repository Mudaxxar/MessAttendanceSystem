namespace MessManagementSystem.MVC.Configuration
{
    public static class AppSettingVariable
    {
        public static void RegisterAppSetting(this IServiceCollection service, IConfiguration configuration, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                configuration.GetSection("SiteConfiguration")["ApiBaseUrl"] = "https://localhost:7090/api/";
                //configuration.GetSection("SiteConfiguration")["ApiBaseUrl"] = "https://messapi.sossurgical.net/api/";

            }
            else
            {
                configuration.GetSection("SiteConfiguration")["ApiBaseUrl"] = "https://messapi.sossurgical.net/api/";
            }
        }
    }
}
