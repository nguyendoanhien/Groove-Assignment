using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.Models.Notes;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Service.Interface;

namespace PersonalNotesAPI.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _noteService;
       

        public NotesController(INotesService notesService)
        {
            _noteService = notesService;



        }
        [HttpGet("")]
        public IEnumerable<FullModel> GetNotes()
        {
            var result = _noteService.GetNoteListFullModel();
            return result;
        }

        //        [HttpGet("{id}")]
        //        public EditModel GetNote(int id)
        //        {
        //            var data = _noteService.GetNoteForEdit(id);
        //            return data;
        //        }

        //        [HttpPut("{id}")]
        //        public EditModel EditNote(int id, [FromBody] EditModel note)
        //        {
        //            if (id != note.Id)
        //            {
        //                return null;
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                var isExisting = _noteService.CheckExisting(id);
        //                if (!isExisting)
        //                {
        //                    return null;
        //                }

        //                _noteService.EditNote(note);
        //                return note;
        //            }

        //            return null;
        //        }

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

        //        [HttpDelete("{id}")]
        //        public IActionResult DeleteNote(int id)
        //        {
        //            var isExisting = _noteService.CheckExisting(id);
        //            if (!isExisting)
        //            {
        //                return new NotFoundResult();
        //            }

        //            _noteService.DeleteNote(id);
        //            return Ok();
        //        }
        //    }
        //}
    }
}