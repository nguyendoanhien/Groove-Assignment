using Microsoft.Extensions.DependencyInjection;
using PersonalNotesDAL.Repositories;
using PersonalNotesDAL.Repositories.Interface;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,,>), typeof(GenericRepository<,,>));
        }
    }
}
