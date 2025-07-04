using MessManagemetSystem.API;
using MessManagemetSystem.API.CustomExceptionHandling;
using MessManagemetSystem.API.DependencyInjections;
using MessManagemetSystem.API.Extensions;
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
builder.Services.AddHostedService<AttendanceSyncService>(); //Background Services


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
//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);
//builder.Services.AddLogging();


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


app.UseMiddleware<ErrorHandlerMiddleware>(); // Global Exception Handling
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
