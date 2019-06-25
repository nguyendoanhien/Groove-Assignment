using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalNotesAPI.Models;
namespace PersonalNotesAPI.Service
{
    public class NotebooksService : INotebooksRepository
    {
        private DataProvider _db;
        public NotebooksService(DataProvider db)
        {
            _db = db;
        }
        public Notebook this[int id] => _db.notebooks.FirstOrDefault(x => x.Id == id);

        public List<Notebook> Notebooks => _db.notebooks;

        public Notebook AddNotebook(Notebook notebook)
        {
            int NotebookId = _db.notebooks.Max(x => x.Id) + 1;
            notebook.Id = NotebookId;
            _db.notebooks.Add(notebook);
            return notebook;
        }

        public void DeleteNotebook(int id)
        {
            Notebook note = _db.notebooks.FirstOrDefault(x => x.Id == id);
            _db.notebooks.Remove(note);
        }

        public Notebook UpdateNotebook(Notebook notebook) => AddNotebook(notebook);

        public bool IsExistNotebook(int id)
        {
            Notebook notebook = _db.notebooks.FirstOrDefault(x => x.Id == id);
            if (notebook != null)
                return false;
            else return true;
        }
    }
}
