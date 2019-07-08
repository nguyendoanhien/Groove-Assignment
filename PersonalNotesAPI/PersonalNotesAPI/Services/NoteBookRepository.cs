using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.DataBase;
using PersonalNotesAPI.Models;


namespace PersonalNotesAPI.Services
{
    public class NoteBookRepository : INoteBookRepository

    {
        private readonly DataContext _context;
        public NoteBookRepository(DataContext context)
        {
            _context = context;
        }

        public Notebook CreateNotebook(Notebook notebook)
        {
            notebook.CreatedBy = "adajhsdavjsdasa";
            notebook.CreatedOn = DateTime.Now;
            _context.Notebooks.Add(notebook);
            _context.SaveChanges();
            return notebook;
        }

        public Notebook GetNotebook(int Id)
        {
            return _context.Notebooks.Find(Id);
            
        }

        public IEnumerable<Notebook> GetNotebookList()
        {
            return _context.Notebooks.ToList();
        }

        public Notebook RemoveNotebook(int Id)
        {
            Notebook notebook = _context.Notebooks.Find(Id);
            notebook.Deleted = true;
            _context.Notebooks.Attach(notebook);
            _context.Entry(notebook).State = EntityState.Modified;
            _context.SaveChanges();
            return notebook;
        }

        public Notebook UpdateNotebook(Notebook notebookChange)
        {
            Notebook notebook = _context.Notebooks.Find(notebookChange.Id);
            
            notebook.Deleted = notebookChange.Deleted;
            notebook.UpdatedBy = "";
            notebook.UpdatedOn = DateTime.Now;
            _context.Notebooks.Attach(notebook);
            _context.Entry(notebook).State = EntityState.Modified;
            _context.SaveChanges();
            return notebook;
        }
    }
}
