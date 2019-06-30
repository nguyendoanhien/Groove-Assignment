using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Entities;
using PersonalNotesAPI.Models;
using PersonalNotesAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Data
{
    public class NoteDBContext: IdentityDbContext<ApplicationUser>
    {
        private readonly IUserResolverRepository _userResolverRepo;
        public NoteDBContext(DbContextOptions<NoteDBContext> options, IUserResolverRepository userResolverRepo) 
            : base(options)
        {
            _userResolverRepo = userResolverRepo;
        }

        public NoteDBContext(DbContextOptions<NoteDBContext> options)
            : base(options)
        {

        }

        public DbSet<NoteEntity> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
