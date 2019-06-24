using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;

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
        public void Post([FromBody] Notebook value)
        {
            if(ModelState.IsValid)
            {
                _notebooksRepository.AddNotebook(value);
            }
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

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)");
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
