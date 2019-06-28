using Microsoft.EntityFrameworkCore;

namespace PersonalNotesAPI.Uow.Interface
{
    public interface IUowBase<TContext> where TContext : DbContext
    {
        void SaveChanges();
        void SaveChangesAsync();
    }
}
