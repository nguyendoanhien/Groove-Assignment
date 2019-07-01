using PersonalNotesAPI.Models.Note;
using System.Collections.Generic;

namespace PersonalNotesAPI.Services
{
    public interface INotesService
    {
        IEnumerable<IndexModel> GetNoteList();
        IEnumerable<FullModel> GetNoteListFullModel();
        void AddNote(CreateModel note);
        EditModel GetNoteForEdit(int id);
        void EditNote(EditModel data);
        bool CheckExisting(int id);
        void DeleteNote(int id);
    }
}
