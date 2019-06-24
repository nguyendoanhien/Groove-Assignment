using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Model.Models;

namespace PersonalNotesAPI.Data
{
    public class PersonalNotesDbContext : DbContext
    {
        public PersonalNotesDbContext(DbContextOptions options): base(options)
        {

        } 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
