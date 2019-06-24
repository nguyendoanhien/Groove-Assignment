using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalNotesAPI.Models
{
    public class NoteVM
    {      
        public int Id { get; set; }
        [MaxLength(255, ErrorMessage = "Title length can't be more than 255.")]
        [Required(ErrorMessage = "The title field is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public int NotebookId { get; set; }
        public bool Deleted { get; set; }
        public byte[] Timestamp { get; set; }

        // Auditable
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual NotebookVM Notebook { get; set; }
    }
}
