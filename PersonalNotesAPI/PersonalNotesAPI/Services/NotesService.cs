using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models;

namespace PersonalNotesAPI.Services
{
    public class NotesService : INotesService
    {
        private List<Note> _noteList;


        public NotesService(DataStorage db)
        {
            _noteList = new List<Note>();
        }


        public Note CreateNew(Note note)
        {
            note.Id = _noteList.Max(n => n.Id) + 1;
            _noteList.Add(note);
            return note;
        }

        public Note Delete(int Id)
        {
            var note = _noteList.SingleOrDefault(n => n.Id == Id);
            if (note != null)
                _noteList.Remove(note);
            return note;
        }

        public IEnumerable<Note> GetList()
        {
            return _noteList;
        }

        public Note GetSingleById(int Id)
        {
            return _noteList.SingleOrDefault(n => n.Id == Id);
        }

        public Note Upate(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
