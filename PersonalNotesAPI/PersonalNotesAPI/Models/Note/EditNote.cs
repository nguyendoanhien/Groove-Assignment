using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models.Note
{
    public class EditNote : AuditBaseNote
    {
        [Required(ErrorMessage = "Please input this field")]
        [StringLength(50, ErrorMessage = "50 characters maximum")]
        public string Title { get; set; }
        [StringLength(255, ErrorMessage = "255 characters maximum")]
        public string Description { get; set; }
        [DisplayName("Is done?")]
        public bool Finished { get; set; }

    }
}
