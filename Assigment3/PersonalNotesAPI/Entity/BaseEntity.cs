using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entity
{
    public abstract class BaseEntity : IBaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Column("Deleted")]
        public bool? Deleted { get; set; }

        [Column("CreatedBy")]
        [Required]
        public string CreatedBy { get; set; }

        [Column("CreatedOn")]
        [Required]
        public DateTime? CreatedOn { get; set; }
       
    }

    public interface IBaseEntity
    {

    }
}
