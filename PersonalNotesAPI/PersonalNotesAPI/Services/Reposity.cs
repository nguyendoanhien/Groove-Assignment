﻿using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services
{
        public interface INoteRepository
        {
            IEnumerable<Note> GetNoteList();
            Note GetNote(int Id);
            Note CreateNote(string newNote);
            Note UpdateNote(Note noteChange);
            Note RemoveNote(int Id);
        }

        public interface INoteBookRepository
        {
            IEnumerable<Notebook> GetNotebookList();
            Notebook GetNotebook(int Id);
            Notebook CreateNotebook(string name);
            Notebook UpdateNotebook(Notebook notebookChange);
            Notebook RemoveNotebook(int Id);

        }

}
