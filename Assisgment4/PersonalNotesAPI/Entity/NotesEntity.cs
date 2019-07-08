using PersonalNotesAPI.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entity
{
    public class NotesEntity : AuditBaseEntity
    {
        
        [Required, MaxLength(50, ErrorMessage = "Cannot 50 character")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Finished { get; set; }

        [Notebookvalidation]
        public int NotebookId { get; set; }


     
    }
}
