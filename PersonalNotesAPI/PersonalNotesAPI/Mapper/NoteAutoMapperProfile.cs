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
    public class NoteAutoMapperProfile: Profile
    {
        public NoteAutoMapperProfile()
        {
            CreateMap<NoteEntity, IndexNote>();
            CreateMap<NoteEntity, EditNote>();
            CreateMap<NoteEntity, FullNote>();
            CreateMap<CreateNote, NoteEntity>();
            CreateMap<EditNote, NoteEntity>();
        }
        
    }
}
