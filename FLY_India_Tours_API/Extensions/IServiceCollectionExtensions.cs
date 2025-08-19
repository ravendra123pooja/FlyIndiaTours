using Infrastructure;
using Infrastructure.UnityOfWork.Interfaces;
using Infrastructure.UnityOfWork.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Service.Account;
using Service.JWTAuthenticationManager;
using Infrastructure.EF;
using Service.CountryService;
using Service.RoleService;
using Service.UserMasterService;
using Service.DesignationService;
using Service.CompanyService;


namespace FLY_India_Tours_API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlyIndiaDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("flyinizz_FlyIndiaTours"),
                    sqlserverOptions => sqlserverOptions.CommandTimeout(120));

                });
            services.AddScoped<Func<FlyIndiaDbContext>>((provider) => () => provider?.GetService<FlyIndiaDbContext>()!);
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSetting = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var key = Encoding.UTF8.GetBytes(appSetting?.SecurityKey);
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.ClaimsIssuer = appSetting?.Issuer;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = appSetting?.Issuer,

                    ValidateAudience = true,
                    ValidAudience = appSetting?.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
        public static IServiceCollection AddSingletonService(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<AppSettings>(configuration?.GetSection("AppSettings")!)
                //.AddSingleton<IUnitOfWorkAppSettings>(configuration?.GetSection(nameof(IUnitOfWorkAppSettings)).Get<IUnitOfWorkAppSettings>()!)
                ;
        }
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                 .AddScoped<ICurrentUserService, CurrentUserService>()
                 .AddScoped<IAccountService, AccountService>()
                 .AddScoped<ISecurityService, SecurityService>()
                .AddScoped<IJWTAuthenticationManager, JWTAuthenticationManager>()
                .AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>()
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<IRoleService, RoleService>()
                 .AddScoped<IUserMasterService, UserMasterService>()
                .AddScoped<IDesignationService, DesignationService>()
                 .AddScoped<ICompanyService, CompanyService>()
            ;
        }
        public static IServiceCollection AddSessionWithOptions(this IServiceCollection services)
        {
            return services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

        }
    }
}
