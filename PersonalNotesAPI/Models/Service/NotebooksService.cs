using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models.Service
{
    public class NotebooksService : INotesBookRepository
    {
        private DataProvider _db;

        public DataProvider Db { get => _db; set => _db = value; }

        public NotebooksService(DataProvider db)
        {
            Db = db;
        }

        public Notebook GetNoteBook(int Id)
        {
            return Db.NotebooksList.FirstOrDefault(e => e.Id == Id
                );
        }

        public void  ADDNotebook( Notebook nb)
        {
      

            Db.NotebooksList.Add(nb);

        }

        public IEnumerable<Notebook> GetNotebooks()
        {
            return Db.NotebooksList;
        }

        public Notebook AddNotebooks(Notebook notebook)
        {
            notebook.Id = Db.NotebooksList.Max(e => e.Id) + 1;
            Db.NotebooksList.Add(notebook);
            return notebook;

        }

        public Notebook UpdateNotebooks(Notebook notebookchange)
        {
            Notebook notebook = Db.NotebooksList.FirstOrDefault(e => e.Id == notebookchange.Id);
                if (notebook != null)
                {
                notebook.Name = notebookchange.Name;
                notebook.ParentId = notebookchange.ParentId;
                notebook.UpdatedOn = notebookchange.UpdatedOn;
                notebook.UpdatedBy = notebookchange.UpdatedBy;
                notebook.CreatedBy = notebookchange.CreatedBy;
                notebook.CreatedOn= notebookchange.CreatedOn;

            }
            
            return notebook;
        }

        

        public Notebook DeleteNotebook(int id)
        {
            Notebook notebook = Db.NotebooksList.FirstOrDefault(e => e.Id == id);
            
                if (notebook != null) {
                    Db.NotebooksList.Remove(notebook);
                       }
            
            return notebook;
        }

    }
}
