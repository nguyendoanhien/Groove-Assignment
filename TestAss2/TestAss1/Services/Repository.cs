using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Models;

namespace TestAss1.Services
{
    public interface INotebook
    {
        Notebook GetNotebook(int Id);
        IEnumerable<Notebook> getAllNotebook();
        Notebook Add(Notebook notebook);
        Notebook Update(Notebook notebookChange);
        Notebook Delete(int Id);
    }

    public interface INote
    {
        Note GetNote(int Id);
        IEnumerable<Note> getAllNote();
        Note Add(Note note);
        Note Update(Note noteChange);
        Note Delete(int Id);
    }

    public interface IUserResolverService
    {
        string CurrentUserName();
    }
}
