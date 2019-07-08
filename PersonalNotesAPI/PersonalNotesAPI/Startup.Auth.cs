using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalNotesAPI.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotesAPI
{
    public partial class Startup
    {
        public void RegisterAuth(IServiceCollection services)
        {
            //if (int.TryParse(Configuration["SecurityConfigs:CookieTimeSpan"], out var cookieTimeSpan))
            //{
            //    cookieTimeSpan = cookieTimeSpan == 0 ? 20 : cookieTimeSpan;
            //}

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JWTAuthentication:Issuer"],
                        ValidAudience = Configuration["JWTAuthentication:Audience"],
                        IssuerSigningKey =
                            new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["JWTAuthentication:SecretKey"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };

                    cfg.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.NoResult();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "text/plain";
                            context.Response.WriteAsync("Token is not valid.").Wait();
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "text/plain";
                            context.Response.WriteAsync("Please provide token.").Wait();
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        public void RegisterIdentity(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
        }
    }
}