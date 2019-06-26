using PersonalNotesAPI.Models;
using PersonalNotesAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateNote(this Note note, NoteVM noteVM)
        {
            note.Description = noteVM.Description;
        }
    }
}
