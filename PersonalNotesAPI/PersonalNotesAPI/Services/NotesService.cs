using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonalNotesAPI.Models;
namespace PersonalNotesAPI.Service
{
    public class NotesService : INotesRepository
    {
        private DataProvider _db;
        public NotesService(DataProvider db)
        {
            _db = db;
        }
        public Note this[int id] => _db.notes.FirstOrDefault(x=>x.Id==id);

        public List<Note> Notes => _db.notes;

        public Note AddNote(Note note)
        {
            int NoteId = _db.notes.Max(x => x.Id) + 1;
            note.Id = NoteId;
            _db.notes.Add(note);
            return note;
        }

        public Note DeleteNote(int id)
        {
            Note note = _db.notes.FirstOrDefault(x => x.Id == id);
            _db.notes.Remove(note);
            return note;
        }

        public Note UpdateNote(Note note)
        {
            Note a = Notes.FirstOrDefault(x => x.Id == note.Id);
            a.Title = note.Title;
            a.NotebookId = note.NotebookId;
            a.UpdatedBy = "A";
            a.UpdatedOn = DateTime.Now;
            a.Description = note.Description;
            return a;
        }
        
    }
}
