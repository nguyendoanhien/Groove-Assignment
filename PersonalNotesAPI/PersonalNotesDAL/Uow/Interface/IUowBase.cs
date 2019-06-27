using Microsoft.EntityFrameworkCore;

namespace PersonalNotesDAL.Uow.Interface
{
    public interface IUowBase<TContext> where TContext : DbContext
    {
        void SaveChanges();
        void SaveChangesAsync();
    }
}
