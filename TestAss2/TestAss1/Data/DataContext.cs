using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Models;

namespace TestAss1.Data
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {      
            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }
  
            public DbSet<Notebook> Notebooks { get; set; }
            public DbSet<Note> Notes { get; set; }
            public DbSet<ApplicationUser> applicationUsers { get; set; }
        public object HttpContext { get; internal set; }
    }
}
