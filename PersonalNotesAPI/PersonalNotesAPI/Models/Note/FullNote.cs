using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models.Note
{
    public class FullNote: AuditBaseNote
    {
        [Required(ErrorMessage = "Please input this field")]
        [StringLength(50, ErrorMessage = "50 characters maximum")]
        public string Title { get; set; }

        [StringLength(255, ErrorMessage = "255 characters maximum")]
        public string Description { get; set; }

        [DisplayName("Is done?")] public bool isdone { get; set; }

        public int NotebookId { get; set; }
    }
}
