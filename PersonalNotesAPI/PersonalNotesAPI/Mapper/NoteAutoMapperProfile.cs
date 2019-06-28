using AutoMapper;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Mapper
{
    public class NoteAutoMapperProfile : Profile
    {
        public NoteAutoMapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<NoteEntity, IndexModel>();
            CreateMap<NoteEntity, EditModel>();
            CreateMap<NoteEntity, FullModel>();

            CreateMap<CreateModel, NoteEntity>();
            CreateMap<EditModel, NoteEntity>();

        }
    }
}
