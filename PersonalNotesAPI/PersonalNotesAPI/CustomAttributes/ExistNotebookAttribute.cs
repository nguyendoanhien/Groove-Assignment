using PersonalNotesAPI.Data;
using PersonalNotesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.CustomAttributes
{
    public class ExistNotebookAttribute : ValidationAttribute
    {
        //private readonly INotesService _notebooksService;

        //public ExistNotebookAttribute(INotesService notebooksService)
        //{
        //    _notebooksService = notebooksService;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int)
            {
                INotesService db = (INotesService)validationContext.GetService(typeof(INotesService));
                if (db.GetSingleById((int)value) != null)
                {
                    return ValidationResult.Success;
                }


            }
            return new ValidationResult("noteBookId không tồ lại");
        }
    }
}
