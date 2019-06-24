using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using PersonalNotes.Service;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Data.Infrastructure;
using PersonalNotesAPI.Data.Repositories;
using PersonalNotesAPI.Mappings;
using System.Reflection;

namespace PersonalNotesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfiguration.Configure();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    (_) => "The field is required.");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PersonalNotesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
  
            // Repos
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(NotebookRepos)))
                .Where(x => x.Name.EndsWith("Repos"))
                .AsPublicImplementedInterfaces();
            // Serivce
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(NotebookService)))
                .Where(x => x.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
