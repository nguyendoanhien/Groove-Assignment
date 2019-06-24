using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Services;
using PersonalNotesAPI.ViewModels;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        public NotesController(INotesService notesService)
        {

            _notesService = notesService;
        }

        #region snippet_GetAll
        [HttpGet]
        public IEnumerable<Note> GetAll()
        {
            return _notesService.GetList();
        }

        #region snippet_GetByID
        [HttpGet("{id}", Name = "Getnote")]
        public IActionResult GetById(int id)
        {
            var item = _notesService.GetSingleById(id);
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
        public IActionResult Create([FromBody] Note item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var newItem = _notesService.CreateNew(item);


            return CreatedAtRoute("Getnote", new { id = newItem.Id }, newItem);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] NoteVM item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var note = _notesService.GetSingleById(id);
            if (note == null)
            {
                return NotFound();
            }

            //note.IsComplete = item.IsComplete;
            //note.Name = item.Name;

            _notesService.Upate(item);

            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = _notesService.GetSingleById(id);
            if (note == null)
            {
                return NotFound();
            }

            _notesService.Delete(id);

            return new NoContentResult();
        }
        #endregion

    }
}