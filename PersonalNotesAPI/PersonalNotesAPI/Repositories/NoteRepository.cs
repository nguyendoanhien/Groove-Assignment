using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Repositories.Interface;
using PersonalNotesAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories
{
    public class NoteRepository : INoteRepository
    {
        protected readonly NoteDBContext NoteDBContext;
        protected readonly IUserResolverService UserResolverService;

        private DbSet<NoteEntity> _entity;

        protected DbSet<NoteEntity> Entity => _entity ?? (_entity = NoteDBContext.Set<NoteEntity>());

        public NoteRepository(NoteDBContext dbContext, IUserResolverService userResolverService)
        {
            NoteDBContext = dbContext;
            UserResolverService = userResolverService;
        }

        public IQueryable<NoteEntity> GetAll()
        {
            return Entity.AsNoTracking().Where(x => (x.Deleted == null || !x.Deleted.Value) &&
                                                    x.CreatedBy == UserResolverService.CurrentUserName());
            //x.CreatedBy == UserResolverService.CurrentUserName());
        }

        public NoteEntity GetSingle(int entityId)
        {
            return Entity.AsNoTracking().FirstOrDefault(x =>
                x.Id.Equals(entityId) && (x.Deleted == null || !x.Deleted.Value) &&
                x.CreatedBy == UserResolverService.CurrentUserName());
        }

        public IQueryable<NoteEntity> FindBy(Expression<Func<NoteEntity, bool>> predicate)
        {
            return Entity.AsNoTracking().Where(x => (x.Deleted == null || !x.Deleted.Value) &&
                                                    x.CreatedBy == UserResolverService.CurrentUserName())
                .Where(predicate);
        }

        public void Add(NoteEntity entity)
        {
            entity.CreatedBy = UserResolverService.CurrentUserName();
            entity.CreatedOn = DateTime.Now;
            Entity.Add(entity);
        }

        public Task<EntityEntry<NoteEntity>> AddAsync(NoteEntity entity)
        {
            var result = Entity.AddAsync(entity);
            return result;
        }

        public void Delete(int entityId)
        {
            var storedEntity = Entity.AsNoTracking().FirstOrDefault(x =>
                x.Id.Equals(entityId) && (x.Deleted == null || !x.Deleted.Value) &&
                x.CreatedBy == UserResolverService.CurrentUserName());
            if (storedEntity == null) return;
            storedEntity.Deleted = true;
            Entity.Attach(storedEntity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int entityId)
        {
            var storedEntity = await Entity.FirstOrDefaultAsync(x =>
                x.Id.Equals(entityId) && (x.Deleted == null || !x.Deleted.Value) &&
                x.CreatedBy == UserResolverService.CurrentUserName());
            if (storedEntity == null) return;
            storedEntity.Deleted = true;
            Entity.Attach(storedEntity).State = EntityState.Modified;
        }

        public void Edit(NoteEntity entity)
        {
            var storedEntity = Entity.Attach(entity);
            storedEntity.State = EntityState.Modified;
        }

        public bool CheckExistingById(int id)
        {
            var result = Entity.AsNoTracking().Any(x => x.Id.Equals(id));
            return result;
        }
    }
}
