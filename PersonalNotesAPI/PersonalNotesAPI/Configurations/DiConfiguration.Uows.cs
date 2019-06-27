using Microsoft.Extensions.DependencyInjection;
using PersonalNotesDAL.Uow;
using PersonalNotesDAL.Uow.Interface;

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
