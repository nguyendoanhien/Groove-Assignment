using Microsoft.Extensions.DependencyInjection;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterUows(services);
            RegisterServices(services);
        }
    }
}
