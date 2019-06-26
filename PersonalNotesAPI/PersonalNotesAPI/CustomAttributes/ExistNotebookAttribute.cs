using PersonalNotesAPI.Data;
using PersonalNotesAPI.Models;
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
        //public string OtherProperty { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);
            INotesService db = (INotesService)validationContext.GetService(typeof(INotesService));
           
            if (value is int)
            {

                if (db.GetSingleById((int)value) != null)
                {
                    return ValidationResult.Success;
                }
                else return new ValidationResult("noteBookId không tồn lại");


            }

            return ValidationResult.Success;
       



        }
    }
}
