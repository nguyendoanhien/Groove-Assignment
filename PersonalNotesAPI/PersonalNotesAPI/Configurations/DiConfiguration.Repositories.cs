using Microsoft.Extensions.DependencyInjection;
using PersonalNotesAPI.Repositories;
using PersonalNotesAPI.Repositories.Interface;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
