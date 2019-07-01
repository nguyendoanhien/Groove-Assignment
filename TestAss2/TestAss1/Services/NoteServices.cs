using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Data;
using TestAss1.Models;

namespace TestAss1.Services
{
    public class NoteServices : INote
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserResolverService _userResolverService;
        public NoteServices(DataContext context,IUnitOfWork unitOfWork,IUserResolverService userResolverService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userResolverService = userResolverService;
        }
        public Note Add(Note note)
        {
            note.CreatedBy = _userResolverService.CurrentUserName();
            note.CreatedOn = DateTime.Now;
            _context.Notes.Add(note);

            _unitOfWork.Complete();
            return note;
        }

        public Note Delete(int Id)
        {
            Note note = _context.Notes.Find(Id);
            note.Deleted = true;
            _context.Notes.Attach(note);
            _context.Entry(note).State = EntityState.Modified;

            _unitOfWork.Complete();
            return note;
        }

        public IEnumerable<Note> getAllNote()
        {
            return _context.Notes.Where(x => x.CreatedBy == _userResolverService.CurrentUserName() && x.Deleted == false).ToList();
        }

        public Note GetNote(int Id)
        {
            Note note = _context.Notes.Find(Id);
            return note;
        }

        public Note Update(Note noteChange)
        {
            Note note = _context.Notes.Find(noteChange.Id);
            note.Title = noteChange.Title;
            note.Description = noteChange.Description;
            note.Finished = noteChange.Finished;
            note.Deleted = noteChange.Deleted;
            note.UpdatedBy = _userResolverService.CurrentUserName();
            note.UpdatedOn = DateTime.Now;
            _context.Notes.Attach(note);
            _context.Entry(note).State = EntityState.Modified;

            _unitOfWork.Complete();
            return note;
        }
    }
}
