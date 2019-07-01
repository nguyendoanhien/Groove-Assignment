using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories.Interface
{
    public interface INotebooksRepository
    {
        IEnumerable<Notebook> Notebooks { get; }
        Notebook this[int id] { get; }
        Notebook AddNotebook(Notebook notebook);
        Notebook UpdateNotebook(Notebook notebook);
        void DeleteNotebook(int id);
    }
}
