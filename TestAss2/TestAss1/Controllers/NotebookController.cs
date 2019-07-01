using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAss1.Fillter;
using TestAss1.Models;
using TestAss1.Services;

namespace TestAss1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotebookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotebook _notebook;
        private readonly UserManager<ApplicationUser> _userManager;
        public NotebookController(IMapper mapper, INotebook notebook,UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _notebook = notebook;
            _userManager = userManager;

        }

        //[VersionFillter]
        [HttpGet]
        public IEnumerable<NotebookViewModel> getAllNotebook()
        {
            var notebookList = _notebook.getAllNotebook();
            return _mapper.Map<List<NotebookViewModel>>(notebookList);
        }

        [HttpPost]
        public NotebookViewModel Add(NotebookViewModel notebookViewModel)
        {
            Notebook notebook = _mapper.Map<Notebook>(notebookViewModel);
            var item = _notebook.Add(notebook);
            return _mapper.Map<NotebookViewModel>(item);
        }

        [HttpDelete("{id}")]
        public NotebookViewModel Delete(int Id)
        {
            Notebook notebook = _notebook.Delete(Id);
            return _mapper.Map<NotebookViewModel>(notebook);
        }

        [HttpPut]
        public NotebookViewModel Update(NotebookViewModel notebookViewModel)
        {
            var item = _mapper.Map<Notebook>(notebookViewModel);
            Notebook notebook = _notebook.Update(item);
            return _mapper.Map<NotebookViewModel>(notebook);
        }
    }
}