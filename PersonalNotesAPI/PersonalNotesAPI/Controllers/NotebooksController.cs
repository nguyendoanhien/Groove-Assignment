using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Services;
using PersonalNotesAPI.ViewModels;

namespace PersonalNotebooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebooksController : ControllerBase
    {
        private readonly INotebooksService _notebooksService;

        public NotebooksController(INotebooksService notebooksService)
        {

            _notebooksService = notebooksService;
        }

        #region snippet_GetAll
        [HttpGet]
        [Browser]
        public IEnumerable<Notebook> GetAll()
        {
            return _notebooksService.GetList();
        }

        #region snippet_GetByID
        [HttpGet("{id}", Name = "Getnotebook")]
        public IActionResult GetById(int id)
        {
            var item = _notebooksService.GetSingleById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #endregion
        #endregion
        #region snippet_Create
        [HttpPost]
        [Browser]
        public IActionResult Create([FromBody] Notebook item)
        {
            
           
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            var newItem = _notebooksService.CreateNew(item);


            return CreatedAtRoute("Getnotebook", new { id = newItem.Id }, newItem);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] NotebookVM item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var notebook = _notebooksService.GetSingleById(id);
            if (notebook == null)
            {
                return NotFound();
            }

            //notebook.IsComplete = item.IsComplete;
            //notebook.Name = item.Name;

            _notebooksService.Upate(item);

            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notebook = _notebooksService.GetSingleById(id);
            if (notebook == null)
            {
                return NotFound();
            }

            _notebooksService.Delete(id);

            return new NoContentResult();
        }
        #endregion
        //// GET: api/Notebookbooks
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //public IEnumerable<string> Get2()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// GET: api/Notebookbooks/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Notebookbooks
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Notebookbooks/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
