using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PersonalNotesAPI.Controllers;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Mapping;
using PersonalNotesAPI.Middleware;
using PersonalNotesAPI.Models;

using PersonalNotesAPI.Repositories;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Service;
using PersonalNotesAPI.Service.Interface;

namespace PersonalNotesAPI
{
    public partial class Startup
    {
        private IConfiguration _Configuration;

        public object DiConfiguration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
            AutoMapperConfiguration.Configure();

        }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });







            services.AddScoped<INotesService, Noteservice>();
            services.AddScoped<INotesRepositories, ReNotes>();
            services.AddScoped< IUserResolverService ,UserResolverService > ();

            services.AddCors(o => o.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));


            //services.AddScoped<INotesRepositories, ReNotes>();
            //services.AddScoped<INotesService, Noteservice>();
            RegisterAuth(services);
            RegisterIdentity(services);
            RegisterAutoMapperProfiles(services);

            //DiConfiguration.Register(services);

            services.AddScoped<VersionFilter>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("AllowAll");
            RegisterMiddlewares(app);
            app.UseMiddleware<MiddlewareChrome>();
            //app.UseMiddleware<AuthorizationTokenCheckMiddleware>();


            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
         
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
