using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services
{
    public class NotebooksService:INotebooksService
    {
        //private List<Notebook> _db.Notebooks;
        private DataStorage _db;

        public NotebooksService(DataStorage db)
        {
            //_db.Notebooks = new List<Notebook>();
            _db = db; ;
        }

        public Notebook CreateNew(Notebook Notebook)
        {
            Notebook.Id = _db.Notebooks.Max(n => n.Id) + 1;
            _db.Notebooks.Add(Notebook);
            return Notebook;
        }

        public Notebook Delete(int Id)
        {
            var Notebook = _db.Notebooks.SingleOrDefault(n => n.Id == Id);
            if (Notebook != null)
                _db.Notebooks.Remove(Notebook);
            return Notebook;
        }

        public IEnumerable<Notebook> GetList()
        {
            return _db.Notebooks;
        }

        public Notebook GetSingleById(int Id)
        {
            return _db.Notebooks.SingleOrDefault(n => n.Id == Id);
        }

        public Notebook Upate(Notebook Notebook)
        {
            throw new NotImplementedException();
        }
    }
}
