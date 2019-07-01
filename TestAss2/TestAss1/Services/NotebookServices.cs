using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Data;
using TestAss1.Models;

namespace TestAss1.Services
{
    public class NotebookServices : INotebook
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserResolverService _userResolverService;
        public NotebookServices(IMapper mapper,DataContext context,IUnitOfWork unitOfWork,IUserResolverService userResolverService)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userResolverService = userResolverService;

        }

        public Notebook Add(Notebook notebook)
        {
            notebook.CreatedBy = _userResolverService.CurrentUserName();
            notebook.CreatedOn = DateTime.Now;
            _context.Notebooks.Add(notebook);

            _unitOfWork.Complete();
            return notebook;

        }

        public Notebook Delete(int Id)
        {
            Notebook notebook = _context.Notebooks.Find(Id);
            notebook.Deleted = true;
            _context.Notebooks.Attach(notebook);
            _context.Entry(notebook).State = EntityState.Modified;
            var noteList = _context.Notes.Where(item => item.NotebookId == Id);
            foreach(var note in noteList)
            {
                note.Deleted = true;
                _context.Notes.Attach(note);
                _context.Entry(note).State = EntityState.Modified;
            }

            _unitOfWork.Complete();
            return notebook;

        }

        public IEnumerable<Notebook> getAllNotebook()
        {

            return _context.Notebooks.Where(x => x.CreatedBy == _userResolverService.CurrentUserName()).ToList();

        }

        public Notebook GetNotebook(int Id)
        {
            Notebook notebook = _context.Notebooks.Find(Id);
            return notebook;
        }

        public Notebook Update(Notebook notebookChange)
        {
            Notebook notebook = _context.Notebooks.Find(notebookChange.Id);
            notebook.Name = notebookChange.Name;
            notebook.UpdatedBy = _userResolverService.CurrentUserName();
            notebook.UpdatedOn = DateTime.Now;
            _context.Notebooks.Attach(notebook);
            _context.Entry(notebook).State = EntityState.Modified;

            _unitOfWork.Complete();
            return notebook;

        }
    }
}
