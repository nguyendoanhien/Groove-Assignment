using PersonalNotesAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using PersonalNotesAPI.Services.Interface;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            //services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IUserResolverService, UserResolverService>();
            services.AddScoped<INotesService, NotesService>();
        }
    }
}