using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.DataBase;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Services;
using PersonalNotesAPI.VersionFilter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        INoteRepository _note;
        public NoteController(INoteRepository note)
        {
            _note = note;
        }
   
    // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            IEnumerable<Note> notes = _note.GetNoteList();
            return notes;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            Note note = new Note();
            note = _note.GetNote(id);
            return note;
        }

        // POST api/<controller>
        [ChromeFilter]
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _note.CreateNote(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            Note note = new Note();
            note.Id = id;
            note.Description = value;
            _note.UpdateNote(note);

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _note.RemoveNote(id);
        }
    }
}
