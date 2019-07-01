using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public interface INotesBookRepository
    {
        Notebook GetNoteBook(int Id);
      
        IEnumerable<Notebook> GetNotebooks();
        Notebook AddNotebooks(Notebook notebook);
        Notebook UpdateNotebooks(Notebook notebookchange);
        Notebook DeleteNotebook(int id);
    }
}
