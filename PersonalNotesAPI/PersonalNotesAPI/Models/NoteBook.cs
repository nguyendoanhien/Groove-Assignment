using PersonalNotesAPI.CustomAttributes;
using PersonalNotesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class Notebook
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        [ExistNotebook]
        [NotEqualTo("Id")]
        public int? ParentId { get; set; }
        [Required]
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
