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
            Notes = new List<Note>();
            Notebooks = new List<Notebook>();
        }
    }
}
