using Microsoft.AspNetCore.Mvc;
using PersonalNotesAPI.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class Note
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
     
        public string Title { get; set; }


        //[RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [Required(ErrorMessage = "Description bắt buộc phải nhập")]
        //[StringLength(10, MinimumLength = 5, ErrorMessage = "Tên phải từ 5 đến 10 kí tự")]
        public string Description { get; set; }
        public bool Finished { get; set; }
        [Range(1,100)]

        [ExistNotebook]
        public int NotebookId { get; set; }

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
