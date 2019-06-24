using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public interface INotebooksRepository
    {
        List<Notebook> Notebooks { get; }
        Notebook this[int id] { get; }
        Notebook AddNotebook(Notebook notebook);
        Notebook UpdateNotebook(Notebook notebook);
        void DeleteNotebook(int id);
    }
}
