using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Service;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebooksController : Controller
    {
        private readonly INotebooksRepository _notebooksRepository;

        public NotebooksController(INotebooksRepository notebooksRepository)
        {
            _notebooksRepository = notebooksRepository;
        }
        // GET: api/Notebooks
        [HttpGet]
        public List<Notebook> Get()
        {
            return _notebooksRepository.Notebooks;
        }

        // GET: api/Notebooks/5
        [HttpGet("{id}", Name = "GetNotebook")]
        public Notebook Get(int id)
        {
            return _notebooksRepository[id];
        }

        // POST: api/Notebooks
        [HttpPost]
        public Notebook Post([FromBody] Notebook value)
        {
            if(ModelState.IsValid)
            {
                _notebooksRepository.AddNotebook(value);
            }
            return value;
        }

        // PUT: api/Notebooks/5
        [HttpPut("{id}")]
        public void Put([FromBody] Notebook value)
        {
            _notebooksRepository.UpdateNotebook(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Notebook notebook = _notebooksRepository.Notebooks.FirstOrDefault(x => x.Id == id);
            if (notebook!=null)
            {
                _notebooksRepository.DeleteNotebook(id);
                Content("Deleted");
            }
        }
    }
}
