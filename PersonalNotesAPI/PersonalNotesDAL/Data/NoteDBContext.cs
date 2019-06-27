using PersonalNotesDAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalNotesDAL.Entities;
using PersonalNotesDAL.Models;
using PersonalNotesDAL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalNotesDAL.Data
{
    public class NoteDBContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly IUserResolverService _userResolverService;

        //public NoteDBContext(DbContextOptions<NoteDBContext> options,
        //    IUserResolverService userResolverService)
        //    : base(options)
        //{
        //    _userResolverService = userResolverService;
        //}

        public NoteDBContext(DbContextOptions<NoteDBContext> options)
            : base(options)
        {
        }
        public DbSet<NoteEntity> Notes { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);

        //    builder.ApplyConfiguration(new NoteMappingConfiguration());
        //}

        //private void SaveChangeOverride()
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entityEntry in modifiedEntries)
        //    {
        //        var entry = entityEntry;
        //        if (entry.Entity.GetType().GetInterface(typeof(IAuditBaseEntity).Name) != null)
        //        {

        //            if (entry.State == EntityState.Modified)
        //            {
        //                entry.Property("UpdatedBy").CurrentValue = _userResolverService.CurrentUserName();
        //            }

        //            if (entry.State == EntityState.Modified)
        //            {
        //                entry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
        //            }
        //        }

        //        if (entry.Entity.GetType().GetInterface(typeof(IBaseEntity).Name) != null)
        //        {
        //            if (entry.State == EntityState.Added)
        //            {
        //                entry.Property("CreatedBy").CurrentValue = _userResolverService.CurrentUserName();
        //            }

        //            if (entry.State == EntityState.Added)
        //            {
        //                entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
        //            }
        //        }
        //    }
        //}

        //public override int SaveChanges()
        //{
        //    SaveChangeOverride();
        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        //    CancellationToken cancellationToken = new CancellationToken())
        //{
        //    SaveChangeOverride();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

       

    }
}
