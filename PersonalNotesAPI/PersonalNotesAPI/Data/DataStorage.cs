using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Data
{
    public class DataStorage
    {
        public List<Note> Notes { get; set; }
        public List<Notebook> Notebooks { get; set; }

        public DataStorage()
        {
            Notes = new List<Note>()
            {
                new Note()
                {
                    Id=1,NotebookId=1,Title="123",Description="Description"
                },
                new Note()
                {
                    Id=2,NotebookId=2
                }


            };
            Notebooks = new List<Notebook>()
            {
                new Notebook()
                {
                    Id=1
                },new Notebook()
                {
                    Id=2,ParentId=1
                },

            };
        }
    }
}
