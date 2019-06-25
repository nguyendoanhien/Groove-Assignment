using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Service;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        // GET: api/Notes
        [HttpGet]
        public List<Note> Get()
        {
            return _notesRepository.Notes;
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "GetNote")]
        public Note Get(int id)
        {
            return _notesRepository[id];
        }

        // POST: api/Notes
        [HttpPost]
        public Note Post([FromBody] Note value)
        {
            _notesRepository.AddNote(value);
            return value;
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public Note Put([FromBody] Note value)
        {
            _notesRepository.UpdateNote(value);
            return value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _notesRepository.DeleteNote(id);
        }
    }
}
