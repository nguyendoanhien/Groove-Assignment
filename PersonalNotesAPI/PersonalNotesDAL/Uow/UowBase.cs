using Microsoft.EntityFrameworkCore;
using PersonalNotesDAL.Uow.Interface;

namespace PersonalNotesDAL.Uow
{
    public class UowBase<TContext> : IUowBase<TContext> where TContext:DbContext
    {
        protected readonly DbContext DbContext;
        public UowBase(TContext dbContext)
        {
            DbContext = dbContext;
        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            DbContext.SaveChangesAsync();
        }
    }
}
