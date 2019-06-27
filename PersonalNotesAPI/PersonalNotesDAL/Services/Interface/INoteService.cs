using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalNotesDAL.Models.Note;

namespace PersonalNotesDAL.Services.Interface
{
    public interface INoteService
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
