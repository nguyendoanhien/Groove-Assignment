using Microsoft.Extensions.DependencyInjection;
using PersonalNotesAPI.Uow;
using PersonalNotesAPI.Uow.Interface;

namespace PersonalNotesAPI.Configurations
{
    public partial class DiConfiguration
    {
        public static void RegisterUows(IServiceCollection services)
        {
            services.AddScoped(typeof(IUowBase<>), typeof(UowBase<>));
        }
    }
}
