using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LittleHelpMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LittleHelpMVC.Data
{
    public class LittleHelpMVCDbContext : DbContext
    {
        public DbSet<LittleHelp> Helpers { get; set; }
        public DbSet<HelpCategory> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public LittleHelpMVCDbContext(DbContextOptions<LittleHelpMVCDbContext> options)
        : base(options)
        { }

    }
}
