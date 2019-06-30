using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services.Interface
{
    public interface INoteService
    {
        IEnumerable<IndexNote> GetNoteList();
        IEnumerable<FullNote> GetNoteListFullModel();
        void AddNote(CreateNote note);
        EditNote GetNoteForEdit(int id);
        NoteEntity GetNoteById(int id);
        void UpdateNote(EditNote note);
        void DeleteNote(int id);
    }
}
