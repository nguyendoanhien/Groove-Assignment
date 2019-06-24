using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class NotesService : INotesRepository
    {
        private DataContext _db;
        public NotesService(DataContext db)
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

        public Note UpdateNote(Note note) => AddNote(note);
        //{
        //    Note newNote = _db.FirstOrDefault(x => x.Id == note.Id);
        //    _db.Remove(note);
        //    _db.Add(newNote);
        //    return newNote
        //}
    }
}
