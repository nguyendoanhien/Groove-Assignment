using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalNotesDAL.Entities
{
    public abstract class AuditBaseEntity<TKey> : BaseEntity<TKey>, IAuditBaseEntity
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
