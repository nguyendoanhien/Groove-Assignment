
using Microsoft.Extensions.DependencyInjection;
using PersonalNotesDAL.Services;
using PersonalNotesDAL.Services.Interface;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            RegisterRepositories(services);
            RegisterUows(services);
            RegisterServices(services);
        }
    }
}