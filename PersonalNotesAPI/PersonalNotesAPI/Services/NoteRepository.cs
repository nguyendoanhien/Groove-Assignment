using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.DataBase;
using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PersonalNotesAPI.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly DataContext _context;

        public NoteRepository (DataContext context)
        {
            _context = context;
        }

        public Note CreateNote(Note note)
        {
            note.CreatedBy = "";
            note.CreatedOn = DateTime.Now;
            note.NotebookId = 4;
            note.Finished = true;
            _context.Add(note);
            _context.SaveChanges();
            return note;
        }

        public Note GetNote(int Id)
        {
            return _context.Notes.Find(Id);
        }

        public IEnumerable<Note> GetNoteList()
        {
            return _context.Notes.ToList();
        }

        public Note RemoveNote(int Id)
        {
            Note note = _context.Notes.Find(Id);
            note.Deleted = true;
            _context.Notes.Attach(note);
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
            return note;
        }

        public Note UpdateNote(Note noteChange)
        {
                Note note = _context.Notes.Find(noteChange.Id);
                note.Title = noteChange.Title;
                note.Description = noteChange.Description;
                note.Finished = noteChange.Finished;
                note.Deleted = noteChange.Deleted;
                note.UpdatedBy = "";
                note.UpdatedOn = DateTime.Now;
                _context.Notes.Attach(note);
                _context.Entry(note).State = EntityState.Modified;
                _context.SaveChanges();
                return note;
        }
    }
}
