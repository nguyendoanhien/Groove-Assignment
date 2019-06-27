using AutoMapper;
using PersonalNotesAPI.DataBase;
using PersonalNotesAPI.Entity;
using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        
        public AutoMapperProfile()
        {
            CreateMap<NoteEntity, Note>();
            CreateMap<NoteBookEntity, Notebook>();
        }
    }
}
