using PersonalNotesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Requirement
{
    public class RequirementByNotebookID : ValidationAttribute
    {
        public INoteBookRepository notebook;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            notebook = (INoteBookRepository)validationContext.GetService(typeof(INoteBookRepository));
            if (notebook.GetNotebookList().FirstOrDefault(x => x.Id == (int)value) == null)
                return new ValidationResult("ID is not exist");
            else return ValidationResult.Success;
        }
    }
}
