using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public interface INotesRepository
    {
        Note GetNote(int Id);

        IEnumerable<Note> GetNotes();
        Note AddNotes(Note Note);
        Note UpdateNotes(Note Notechange);
        Note DeleteNote(int id);
    }
}
