using AutoMapper;
using PersonalNotesAPI.Model.Models;
using PersonalNotesAPI.Models;

namespace PersonalNotesAPI.Mappings
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Notebook, NotebookVM>();
            CreateMap<Note, NoteVM>();
        }
    }
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<OrganizationProfile>();
            });
        }      
    }
}
