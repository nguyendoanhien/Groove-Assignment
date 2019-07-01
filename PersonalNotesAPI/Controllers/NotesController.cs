using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Version;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesRepository _notesRepository;
        public NotesController(INotesRepository In)
        {
            _notesRepository = In;
        }

        // GET: api/Notes
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _notesRepository.GetNotes();
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "Get1")]
        public Note Get(int id)
        {
            return _notesRepository.GetNote(id);
        }

        // POST: api/Notes
        [HttpPost]
        [VersionFilter]
        public void Post([FromBody] Note value)
        {
            _notesRepository.AddNotes(value);
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Note value)
        {
            _notesRepository.UpdateNotes(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _notesRepository.DeleteNote(id);
        }
    }
}
