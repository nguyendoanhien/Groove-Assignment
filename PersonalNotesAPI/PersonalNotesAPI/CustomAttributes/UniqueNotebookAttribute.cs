using PersonalNotesAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.CustomAttributes
{
    public class UniqueNotebookAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            INotesService db = (INotesService)validationContext.GetService(typeof(INotesService));
            var instance = validationContext.ObjectInstance; // which is instance of ModelClass
            var instanceType = validationContext.ObjectType; //which is typeof(ModelClass)
            var dispayName = validationContext.DisplayName;
           
            var otherProperty = validationContext.ObjectType.GetProperty("Id");
            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if (!otherPropertyValue.Equals(value) &&  db.GetSingleById((int)otherPropertyValue) != null)
            {
                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
