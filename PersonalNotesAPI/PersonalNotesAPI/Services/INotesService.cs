using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services
{
    public interface INotesService
    {
        IEnumerable<Note> GetList();
        Note GetSingleById(int id);
        Note CreateNew(Note note);
        Note Delete(int id);
        Note Upate(Note note);
    }
}
