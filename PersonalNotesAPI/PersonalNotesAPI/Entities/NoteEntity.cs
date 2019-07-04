using PersonalNotesAPI.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entities
{
    public class NoteEntity : AuditBaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Is done?")]
        public bool IsDone { get; set; }
    }
}
