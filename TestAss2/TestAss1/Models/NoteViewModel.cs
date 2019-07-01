using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Validation;

namespace TestAss1.Models
{
    public class NoteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [MaxLength(50, ErrorMessage = "Title length can't be more than 50.")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Finished { get; set; }
        [NotebookId]
        public int NotebookId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        //public virtual NotebookViewModel Notebook { get; set; }
    }
}
