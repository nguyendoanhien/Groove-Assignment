using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Models;

namespace TestAss1.Data
{
    public interface IInitial
    {
        List<Notebook> createListNotebook();
        List<Note> createListNote();
    }

    public class DataSource : IInitial
    {
        private List<Notebook> _notebooks;
        private List<Note> _notes;

        public List<Note> createListNote()
        {
            _notes = new List<Note>();
            return _notes;
        }

        public List<Notebook> createListNotebook()
        {
            _notebooks = new List<Notebook>()
            {
                new Notebook(){Id=1,Name="Test1",CreatedBy="PhuongNam",CreatedOn=DateTime.Now},
                new Notebook(){Id=2,Name="Test2",CreatedBy="John",CreatedOn=DateTime.Now},
                new Notebook(){Id=3,Name="Test3",CreatedBy="Wick",CreatedOn=DateTime.Now},

            };
            return _notebooks;

        }

       
    }

}

