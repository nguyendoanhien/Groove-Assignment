using PersonalNotesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Requirement
{
    public class RequirementByParentID : ValidationAttribute
    {
        public NoteBookRepository noteBook;

        protected override ValidationResult IsValid(object value , ValidationContext context)
        {
            noteBook = (NoteBookRepository)context.GetService(typeof(NoteBookRepository));
            if (noteBook.GetNotebookList().FirstOrDefault(x => x.ParentId == (int)value) == null)
            {
                return new ValidationResult("ParenID is no exist");
            }
            else return ValidationResult.Success;
        }
    }
}
