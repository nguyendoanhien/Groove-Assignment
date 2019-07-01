using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Entity
{
    public abstract class AuditBaseEntity : BaseEntity, IAuditBaseEntity
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
