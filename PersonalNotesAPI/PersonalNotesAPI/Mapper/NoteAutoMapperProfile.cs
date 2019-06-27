using AutoMapper;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models;
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
            CreateMap<NoteEntity, Note>();
        }
        
    }
}
