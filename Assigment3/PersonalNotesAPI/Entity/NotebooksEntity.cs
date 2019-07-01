using PersonalNotesAPI.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entity
{
    public class NotebooksEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NoteidparentValidation]
        public int? ParentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot 50 character")]
        public string UpdatedBy { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Cannot 50 character")]
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
