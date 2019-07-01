using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models.Service
{
    public class NotesService : INotesRepository
    {
        private DataProvider _db;

        public DataProvider Db { get => _db; set => _db = value; }
        public NotesService(DataProvider db)
        {
            Db = db;
        }
        public Note AddNotes(Note note)
        {

            note.Id = Db.NoteList.Max(e => e.Id) + 1;
            Db.NoteList.Add(note);
            return note;

        }

        public Note DeleteNote(int id)
        {
            return Db.NoteList.FirstOrDefault(e => e.Id == id);
        }

        public Note GetNote(int Id)
        {
            return Db.NoteList.FirstOrDefault(e => e.Id == Id
               );
        }

        public IEnumerable<Note> GetNotes()
        {
            return Db.NoteList;
        }

        public Note UpdateNotes(Note Notechange)
        {
            Note note = Db.NoteList.FirstOrDefault(e => e.Id == Notechange.Id);
            if (note!= null)
            {
                note.Title = Notechange.Title;
                note.Description = Notechange.Description;
                note.UpdatedOn = Notechange.UpdatedOn;
                note.UpdatedBy = Notechange.UpdatedBy;
                note.CreatedBy = Notechange.CreatedBy;
                note.CreatedOn = Notechange.CreatedOn;
                note.Finished = Notechange.Finished;
                note.Deleted = Notechange.Deleted;

            }

            return note;
        }
    }
}
