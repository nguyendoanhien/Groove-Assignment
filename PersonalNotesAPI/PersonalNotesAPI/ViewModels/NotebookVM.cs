using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.ViewModels
{
    public class NotebookVM
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

       
        public int? ParentId { get; set; }
       
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
        
        public byte[] Timestamp { get; set; }
    }
}
