using PersonalNotesAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories.Interface
{
    public interface INotesRepositories
    {
        IEnumerable<NotesEntity> GetAll();
        NotesEntity GetSingle(int entityId);
    
        void Add(BaseEntity entity);
        void Delete(BaseEntity entityId);
        void Edit(BaseEntity entity);
        bool CheckExistingById(int id);
    }
}
