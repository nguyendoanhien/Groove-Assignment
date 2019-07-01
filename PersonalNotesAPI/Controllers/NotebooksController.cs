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
    public class NotebooksController : ControllerBase
    {
        private INotesBookRepository _notesBookRepository;

        public NotebooksController(INotesBookRepository notesBookRepository)
        {
            _notesBookRepository = notesBookRepository;

        }

        // GET: api/Notebooks
        [HttpGet]
        public IEnumerable<Notebook> Get()
        {
            return _notesBookRepository.GetNotebooks();
        }

        // GET: api/Notebooks/5
        [HttpGet("{id}", Name = "Get")]
        public Notebook Get(int id)
        {
            return _notesBookRepository.GetNoteBook(id);
        }

        // POST: api/Notebooks
        [HttpPost]
        [VersionFilter]
        public void Post([FromBody] Notebook value)
        {
            _notesBookRepository.AddNotebooks(value);
        }

        // PUT: api/Notebooks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Notebook value)
        {
           
            _notesBookRepository.UpdateNotebooks(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _notesBookRepository.DeleteNotebook(id);
        }
    }
}
