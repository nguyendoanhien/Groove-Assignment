using PersonalNotesAPI.Models;
using PersonalNotesAPI.ViewModels;
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
        Note Upate(NoteVM note);
    }
}
