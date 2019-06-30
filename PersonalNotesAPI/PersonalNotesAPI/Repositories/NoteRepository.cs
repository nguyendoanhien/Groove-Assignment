using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Data;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories
{
    public class NoteRepository: INoteRepository
    {
        protected readonly NoteDBContext context;
        protected readonly IUserResolverRepository UserResolverService;

        private DbSet<NoteEntity> _entity;

        protected DbSet<NoteEntity> Note => _entity ?? (_entity = context.Set<NoteEntity>());

         public NoteRepository(NoteDBContext context, IUserResolverRepository userResolverService)
        {
            this.context = context;
            UserResolverService = userResolverService;
        }

        public NoteEntity this[int id] => Note.FirstOrDefault(x => x.Id == id && (x.Deleted == null || !x.Deleted.Value) &&
                                                    x.CreatedBy == UserResolverService.CurrentUserName());

        public void AddNote(NoteEntity note)
        {
            note.CreatedOn = DateTime.Now;
            note.CreatedBy = UserResolverService.CurrentUserName();
            Note.Add(note);
            context.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            NoteEntity storedNote = context.Note.FirstOrDefault(x => x.Id.Equals(id) &&
                                            (x.Deleted == null || x.Deleted.Value) &&
                                            x.CreatedBy == UserResolverService.CurrentUserName());
            if (storedNote == null) return;
            storedNote.Deleted = true;
            context.Attach(storedNote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void UpdateNote(NoteEntity note)
        {
            note.UpdatedBy = UserResolverService.CurrentUserName();
            note.UpdatedOn = DateTime.Now;
            var oldNote = Note.Attach(note);
            oldNote.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<NoteEntity> Notes()
        {
            return Note.AsNoTracking().Where(x => (x.Deleted == null || !x.Deleted.Value) &&
                                                    x.CreatedBy == UserResolverService.CurrentUserName());
        }

        public NoteEntity GetNoteEntityById(int id)
        {
            return Note.FirstOrDefault(x => x.Id == id && (x.Deleted == null || !x.Deleted.Value) &&
                                                    x.CreatedBy == UserResolverService.CurrentUserName());
        }
    }
}
