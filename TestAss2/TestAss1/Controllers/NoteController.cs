using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAss1.Models;
using TestAss1.Services;

namespace TestAss1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INote _note;
        public NoteController(IMapper mapper, INote note)
        {
            _mapper = mapper;
            _note = note;

        }

        [HttpGet]
        public IEnumerable<NoteViewModel> getAllNote()
        {
            var noteList = _note.getAllNote();
            return _mapper.Map<List<NoteViewModel>>(noteList);
        }

        [HttpGet("{id}")]
        public NoteViewModel GetNotebook(int Id)
        {
            Note note = _note.GetNote(Id);
            return _mapper.Map<NoteViewModel>(note); 
        }

        [HttpDelete("{id}")]
        public NoteViewModel Delete(int Id)
        {
            Note note = _note.Delete(Id);
            return _mapper.Map<NoteViewModel>(note);
        }

        [HttpPost]
        public NoteViewModel Add(NoteViewModel noteViewModel)
        {

            var item = _mapper.Map<Note>(noteViewModel);
            Note note = _note.Add(item);
            return _mapper.Map<NoteViewModel>(note);
        }

        [HttpPut]
        public NoteViewModel Update(NoteViewModel noteViewModel)
        {
            var item = _mapper.Map<Note>(noteViewModel);
            Note note = _note.Update(item);
            return _mapper.Map<NoteViewModel>(note);
        }
    }
}