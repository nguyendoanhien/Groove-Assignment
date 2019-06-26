using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.ViewModels;

namespace PersonalNotesAPI.Services
{
    public class NotesService : INotesService
    {

        private DataStorage _db;

        public NotesService(DataStorage db)
        {
            _db = db;
        }


        public Note CreateNew(Note note)
        {
            note.Id = _db.Notes.Max(n => n.Id) + 1;
            _db.Notes.Add(note);
            return note;
        }

        public Note Delete(int Id)
        {
            var note = _db.Notes.SingleOrDefault(n => n.Id == Id);
            if (note != null)
                _db.Notes.Remove(note);
            return note;
        }

        public IEnumerable<Note> GetList()
        {
            return _db.Notes;
        }

        public Note GetSingleById(int Id)
        {
            return _db.Notes.SingleOrDefault(n => n.Id == Id);
        }
        
        public Note Upate(NoteVM note)
        {
            Note updatedNote = _db.Notes.SingleOrDefault(n => n.Id == note.Id);
            Mapper.Map<NoteVM, Note>(note, updatedNote);

            return updatedNote;
        }
    }
}
