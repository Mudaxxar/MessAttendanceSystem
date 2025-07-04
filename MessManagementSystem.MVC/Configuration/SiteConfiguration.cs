using Microsoft.Extensions.Options;

namespace MessManagementSystem.MVC.Configuration
{
    public class SiteConfiguration : ISiteConfiguration
    {
        private readonly EnviornmentConfiguration _enviornmentConfiguration;
        private readonly IConfiguration _configuration;
        private static string apiurl;
        public SiteConfiguration(IOptions<EnviornmentConfiguration> enviornmentConfiguration,
                                  IConfiguration configuration)
        {
            _enviornmentConfiguration = enviornmentConfiguration.Value;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("SiteConfiguration:ApiBaseUrl");
        }
        public string ApiBaseUrl { get; set; } = apiurl;


    }
}
