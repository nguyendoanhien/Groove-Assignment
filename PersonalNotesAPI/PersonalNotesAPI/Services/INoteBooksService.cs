using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services
{
    public interface INotebooksService
    {
        IEnumerable<Notebook> GetList();
        Notebook GetSingleById(int id);
        Notebook CreateNew(Notebook Notebook);
        Notebook Delete(int id);
        Notebook Upate(Notebook Notebook);
    }
}
