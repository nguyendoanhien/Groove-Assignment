using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options)
           : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
    }
}
