using PersonalNotesAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PersonalNotesAPI.ModelValidation
{
    public class NoteExist : ValidationAttribute
    {
        public INotebooksRepository _notebooksRepository;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            INotebooksRepository db = (INotebooksRepository)validationContext.GetService(typeof(INotebooksRepository));
            if (db.Notebooks.FirstOrDefault(x => x.Id == (int)value) == null)
                return new ValidationResult("NotebookId does not exist");
            else
                return ValidationResult.Success;
        }
    }
}
