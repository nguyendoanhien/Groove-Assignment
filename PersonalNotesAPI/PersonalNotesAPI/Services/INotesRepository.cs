using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonalNotesAPI.Models;
namespace PersonalNotesAPI.Service
{
    public interface INotesRepository
    {
        List<Note> Notes{ get;}
        Note this[int id] { get;}
        Note AddNote(Note note);
        Note UpdateNote(Note note);
        Note DeleteNote(int id);
    }
}
