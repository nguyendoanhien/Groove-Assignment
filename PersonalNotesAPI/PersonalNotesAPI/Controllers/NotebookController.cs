using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Services;
using PersonalNotesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    public class NotebookController : Controller
    {
        INoteBookRepository _notebook; 
        public NotebookController(INoteBookRepository notebook)
        {
            this._notebook = notebook;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Notebook> Get()
        {
            IEnumerable<Notebook> notebooks = _notebook.GetNotebookList();
            return notebooks;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Notebook Get(int id)
        {
            return _notebook.GetNotebook(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string name)
        {
            _notebook.CreateNotebook(name);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string name)
        {
            Notebook newNotebook = new Notebook();
            newNotebook.Id = id;
            newNotebook.Name = name;
            _notebook.UpdateNotebook(newNotebook);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _notebook.RemoveNotebook(id);
        }
    }
}
