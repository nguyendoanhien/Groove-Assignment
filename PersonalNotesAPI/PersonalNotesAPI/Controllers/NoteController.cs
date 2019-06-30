using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Filters;
using PersonalNotesAPI.Models.Note;
using PersonalNotesAPI.Services.Interface;

namespace PersonalNotesAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        public readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("")]
        public IEnumerable<FullNote> GetNotes()
        {
            var result = _noteService.GetNoteListFullModel();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<NoteEntity> GetNote(int id)
        {
            NoteEntity note = _noteService.GetNoteById(id);
            if (note != null)
            { return Ok(note); }
            return new NotFoundObjectResult("Không tồn tại");
        }

        [HttpPut("{id}")]
        public EditNote EditNote(int id, [FromBody] EditNote note)
        {
            if (id != note.Id)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                var isExisting = _noteService.GetNoteById(id);
                if (isExisting == null)
                {
                    return null;
                }

                _noteService.UpdateNote(note);
                return note;
            }

            return null;
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] CreateNote note)
        {
            if (ModelState.IsValid)
            {
                _noteService.AddNote(note);
            }
            else
            {
                return new BadRequestResult();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var isExisting = _noteService.GetNoteById(id);
            if (isExisting == null)
            {
                return new NotFoundResult();
            }

            _noteService.DeleteNote(id);
            return Ok();
        }
    }
}
