using AutoMapper;
using PersonalNotesAPI.Entity;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotesEntity, IndexModel>();
            CreateMap<NotesEntity, EditModel>();
            CreateMap<NotesEntity, FullModel>();

            CreateMap<CreateModel, NotesEntity>();
            CreateMap<EditModel, NotesEntity>();

        }
    }
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
        }
    }
}
