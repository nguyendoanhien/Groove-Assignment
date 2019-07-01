using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Services;

namespace TestAss1.Validation
{
    public class NotebookIdAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext)
        {
            INotebook notebook = (INotebook)validationContext.GetService(typeof(INotebook));
            var result = notebook.GetNotebook((int)value);
            if (result == null)
            {
                return new ValidationResult("NotebookId does not exist");
            }

            return ValidationResult.Success;
        }
    }
}
