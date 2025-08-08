using MessManagemetSystem.API;
using MessManagemetSystem.API.BackgroundServices;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.DependencyInjections;
using MessManagemetSystem.API.Extensions;
using Microsoft.Win32;
using Quartz;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<EnviornmentSettingModel>(builder.Configuration.GetSection("EnviornmentSetting"));

// Access and modify the value of isDevelopmentMode

// Add services to the container.

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
	});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddMvc()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
		options.JsonSerializerOptions.PropertyNamingPolicy = null; // or CamelCaseNamingPolicy if needed
	});
builder.Services.RegisterAppSettingVariable(builder.Configuration, builder.Environment);// configure first 
builder.Services.RegisterDALDependencies(builder.Configuration);
builder.Services.RegisterBLLDependencies(builder.Configuration);
//builder.Services.AddHostedService<AttendanceSyncService>(); //Background Services


// Swagger Authentication & Sawagger Documentation

//SeriLog


var configuration = new ConfigurationBuilder()
		   .AddJsonFile("appsettings.json")
		   .AddJsonFile("serilog.json", optional: true, reloadOnChange: true) // Add serilog.json
		   .Build();




//var logger = new Serilog.LoggerConfiguration()
//	.ReadFrom.Configuration(configuration)
//	.Enrich.FromLogContext()
//	.CreateLogger();
//builder.Logging.AddSerilog(logger);
//builder.Logging.ClearProviders();
//builder.Services.AddLogging();



//Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
	configuration.ReadFrom.Configuration(context.Configuration));



// Add Quartz services
// Register your job and trigger using DI-friendly Quartz config
builder.Services.AddQuartz(q =>
{
    // Register the job with its identity
    var jobKey = new JobKey("QuartzBackgroundJob");
q.AddJob<QuartzBackgroundJob>(opts => opts.WithIdentity(jobKey));

// Schedule the job with a CRON trigger (runs daily at 3:00 AM)
q.AddTrigger(opts => opts
	.ForJob(jobKey)
	.WithIdentity("QuartzBackgroundJob-trigger")
	.WithCronSchedule("0 35 2 * * ?", x => x
		.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Asia/Karachi")))); //0>= Second, 0=> mintues, 21=> hours, *=> dayof month, *=> every month, ?=> dayof week
});


// Add Quartz hosted service
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var app = builder.Build();

app.UseSwagger();
//swagger Documentation

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwaggerUI();
}
else
{
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mess API V1");
		c.DocumentTitle = "Mess Web Api";
		c.DocExpansion(DocExpansion.None);
		c.RoutePrefix = string.Empty;
	});
}

app.UseCors(options => options.WithOrigins("https://kmsmc.sossurgical.net")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin());
//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

app.UseMiddleware<ErrorHandlerMiddleware>(); // Global Exception Handling
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
