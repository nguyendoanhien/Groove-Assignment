using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models.Note;
using PersonalNotesAPI.Services;
using PersonalNotesAPI.Services.Interface;

namespace PersonalNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[AutoValidateAntiforgeryToken]
    public class NotesController : Controller
    {
        private readonly INotesService _noteService;
        private readonly IUserResolverService _userResolverService;


        public NotesController(INotesService noteService, IUserResolverService userResolverService)
        {
            _noteService = noteService;
            _userResolverService = userResolverService;
        }

        [HttpGet("")]
        public IEnumerable<FullModel> GetNotes()
        {
            var result = _noteService.GetNoteListFullModel();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetNote(int id)
        {
            var data = _noteService.GetNoteForEdit(id);
            if (data != null && _userResolverService.CurrentUserName() == data.CreatedBy)
                return Ok(data);
            
            return BadRequest("Ban ko co quyen");
        }

        [HttpPut("{id}")]
        public IActionResult EditNote(int id, [FromBody] EditModel note)
        {


            var data = _noteService.GetNoteForEdit(id);
            if (data == null || _userResolverService.CurrentUserName() != data.CreatedBy)
                return BadRequest("Ban ko co quyen");

            if (id != note.Id)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                var isExisting = _noteService.CheckExisting(id);
                if (!isExisting)
                {
                    return null;
                }

                _noteService.EditNote(note);
                 return Ok(note);
            }

            return BadRequest("Loi");
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] CreateModel note)
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
            var data = _noteService.GetNoteForEdit(id);
            if (data == null || _userResolverService.CurrentUserName() != data.CreatedBy)
                return BadRequest("Ban ko co quyen");
            var isExisting = _noteService.CheckExisting(id);
            if (!isExisting)
            {
                return new NotFoundResult();
            }

            _noteService.DeleteNote(id);
            return Ok();
        }
    }
}