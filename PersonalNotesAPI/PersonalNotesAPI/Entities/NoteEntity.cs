
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entities
{
    public class NoteEntity: AuditBaseNoteEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NotebookId { get; set; }
        public bool isdone { get; set; }
    }
}
