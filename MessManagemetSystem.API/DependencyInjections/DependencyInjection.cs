using MessManagemetSystem.API.DbContext;
using MessManagemetSystem.API.Identity;
using MessManagemetSystem.API.MApping;
using MessManagemetSystem.API.Repository.GenericRepository;
using MessManagemetSystem.API.Repository.IRepositories;
using MessManagemetSystem.API.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using FluentValidation.AspNetCore;
using MessManagemetSystem.API.Services.IService;
using MessManagemetSystem.API.Services.Service;
using MessManagemetSystem.API.Extensions;

namespace MessManagemetSystem.API.DependencyInjections
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>()


                .AddScoped<IPermissionsRepository, PermissionsRepository>()
                .AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>()
                .AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IRolePermissionsRepository, RolePermissionsRepository>()
                .AddScoped<IMenuRepository, MenuRepository>()
                .AddScoped<IAccountsService, AccountsService>()
                ;

            services.AddDbContext<MessDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // For Identity
            services.AddIdentity<ApplicationUser, UserRoles>()
                .AddEntityFrameworkStores<MessDbContext>()
                .AddDefaultTokenProviders();
            // Adding Authentication

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT-Authentication:ValidAudience"],
                    ValidIssuer = Configuration["JWT-Authentication:ValidIssuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT-Authentication:Secret"])),
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Mess.ERP API",
                    Version = "v1",
                    Description = "An API to perform Nugets operations",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Mudassar mushtaq",
                    //    Email = "mudassarmushtaq143@gmail.com",
                    //    Url = new Uri("https://twitter.com/jwalkner"),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Nugets API LICX",
                    //    Url = new Uri("https://example.com/license"),
                    //}
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        public static IServiceCollection RegisterBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return
            services
            .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
            .AddAutoMapper(typeof(MappingConfiguration))
               .AddScoped<IUnitOfWork, UnitOfWork>()

                 .AddHttpClient()
                 .AddFluentValidationAutoValidation()// fluent Validations
                 .AddFluentValidationClientsideAdapters() // Fluent Validations
                 .AddScoped<IUserService, UserService>()
                 .AddScoped<IRolesService, RolesService>()
                 .AddScoped<IRolePermissionsService, RolePermissionsService>()
                 .AddScoped<IPermissionsService, PermissionsService>()
                .AddScoped<IMenuService, MenuService>()
                .AddScoped<IAttendanceService, AttendanceService>()
                .AddScoped<IExpenseHeadsService, ExpenseHeadsService>()
                .AddScoped<IExpenseService, ExpenseService>()

                 ;

        }
    }
}
