using MessManagementSystem.MVC.Configuration;
using MessManagementSystem.MVC.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<EnviornmentConfiguration>(builder.Configuration.GetSection("SiteConfiguration"));

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();

builder.Services.RegisterAppSetting(builder.Configuration, builder.Environment);// configure first 


//Register all Dependencies
builder.Services.RegisterDependencies();
// Add services to the container.



///register 
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new RequireLoginFilter()); // 👈 your global login filter
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


// Middleware to prevent caching of pages

app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});

// Configure AppContext with IHttpContextAccessor

MessManagementSystem.MVC.Configuration.AppContext.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
