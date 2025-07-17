namespace MessManagemetSystem.API.Extensions
{
	public static class AppSettingVariable
	{
		public static void RegisterAppSettingVariable(this IServiceCollection services, IConfiguration Configuration, IHostEnvironment env)
		{

			if (env.IsDevelopment())
			{
				Configuration.GetSection("ConnectionStrings")["DefaultConnection"] = "Server=Mudassar-PC\\SQLEXPRESS;Database=MessManagement;Integrated Security=true;Trust Server Certificate=true";
				//Configuration.GetSection("ConnectionStrings")["DefaultConnection"] = "Server = 216.158.231.74;Database= KMSMC-Mess;User Id= SOS_Pearl;password=Qf594n#g3;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True";

            }
            else
			{
				Configuration.GetSection("ConnectionStrings")["DefaultConnection"] = "Server = 216.158.231.74;Database= KMSMC-Mess;User Id= SOS_Pearl;password=Qf594n#g3;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True";

            }
			services.Configure<EnviornmentSettingModel>(Configuration.GetSection("EnviornmentSetting"));

		}
	}
}
