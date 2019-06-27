using AutoMapper;
using PersonalNotesDAL.Models;
using PersonalNotesDAL.Models.Note;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalNotesDAL.Mapper
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
