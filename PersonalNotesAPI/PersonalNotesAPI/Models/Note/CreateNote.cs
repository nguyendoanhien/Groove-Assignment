using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models.Note
{
    public class CreateNote
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool? Finished { get; set; }

        //[NoteExist]
        public int NotebookId { get; set; }

    }
}
