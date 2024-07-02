using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProductInventoryManager.Application.Contracts.Identity;
using ProductInventoryManager.Application.Models.Identity;
using ProductInventoryManager.Identity.DbContext;
using ProductInventoryManager.Identity.Models;
using ProductInventoryManager.Identity.Services;
using System.Text;

namespace ProductInventoryManager.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            Console.WriteLine($"DbHost {dbHost}");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            Console.WriteLine($"DbName {dbName}");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            Console.WriteLine($"DbPassword {dbPassword}");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True;";
            Console.WriteLine($"ConnectionString {connectionString}");
            services.AddDbContext<ProductInventoryManagerIdentityDbContext>(options =>
               options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductInventoryManagerIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))

                };
            });

            return services;
        }
    }
}