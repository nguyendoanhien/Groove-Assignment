using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entities
{
    public class AuditBaseNoteEntity: BaseEntity, IAuditBaseEntity
    {
        [Column("UpdatedBy")]
        public string UpdatedBy { get; set; }

        [Column("UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
    public interface IAuditBaseEntity
    {
    }
}
