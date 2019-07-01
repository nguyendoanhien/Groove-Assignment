using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAss1.Models
{
    public class Notebook
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [MaxLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public virtual IEnumerable<Note> Notes { get; set; }
    }
}
