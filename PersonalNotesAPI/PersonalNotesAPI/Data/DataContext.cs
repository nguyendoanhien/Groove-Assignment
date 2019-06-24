using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class DataContext
    {
        public List<Note> notes { get; set; }
        public List<Notebook> notebooks { get; set; }

        public DataContext()
        {
            notes = new List<Note>() {
             new Note {
                Id =1,
                Title ="Note01",
                Description ="Description note 01",
                Finished =false,
                CreatedBy ="Truc",
                CreatedOn =DateTime.Now,
                UpdatedBy ="",
                UpdatedOn =null,
                Deleted =false,
                NotebookId =1,
                Timestamp =null },
            new Note {
                Id =2,
                Title ="Note02",
                Description ="Description note 02",
                Finished =false,
                CreatedBy ="Truc",
                CreatedOn =DateTime.Now,
                UpdatedBy ="",
                UpdatedOn =null,
                Deleted =false,
                NotebookId =1,
                Timestamp =null },
            new Note {
                Id =3,
                Title ="Note03",
                Description ="Description note 03",
                Finished =false,
                CreatedBy ="Truc",
                CreatedOn =DateTime.Now,
                UpdatedBy ="",
                UpdatedOn =null,
                Deleted =false,
                NotebookId =2,
                Timestamp =null }
            };
            notebooks = new List<Notebook>() {
            new Notebook {
                Id =1,
                Name ="Notebook01",
                ParentId =null,
                CreatedBy ="Truc",
                CreatedOn =DateTime.Now,
                UpdatedBy ="",
                UpdatedOn =null,
                Deleted =false,
                Timestamp =null },
            new Notebook {
                Id =2,
                Name ="Note02",
                ParentId =null,
                CreatedBy ="Truc",
                CreatedOn =DateTime.Now,
                UpdatedBy ="",
                UpdatedOn =null,
                Deleted =false,
                Timestamp =null }};
        }
    }
}
