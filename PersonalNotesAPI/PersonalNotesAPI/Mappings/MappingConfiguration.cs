using AutoMapper;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Mappings
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<NotebookVM, Notebook>();
            CreateMap<NoteVM, Note>();
        }
    }
    public static class MappingConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            });
        }
    }
}
