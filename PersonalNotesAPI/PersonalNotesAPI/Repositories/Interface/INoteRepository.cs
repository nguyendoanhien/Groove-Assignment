using PersonalNotesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories.Interface
{
    public interface INoteRepository
    {
        IEnumerable<NoteEntity> Notes();
        NoteEntity GetNoteEntityById(int id);
        void AddNote(NoteEntity note);
        void UpdateNote(NoteEntity note);
        void DeleteNote(int id);

    }
}
