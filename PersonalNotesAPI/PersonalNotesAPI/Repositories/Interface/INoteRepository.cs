using PersonalNotesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories.Interface
{
    public interface INoteRepository
    {
        IQueryable<NoteEntity> GetAll();
        NoteEntity GetSingle(int noteId);
        IQueryable<NoteEntity> FindBy(Expression<Func<NoteEntity, bool>> predicate);
        void Add(NoteEntity note);
        void Delete(int noteId);
        void Edit(NoteEntity note);
        bool CheckExistingById(int id);
    }
}
