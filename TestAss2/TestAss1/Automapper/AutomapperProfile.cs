using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Models;

namespace TestAss1.Automapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Notebook, NotebookViewModel>().ReverseMap();
            CreateMap<Note, NoteViewModel>().ReverseMap();

        }
    }
}
