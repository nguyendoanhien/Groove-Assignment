using System;
using PersonalNotesAPI.Model.Abstracts;

namespace PersonalNotesAPI.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public string CreatedBy { get ; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get ; set; }
        public DateTime? UpdatedOn { get ; set; }
    }
}
