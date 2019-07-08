using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using PersonalNotesAPI.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Service.Interface
{
   public interface INotesService
    {
        //IEnumerable<IndexModel> GetNoteList();
        IEnumerable<FullModel> GetNoteListFullModel();
        void AddNote(CreateModel note);
        EditModel GetNoteForEdit(int id);
        void EditNote(EditModel data);
        bool CheckExisting(int id);
        void DeleteNote(int id);
    }
}
