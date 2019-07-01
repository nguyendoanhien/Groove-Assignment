using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.ModelValidation
{
    public class NoteidparentValidation : ValidationAttribute
    {
       

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {

            INotesBookRepository db = (INotesBookRepository)validationContext.GetService(typeof(INotesBookRepository));
           
            int id = (int)value;
            if (db.GetNoteBook(id)== null)
            {
                return new ValidationResult(" Parent Id does not exist");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}


    

