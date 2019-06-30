
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entities
{
    public class NotebookEntity
    {
        int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        //[NotebookExist]
        public int? ParentId { get; set; }

        [Required(ErrorMessage = "CreatedBy is required")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool Deleted { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
