using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Configurations;
using PersonalNotesAPI.Entity;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Data
{
    public class Datacontext : IdentityDbContext<ApplicationUser>
    {
        private readonly IUserResolverService _userResolverService;
        public Datacontext(DbContextOptions<Datacontext> options, IUserResolverService userResolverService)
            : base(options)
        {
            _userResolverService = userResolverService;

        }
        public Datacontext(DbContextOptions<Datacontext> options)
            : base(options)
        {
            

        }

    
        public DbSet<NotesEntity> Notes { get; set; }
        public DbSet<NotebookEntity> Notebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NoteMappingConfiguration());
        }
        private void SaveChangeOverride()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in modifiedEntries)
            {
                var entry = entityEntry;
                if (entry.Entity.GetType().GetInterface(typeof(IAuditBaseEntity).Name) != null)
                {

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("UpdatedBy").CurrentValue = _userResolverService.CurrentUserName();
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
                    }
                }

                if (entry.Entity.GetType().GetInterface(typeof(IBaseEntity).Name) != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedBy").CurrentValue = _userResolverService.CurrentUserName();
                    }

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            SaveChangeOverride();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SaveChangeOverride();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        

    }
}


