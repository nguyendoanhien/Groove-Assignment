using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalNotesAPI.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI
{
    public partial class Startup
    {
        public void RegisterAutoMapperProfiles(IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
