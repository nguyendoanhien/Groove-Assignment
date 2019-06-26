using Microsoft.EntityFrameworkCore;
using PersonalNotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Data
{
    public class NoteDBContext: DbContext
    {
        public NoteDBContext(DbContextOptions<NoteDBContext> options) : base(options)
        {

        }

        public DbSet<Note> Note { get; set; }
        public DbSet<Notebook> Notebook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            modelBuilder.Entity<Notebook>().HasData(
                new Notebook
                {
                    Id = 1,
                    Name = "Notebook01",
                    ParentId = null,
                    CreatedBy = "Truc",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    Deleted = false,
                    Timestamp = null
                },
                new Notebook
                {
                    Id = 2,
                    Name = "Notebook02",
                    ParentId = null,
                    CreatedBy = "Truc",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    Deleted = false,
                    Timestamp = null
                });
            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = 1,
                    Title = "Note01",
                    Description = "Description note 01",
                    Finished = false,
                    CreatedBy = "Truc",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    Deleted = false,
                    NotebookId = 1,
                    Timestamp = null
                },
                new Note
                {
                    Id = 2,
                    Title = "Note02",
                    Description = "Description note 02",
                    Finished = false,
                    CreatedBy = "Truc",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    Deleted = false,
                    NotebookId = 1,
                    Timestamp = null
                },
                new Note
                {
                    Id = 3,
                    Title = "Note03",
                    Description = "Description note 03",
                    Finished = false,
                    CreatedBy = "Truc",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "",
                    UpdatedOn = null,
                    Deleted = false,
                    NotebookId = 2,
                    Timestamp = null
                });
        }

    }
}
