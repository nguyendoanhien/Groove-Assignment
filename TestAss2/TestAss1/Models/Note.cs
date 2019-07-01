using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Validation;

namespace TestAss1.Models
{
    public class Note
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
        [Required]
        [MaxLength(50, ErrorMessage = "CreatedBy length can't be more than 50.")]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [MaxLength(50, ErrorMessage = "UpdatedBy length can't be more than 50.")]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        [ForeignKey("NotebookId")]
        public virtual Notebook Notebook { get; set; }
    }
}
