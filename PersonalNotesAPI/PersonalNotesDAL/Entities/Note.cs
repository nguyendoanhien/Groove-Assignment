
using PersonalNotesDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesDAL.Models
{
    public class NoteEntity : AuditBaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
