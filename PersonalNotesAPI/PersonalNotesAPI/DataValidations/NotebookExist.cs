using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PersonalNotesAPI.Service;
using PersonalNotesAPI.Models;

namespace PersonalNotesAPI.DataValidation
{
    public class NotebookExist: ValidationAttribute
    {
        public INotebooksRepository _notebooksRepository;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            INotebooksRepository db = (INotebooksRepository)validationContext.GetService(typeof(INotebooksRepository));
            if (db.Notebooks.FirstOrDefault(x => x.Id == (int)value) == null)
                return new ValidationResult("ParentId does not exist");
            else
                return ValidationResult.Success;
        }
    }
}
